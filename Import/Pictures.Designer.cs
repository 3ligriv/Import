namespace Import
{
    partial class frm_Pictures
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Pictures));
            this.lvw_Pics = new System.Windows.Forms.ListView();
            this.imglst_Pics = new System.Windows.Forms.ImageList(this.components);
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_nbPics = new System.Windows.Forms.Label();
            this.pnl_buttons = new System.Windows.Forms.Panel();
            this.imr_item = new BrightIdeasSoftware.ImageRenderer();
            this.fol_pics = new BrightIdeasSoftware.FastObjectListView();
            this.col_folder = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.col_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.col_pic = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bwk_picsLoader = new System.ComponentModel.BackgroundWorker();
            this.pnl_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fol_pics)).BeginInit();
            this.SuspendLayout();
            // 
            // lvw_Pics
            // 
            this.lvw_Pics.Activation = System.Windows.Forms.ItemActivation.OneClick;
            resources.ApplyResources(this.lvw_Pics, "lvw_Pics");
            this.lvw_Pics.GridLines = true;
            this.lvw_Pics.HideSelection = false;
            this.lvw_Pics.LargeImageList = this.imglst_Pics;
            this.lvw_Pics.Name = "lvw_Pics";
            this.lvw_Pics.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvw_Pics.UseCompatibleStateImageBehavior = false;
            this.lvw_Pics.VirtualMode = true;
            this.lvw_Pics.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.Lvw_Pics_RetrieveVirtualItem);
            // 
            // imglst_Pics
            // 
            this.imglst_Pics.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            resources.ApplyResources(this.imglst_Pics, "imglst_Pics");
            this.imglst_Pics.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn_select
            // 
            resources.ApplyResources(this.btn_select, "btn_select");
            this.btn_select.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_select.Name = "btn_select";
            this.btn_select.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            resources.ApplyResources(this.btn_cancel, "btn_cancel");
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // lbl_nbPics
            // 
            resources.ApplyResources(this.lbl_nbPics, "lbl_nbPics");
            this.lbl_nbPics.Name = "lbl_nbPics";
            // 
            // pnl_buttons
            // 
            resources.ApplyResources(this.pnl_buttons, "pnl_buttons");
            this.pnl_buttons.Controls.Add(this.btn_select);
            this.pnl_buttons.Controls.Add(this.btn_cancel);
            this.pnl_buttons.Name = "pnl_buttons";
            // 
            // imr_item
            // 
            this.imr_item.ImageList = this.imglst_Pics;
            // 
            // fol_pics
            // 
            this.fol_pics.AllColumns.Add(this.col_name);
            this.fol_pics.AllColumns.Add(this.col_pic);
            this.fol_pics.AllColumns.Add(this.col_folder);
            resources.ApplyResources(this.fol_pics, "fol_pics");
            this.fol_pics.CellEditUseWholeCell = false;
            this.fol_pics.CheckBoxes = true;
            this.fol_pics.CheckedAspectName = "IsSelected";
            this.fol_pics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_name,
            this.col_pic});
            this.fol_pics.HideSelection = false;
            this.fol_pics.ItemRenderer = this.imr_item;
            this.fol_pics.LargeImageList = this.imglst_Pics;
            this.fol_pics.Name = "fol_pics";
            this.fol_pics.ShowFilterMenuOnRightClick = false;
            this.fol_pics.ShowHeaderInAllViews = false;
            this.fol_pics.ShowSortIndicators = false;
            this.fol_pics.SortGroupItemsByPrimaryColumn = false;
            this.fol_pics.UseCompatibleStateImageBehavior = false;
            this.fol_pics.View = System.Windows.Forms.View.LargeIcon;
            this.fol_pics.VirtualMode = true;
            // 
            // col_folder
            // 
            this.col_folder.AspectName = "FileInfo.DirectoryName";
            this.col_folder.IsEditable = false;
            this.col_folder.IsVisible = false;
            this.col_folder.Searchable = false;
            this.col_folder.Sortable = false;
            resources.ApplyResources(this.col_folder, "col_folder");
            this.col_folder.UseFiltering = false;
            // 
            // col_name
            // 
            this.col_name.AspectName = "FileInfo.Name";
            this.col_name.Groupable = false;
            this.col_name.ImageAspectName = "FileInfo.FullName";
            this.col_name.IsEditable = false;
            this.col_name.Sortable = false;
            resources.ApplyResources(this.col_name, "col_name");
            this.col_name.UseFiltering = false;
            // 
            // col_pic
            // 
            this.col_pic.AspectName = "FileInfo.FullName";
            this.col_pic.Groupable = false;
            this.col_pic.IsEditable = false;
            this.col_pic.Renderer = this.imr_item;
            this.col_pic.Searchable = false;
            this.col_pic.ShowTextInHeader = false;
            this.col_pic.Sortable = false;
            resources.ApplyResources(this.col_pic, "col_pic");
            this.col_pic.UseFiltering = false;
            // 
            // bwk_picsLoader
            // 
            this.bwk_picsLoader.WorkerReportsProgress = true;
            this.bwk_picsLoader.WorkerSupportsCancellation = true;
            this.bwk_picsLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bwk_picsLoader_DoWork);
            this.bwk_picsLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Bwk_picsLoader_ProgressChanged);
            this.bwk_picsLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bwk_picsLoader_RunWorkerCompleted);
            // 
            // frm_Pictures
            // 
            this.AcceptButton = this.btn_select;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.Controls.Add(this.fol_pics);
            this.Controls.Add(this.lbl_nbPics);
            this.Controls.Add(this.lvw_Pics);
            this.Controls.Add(this.pnl_buttons);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Pictures";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Pictures_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Pictures_Load);
            this.pnl_buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fol_pics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvw_Pics;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ImageList imglst_Pics;
        private System.Windows.Forms.Label lbl_nbPics;
        private System.Windows.Forms.Panel pnl_buttons;
        private BrightIdeasSoftware.ImageRenderer imr_item;
        private BrightIdeasSoftware.FastObjectListView fol_pics;
        private BrightIdeasSoftware.OLVColumn col_folder;
        private BrightIdeasSoftware.OLVColumn col_name;
        private BrightIdeasSoftware.OLVColumn col_pic;
        private System.ComponentModel.BackgroundWorker bwk_picsLoader;
    }
}