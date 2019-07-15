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
            List<Picture> pics = ((frm_Main)Owner).Pictures;
            lvw_Pics.VirtualListSize = pics.Count();
            lbl_nbPics.Text = pics.Where(p => p.IsSelected).Count() + "/" + pics.Count + " pictures selected";
            //olv_pics.SetObjects(pics);
            //vol_pics.SetObjects(pics);
            fol_pics.SetObjects(pics);
            //bwk_picsLoader.RunWorkerAsync();
        }

        private RectangleF ScaleRect(RectangleF pSource, RectangleF pDest)
        {
            float srcAspect = pSource.Width / pSource.Height;
            float wid = pDest.Width;
            float hgt = pDest.Height;
            float dstAspect = wid / hgt;

            if (srcAspect > dstAspect)
            {
                // The source is relatively short and wide.
                // Use all of the available width.
                hgt = wid / srcAspect;
            }
            else
            {
                // The source is relatively tall and thin.
                // Use all of the available height.
                wid = hgt * srcAspect;
            }

            // Center it.
            float x = pDest.Left + (pDest.Width - wid) / 2;
            float y = pDest.Top + (pDest.Height - hgt) / 2;
            return new RectangleF(x, y, wid, hgt);
        }

        private void Lvw_Pics_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            List<Picture> pics = ((frm_Main)Owner).Pictures;
            Picture pic = pics[e.ItemIndex];

            if (imglst_Pics.Images.Count == e.ItemIndex)
            {
                Image imgSrc = Image.FromFile(pic.FileInfo.FullName);
                Image thumbnail = new Bitmap(lvw_Pics.LargeImageList.ImageSize.Width, lvw_Pics.LargeImageList.ImageSize.Height);
                using (Graphics gr = Graphics.FromImage(thumbnail))
                {
                    gr.Clear(Color.Transparent);
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

                    RectangleF srcRtl = new RectangleF(0, 0, imgSrc.Width, imgSrc.Height);
                    RectangleF dstRtl = new RectangleF(0, 0, thumbnail.Width, thumbnail.Height);
                    dstRtl = ScaleRect(srcRtl, dstRtl);
                    gr.DrawImage(imgSrc, dstRtl, srcRtl, GraphicsUnit.Pixel);
                }
                imgSrc.Dispose();
                imglst_Pics.Images.Add(pic.FileInfo.FullName, thumbnail);
            }
            e.Item = new ListViewItem(pic.FileInfo.Name)
            {
                Selected = pic.IsSelected,
                //Group = new ListViewGroup(pic.FileInfo.DirectoryName),
                ImageIndex = e.ItemIndex
                //ImageKey = pic.FileInfo.FullName
            };
        }

        private void Bwk_picsLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            List<Picture> pics = ((frm_Main)Owner).Pictures;

            foreach (var pic in pics)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Image imgSrc = Image.FromFile(pic.FileInfo.FullName);
                Image thumbnail = new Bitmap(imglst_Pics.ImageSize.Width, imglst_Pics.ImageSize.Height);
                using (Graphics gr = Graphics.FromImage(thumbnail))
                {
                    gr.Clear(Color.Transparent);
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

                    RectangleF srcRtl = new RectangleF(0, 0, imgSrc.Width, imgSrc.Height);
                    RectangleF dstRtl = new RectangleF(0, 0, thumbnail.Width, thumbnail.Height);
                    dstRtl = ScaleRect(srcRtl, dstRtl);
                    gr.DrawImage(imgSrc, dstRtl, srcRtl, GraphicsUnit.Pixel);
                }
                imgSrc.Dispose();
                worker.ReportProgress(0, new Tuple<string, Image>(pic.FileInfo.FullName, thumbnail));
            }
        }

        private void Bwk_picsLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Tuple<string, Image> pic = (Tuple<string, Image>)e.UserState;
            imglst_Pics.Images.Add(pic.Item1, pic.Item2);
        }

        private void Bwk_picsLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Frm_Pictures_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bwk_picsLoader.IsBusy)
                bwk_picsLoader.CancelAsync();
        }
    }
}
