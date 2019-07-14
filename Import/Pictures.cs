using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Import
{
    public partial class frm_Pictures : Form
    {
        public frm_Pictures()
        {
            InitializeComponent();
        }

        private void Frm_Pictures_Load(object sender, EventArgs e)
        {
            bwk_populateListView.RunWorkerAsync();
            lvw_Pics.VirtualMode = false;
            lvw_Pics.VirtualListSize = ((frm_Main)Owner).Pictures.Count();
        }

        private void Bwk_populateListView_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<IGrouping<string, Picture>> groups = ((frm_Main)Owner).Pictures.GroupBy(p => p.FileInfo.DirectoryName).ToList();
            bool dobreak = false;
            foreach (IGrouping<string, Picture> group in groups)
            {
                ListViewGroup listViewGroup = new ListViewGroup(group.Key);
                foreach (Picture picture in group)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        dobreak = true;
                        break;
                    }
                    else
                    {
                        worker.ReportProgress(0, new Tuple<Picture, ListViewGroup>(picture, listViewGroup));
                        //imglst_Pics.Images.Add(picture.FileInfo.FullName, Bitmap.FromFile(picture.FileInfo.FullName));
                        //ListViewItem lvi = new ListViewItem(picture.FileInfo.Name)
                        //{
                        //    Checked = picture.IsSelected,
                        //    Group = listViewGroup,
                        //    ImageKey = picture.FileInfo.FullName
                        //};
                        //worker.ReportProgress(0, lvi);
                    }
                }

                if (dobreak)
                    break;
                //lvw_Pics.BeginUpdate();
                //lvw_Pics.Groups.Add(listViewGroup);
                //lvw_Pics.EndUpdate();
            }
        }

        private void Bwk_populateListView_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lvw_Pics.BeginUpdate();
            Tuple<Picture, ListViewGroup> picture = (Tuple<Picture, ListViewGroup>)e.UserState;
            imglst_Pics.Images.Add(picture.Item1.FileInfo.FullName, Bitmap.FromFile(picture.Item1.FileInfo.FullName));
            ListViewItem lvi = new ListViewItem(picture.Item1.FileInfo.Name)
            {
                Checked = picture.Item1.IsSelected,
                Group = picture.Item2,
                ImageKey = picture.Item1.FileInfo.FullName
            };
            if (!lvw_Pics.Groups.Contains(picture.Item2))
                lvw_Pics.Groups.Add(picture.Item2);
            lvw_Pics.Items.Add(lvi);
            lvw_Pics.EndUpdate();
        }

        private void Bwk_populateListView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Frm_Pictures_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bwk_populateListView.IsBusy)
                bwk_populateListView.CancelAsync();
        }

        private void Lvw_Pics_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            List<Picture> pics = ((frm_Main)Owner).Pictures;
            Picture pic = pics[e.ItemIndex];

            imglst_Pics.Images.Add(pic.FileInfo.FullName, Bitmap.FromFile(pic.FileInfo.FullName));
            e.Item = new ListViewItem(pic.FileInfo.Name)
            {
                Checked = pic.IsSelected,
                Group = new ListViewGroup(pic.FileInfo.DirectoryName),
                ImageKey = pic.FileInfo.FullName
            };
        }
    }
}
