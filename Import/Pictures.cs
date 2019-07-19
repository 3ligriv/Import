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
    public partial class frm_Pictures : Form
    {
        List<FileInfo> Pictures;
        List<int> SelectedPictures;

        public frm_Pictures()
        {
            InitializeComponent();
            Pictures = new List<FileInfo>();
            SelectedPictures = new List<int>();
        }

        private void Frm_Pictures_Load(object sender, EventArgs e)
        {
            Pictures = ((frm_Main)Owner).Pictures;
            lvw_Pics.VirtualListSize = Pictures.Count;
            SelectedPictures = ((frm_Main)Owner).SelectedPictures;
            lbl_nbPics.Text = SelectedPictures.Count + "/" + Pictures.Count + " pictures selected";
            //foreach (var index in t)
            //    lvw_Pics.SelectedIndices.Add(index);
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
            FileInfo pic = Pictures[e.ItemIndex];

            if (imglst_Pics.Images.Count == e.ItemIndex)
            {
                Image imgSrc = Image.FromFile(pic.FullName);
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
                imglst_Pics.Images.Add(pic.FullName, thumbnail);
            }
            if (SelectedPictures.Contains(e.ItemIndex))
                lvw_Pics.SelectedIndices.Add(e.ItemIndex);
            e.Item = new ListViewItem(pic.Name)
            {
                ImageIndex = e.ItemIndex
            };
        }

        private void Lvw_Pics_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //foreach (var pic in pictures)
            //    pic.IsSelected = false;
            //foreach (int item in lvw_Pics.SelectedIndices)
            //{
            //    pictures[item].IsSelected = true;
            //}
            //pictures[e.ItemIndex].IsSelected = !pictures[e.ItemIndex].IsSelected;
        }
    }
}
