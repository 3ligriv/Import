using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Import
{
    public partial class frm_Main : Form
    {
        /// <summary>
        /// List of the pictures selected.
        /// Contains FileInfo objects.
        /// </summary>
        public List<FileInfo> Pictures { get; private set; }
        /// <summary>
        /// List of the pictures unselected.
        /// Contains FileInfo objects.
        /// </summary>
        public List<int> SelectedPictures { get; private set; }
        private readonly char[] invalidPathChars;

        public frm_Main()
        {
            InitializeComponent();
            Pictures = new List<FileInfo>();
            SelectedPictures = new List<int>();
            List<char> temp = Path.GetInvalidFileNameChars().ToList();
            temp.Remove('\\');
            invalidPathChars = temp.ToArray();
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
            Pictures.Clear();
            SelectedPictures.Clear();

            bwk_searchPics.RunWorkerAsync();
        }

        /// <summary>
        /// Update the results of the search.
        /// Used by the searching thread.
        /// </summary>
        public void UpdateSearchResults()
        {
            lbl_nbPic.Text = SelectedPictures.Count + "/" + Pictures.Count + " pictures selected.";
            if (Pictures.Count > 0)
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
            if (SelectedPictures.Count > 0)
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
            char[] invalidFilenameChars = Path.GetInvalidFileNameChars();
            // tbx_subdirectoryPattern
            valid &= cbx_createSubdirectory.Checked ? ComputePath(tbx_subdirectoryPattern.Text).IndexOfAny(invalidPathChars) == -1 : true;
            // tbx_filenamePattern
            valid &= ComputeFilename(tbx_filenamePattern.Text).IndexOfAny(invalidFilenameChars) == -1;
            // tbx_tag
            valid &= tbx_tag.Text.IndexOfAny(invalidFilenameChars) == -1;

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
                btn_import.Enabled = true;
            else
                btn_import.Enabled = false;
        }

        /// <summary>
        /// Search if a string contains a camera brand.
        /// </summary>
        /// <param name="pVolumeLabel">The string to search for (a volume label).</param>
        /// <returns>Wether a brand is found or not.</returns>
        private static bool SearchBrand(string pVolumeLabel)
        {
            string[] brands = { "blackmagic design", "visiontek", "aigo", "advert tech", "foscam", "phase one", "thomson", "agfaphoto", "leica", "medion", "minox",
                "praktica", "rollei", "tevion", "traveler", "vageeswari", "canon", "casio", "epson", "fujifilm", "nikon", "olympus", "ricoh", "panasonic", "pentax",
                "sigma", "sony", "samsung", "hasselblad", "memoto", "benq", "genius", "bell & howell", "ge", "gopro", "hp", "kodak", "lytro", "polaroid", "vivitar", };
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
                    if (!cbx_excludeJPEG.Checked && (f.Extension == ".jpg" || f.Extension == ".jpeg"))
                    {
                        // We add the current number of pics in the list because it will be the index of the current pic after Pictures.Add(f);
                        SelectedPictures.Add(Pictures.Count);
                    }
                    Pictures.Add(f);
                    worker.ReportProgress(0);
                }
            }
        }

        private void Bwk_searchPics_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateSearchResults();
        }

        /// <summary>
        /// Retrieve the shooting date and time of a picture.
        /// </summary>
        /// <param name="pRegex">The regex initialized with the ":" string.</param>
        /// <param name="pPath">The full path of the picture.</param>
        /// <returns>A DateTime representing the shooting date and time.</returns>
        private DateTime GetShootingDate(Regex pRegex, string pPath)
        {
            using (FileStream fs = new FileStream(pPath, FileMode.Open, FileAccess.Read))
            using (Image img = Image.FromStream(fs, false, false))
            {
                PropertyItem prop = img.GetPropertyItem(36867);
                string strShootingDate = pRegex.Replace(Encoding.UTF8.GetString(prop.Value), "-", 2);
                return DateTime.Parse(strShootingDate);
            }
        }

        private void Bwk_copyPics_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<FileInfo> picsToCopy = new List<FileInfo>(SelectedPictures.Count);
            Regex r = new Regex(":");
            foreach (var index in SelectedPictures)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                picsToCopy.Add(Pictures[index]);
            }
            float folderSequence = 1;
            float picSequence = 1;
            foreach (var pic in picsToCopy)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                DateTime creation;
                try
                {
                    creation = GetShootingDate(r, pic.FullName);
                }
                catch (Exception exc)
                {
                    LogError("Error while retrieving the shooting date for the following file:\n" + pic.FullName, exc);
                    creation = pic.LastWriteTime;
                }
                string path = Path.Combine(tbx_pathTo.Text, ComputePath(tbx_subdirectoryPattern.Text, creation.ToString("yyyy-MM-dd"), creation.ToString("HH.mm"), folderSequence.ToString(), tbx_tag.Text));
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch (Exception exc)
                    {
                        e.Cancel = true;
                        LogError("Error while creating the following directory:\n" + path, exc);
                        return;
                    }
                    ++folderSequence;
                }
                try
                {
                    pic.CopyTo(Path.Combine(path, ComputeFilename(tbx_filenamePattern.Text, creation.ToString("yyyy-MM-dd"), creation.ToString("HH.mm"), picSequence.ToString(), tbx_tag.Text, pic.Name, pic.Extension)));
                    ++picSequence;
                }
                catch (IOException io)
                {
                    LogError("Error while copying the following file:\n" + pic.FullName + "\nThe file was ignored.", io);
                }
                catch (Exception exc)
                {
                    e.Cancel = true;
                    LogError("Error while copying the following file:\n" + pic.FullName, exc);
                    return;
                }
                int progress = (int)(picSequence / picsToCopy.Count * 100);
                progress = progress > 100 ? 100 : progress;
                worker.ReportProgress(progress);
            }
            e.Result = (int)picSequence;
        }

        private void Bwk_copyPics_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbr_progress.Value = e.ProgressPercentage;
        }

        private void Bwk_copyPics_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                MessageBox.Show("Copying is complete!\n" + (((int)e.Result) - 1) + " file(s) created.", "Copy complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pbr_progress.Value = 0;
                btn_import.Text = "Import";
            }
        }

        private void Cbx_excludeJPEG_CheckedChanged(object sender, EventArgs e)
        {
            StartSearch();
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
            if (bwk_copyPics.IsBusy)
            {
                bwk_copyPics.CancelAsync();
                btn_import.Text = "Import";
                pbr_progress.Value = 0;
            }
            else
            {
                bwk_copyPics.RunWorkerAsync();
                btn_import.Text = "Cancel";
            }
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
