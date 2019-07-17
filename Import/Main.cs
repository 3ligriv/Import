using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Import
{
    public partial class frm_Main : Form
    {
        /// <summary>
        /// List of the pictures found.
        /// Contains info about each file and if it is selected.
        /// </summary>
        public List<Picture> Pictures { get; private set; }
        /// <summary>
        /// The total number of pictures found in the input folder.
        /// </summary>
        public int nbPics = 0;
        /// <summary>
        /// The number of pictures currently selected.
        /// </summary>
        public int nbSelectedPics = 0;

        public frm_Main()
        {
            InitializeComponent();
            Pictures = new List<Picture>();
        }

        private void Btn_selectPics(object sender, EventArgs e)
        {
            frm_Pictures childForm = new frm_Pictures();
            childForm.ShowDialog(this);
        }

        private void Btn_editMetadata_Click(object sender, EventArgs e)
        {
            frm_Metadata childForm = new frm_Metadata();
            childForm.ShowDialog(this);
        }

        private void Btn_pathFrom_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd_pathFrom.ShowDialog();
            if (result == DialogResult.OK)
                tbx_pathFrom.Text = fbd_pathFrom.SelectedPath;
        }

        private void Btn_pathTo_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd_pathTo.ShowDialog();
            if (result == DialogResult.OK)
                tbx_pathTo.Text = fbd_pathTo.SelectedPath;
        }

        private void Tbx_pathFrom_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(tbx_pathFrom.Text))
                StartSearch();
            else
            {
                grp_photos.Enabled = false;
                grp_options.Enabled = false;
                grp_to.Enabled = false;
                btn_import.Enabled = false;
            }
        }

        /// <summary>
        /// On form load, search for removable drives and if any, start the search.
        /// The drive selected is the one with a volume label containing a camera brand
        /// or if no correspondance, the first.
        /// </summary>
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            // 
            // fbd_pathFrom
            // 
            DriveInfo[] d = DriveInfo.GetDrives();
            List<DriveInfo> Drives = d.Where(drive => drive.DriveType == DriveType.Removable).ToList();
            bool found = false;
            foreach (var drive in Drives)
            {
                try
                {
                    if (drive.IsReady && SearchBrand(drive.VolumeLabel))
                    {
                        fbd_pathFrom.SelectedPath = drive.Name;
                        tbx_pathFrom.Text = drive.Name;
                        found = true;
                        break;
                    }
                }
                catch (Exception exc)
                {
                    LogError("Error when retrieving info for: " + drive.Name, exc);
                }
            }
            if (!found && Drives.Count > 0)
            {
                DriveInfo Drive = Drives.First();
                try
                {
                    if (Drive.IsReady)
                    {
                        fbd_pathFrom.SelectedPath = Drive.Name;
                        tbx_pathFrom.Text = Drive.Name;
                        found = true;
                    }
                }
                catch (Exception exc)
                {
                    LogError("Error when retrieving info for: " + Drive.Name, exc);
                }
            }
            if (found)
            {
                StartSearch();
            }

            //
            // tbx_pathTo
            //
            tbx_pathTo.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        /// <summary>
        /// Start the searching thread in background.
        /// If one was already running, stops it.
        /// </summary>
        private void StartSearch()
        {
            grp_photos.Enabled = false;
            grp_options.Enabled = false;
            grp_to.Enabled = false;
            btn_import.Enabled = false;
            if (bwk_searchPics.IsBusy)
            {
                bwk_searchPics.CancelAsync();
            }
            nbPics = 0;
            nbSelectedPics = 0;
            Pictures.Clear();

            bwk_searchPics.RunWorkerAsync();
        }

        /// <summary>
        /// Update the results of the search.
        /// Used by the searching thread.
        /// </summary>
        public void UpdateSearchResults()
        {
            lbl_nbPic.Text = nbSelectedPics + "/" + nbPics + " pictures selected.";
            if (nbPics > 0)
            {
                grp_photos.Enabled = true;
                grp_photos_Validate();
            }
            else
            {
                grp_photos.Enabled = false;
                grp_options.Enabled = false;
                grp_to.Enabled = false;
                btn_import.Enabled = false;
            }
        }

        /// <summary>
        /// Validate the elements of the group. If they are all correct, enable the next group.
        /// </summary>
        private void grp_photos_Validate()
        {
            if (nbSelectedPics > 0)
            {
                grp_options.Enabled = true;
                grp_options_Validate();
            }
            else
            {
                grp_options.Enabled = false;
                grp_to.Enabled = false;
                btn_import.Enabled = false;
            }
        }

        /// <summary>
        /// Validate the elements of the group. If they are all correct, enable the next group.
        /// </summary>
        private void grp_options_Validate()
        {
            bool valid = true;
            // tbx_subdirectoryPattern
            valid &= cbx_createSubdirectory.Checked ? ComputePath(tbx_subdirectoryPattern.Text).IndexOfAny(Path.GetInvalidPathChars()) == -1 && tbx_subdirectoryPattern.Text.LastIndexOfAny(new char[]{ ':', '/'}) == -1 : true;
            bool b = Uri.IsWellFormedUriString(ComputePath(tbx_subdirectoryPattern.Text).Replace('\\', '/'), UriKind.Relative);
            // tbx_filenamePattern
            valid &= ComputeFilename(tbx_filenamePattern.Text).IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
            // tbx_tag
            valid &= tbx_tag.Text.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;

            if (valid)
            {
                grp_to.Enabled = true;
                grp_to_Validate();
            }
            else
            {
                grp_to.Enabled = false;
                btn_import.Enabled = false;
            }
        }

        /// <summary>
        /// Replace parameters in the subdirectory pattern with their values.
        /// </summary>
        /// <param name="pPath">The subdirectory pattern.</param>
        /// <param name="pDate">The date to use.</param>
        /// <param name="pTime">The time to use.</param>
        /// <param name="pNum">The sequence number to use.</param>
        /// <param name="pTag">The tag to use.</param>
        /// <returns>The path with the parameters replaced by their values.</returns>
        private string ComputePath(string pPath, string pDate = "9999-12-31", string pTime = "23.59", string pNum = "0", string pTag = "tag")
        {
            return pPath.Replace("$(DATE)", pDate).Replace("$(TIME)", pTime).Replace("$(#)", pNum).Replace("$(TAG)", pTag);
        }

        /// <summary>
        /// Replaces parameters in the filename pattern with their values.
        /// </summary>
        /// <param name="pFilename">The filename pattern.</param>
        /// <param name="pDate">The date to use.</param>
        /// <param name="pTime">The time to use.</param>
        /// <param name="pNum">The sequence number to use.</param>
        /// <param name="pTag">The tag to use.</param>
        /// <param name="pExtension">The file extension to use.</param>
        /// <returns>The filename with the parameters replaced by their values.</returns>
        private string ComputeFilename(string pFilename, string pDate = "9999-12-31", string pTime = "23.59", string pNum = "0", string pTag = "tag", string pName = "filename", string pExtension = "raw")
        {
            return ComputePath(pFilename, pDate, pTime, pNum, pTag).Replace("$(NAME)", pName).Replace("$(EXT)", pExtension);
        }

        /// <summary>
        /// Validate the elements of the group. If they are all correct, enable the next group.
        /// </summary>
        private void grp_to_Validate()
        {
            if (Directory.Exists(tbx_pathTo.Text))
            {
                btn_import.Enabled = true;
            }
        }

        /// <summary>
        /// Search if a string contains a camera brand.
        /// </summary>
        /// <param name="pVolumeLabel">The string to search for (a volume label).</param>
        /// <returns>Wether a brand is found or not.</returns>
        private static bool SearchBrand(string pVolumeLabel)
        {
            string[] brands = { "nikon", "canon", "sony", "sigma" };
            foreach (var brand in brands)
            {
                if (pVolumeLabel.ToLower().Contains(brand))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Logs error to the console.
        /// If '--debug' is present, displays a dialog box.
        /// </summary>
        /// <param name="pMessage">The message to display with the exception.</param>
        /// <param name="pExc">The exception which occured.</param>
        public static void LogError(string pMessage, Exception pExc)
        {
            Console.WriteLine(pMessage + "\n" + pExc.Message);
            if (Environment.GetCommandLineArgs().Contains("--debug"))
            {
                MessageBox.Show(pMessage + "\n" + pExc.Message + "\n\n" + pExc.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Pictures background searcher.
        /// </summary>
        private void Bwk_searchPics_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string[] filesExtensions = { ".3fr", ".ari", ".arw", ".srf", ".sr2", ".bay", ".cri", ".crw", ".cr2", ".cr3", ".cap", ".iiq", ".eip", ".dcs", ".dcr", ".drf", ".k25", ".kdc", ".dng", ".erf", ".fff",
                ".mef", ".mdc", ".mos", ".mrw", ".nef", ".nrw", ".orf", ".pef", ".ptx", ".pxn", ".R3D", ".raf", ".raw", ".rw2", ".raw", ".rwl", ".dng", ".rwz", ".srw", ".x3f", "*.jpg", "*.jpeg" };
            List<string> files = filesExtensions.AsParallel().SelectMany(searchPattern => Directory.EnumerateFiles(tbx_pathFrom.Text, searchPattern, cbx_recursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)).ToList();
            foreach (var file in files)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    FileInfo f = new FileInfo(file);
                    if (cbx_excludeJPEG.Checked && (f.Extension == ".jpg" || f.Extension == ".jpeg"))
                    {
                        Pictures.Add(new Picture(f, false));
                    }
                    else
                    {
                        Pictures.Add(new Picture(f, true));
                        ++nbSelectedPics;
                    }
                    ++nbPics;
                    worker.ReportProgress(0);
                }
            }
        }

        private void Bwk_searchPics_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateSearchResults();
        }

        private void Bwk_copyPics_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Bwk_copyPics_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void Bwk_copyPics_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Cbx_excludeJPEG_CheckedChanged(object sender, EventArgs e)
        {
            bool selected = !cbx_excludeJPEG.Checked;
            foreach (Picture picture in Pictures)
            {
                picture.IsSelected = selected;
                if (selected)
                    ++nbSelectedPics;
                else
                    --nbSelectedPics;
            }
            UpdateSearchResults();
        }

        private void Cbx_recursive_CheckedChanged(object sender, EventArgs e)
        {
            // On check/uncheck, (re)start the search.
            StartSearch();
        }

        private void Bwk_searchPics_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogError("An error occured during pictures search:", e.Error);
            }
        }

        private void Tbx_subdirectoryPattern_TextChanged(object sender, EventArgs e)
        {
            grp_options_Validate();
        }

        private void Tbx_filenamePattern_TextChanged(object sender, EventArgs e)
        {
            grp_options_Validate();
        }

        private void Tbx_tag_TextChanged(object sender, EventArgs e)
        {
            grp_options_Validate();
        }

        private void Btn_import_Click(object sender, EventArgs e)
        {
            //TODO Import func
        }

        private void Tbx_pathTo_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(tbx_pathTo.Text))
                btn_import.Enabled = true;
            else
                btn_import.Enabled = false;
        }

        private void Cbx_createSubdirectory_CheckedChanged(object sender, EventArgs e)
        {
            tbx_subdirectoryPattern.Enabled = cbx_createSubdirectory.Checked;
            grp_options_Validate();
        }
    }
}
