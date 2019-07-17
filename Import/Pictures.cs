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
        List<Picture> pictures;

        public frm_Pictures()
        {
            InitializeComponent();
        }

        private void Frm_Pictures_Load(object sender, EventArgs e)
        {
            pictures = ((frm_Main)Owner).Pictures;
            lvw_Pics.VirtualListSize = pictures.Count();
            lbl_nbPics.Text = pictures.Where(p => p.IsSelected).Count() + "/" + pictures.Count + " pictures selected";
            for (int i = 0; i < pictures.Count; i++)
                if (pictures[i].IsSelected)
                    lvw_Pics.SelectedIndices.Add(i);
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
            Picture pic = pictures[e.ItemIndex];

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
            if (pic.IsSelected)
            {
                lvw_Pics.SelectedIndices.Add(e.ItemIndex);
            }
            e.Item = new ListViewItem(pic.FileInfo.Name)
            {
                //Selected = pic.IsSelected,
                Checked = pic.IsSelected,
                //Group = new ListViewGroup(pic.FileInfo.DirectoryName),
                ImageIndex = e.ItemIndex
                //ImageKey = pic.FileInfo.FullName
            };
        }

        private void Lvw_Pics_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            pictures[e.ItemIndex].IsSelected = !pictures[e.ItemIndex].IsSelected;
        }
    }
}
