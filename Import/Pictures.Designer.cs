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
            this.olv_pics = new BrightIdeasSoftware.ObjectListView();
            this.olvcol_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcol_Image = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcol_directory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bwk_picsLoader = new System.ComponentModel.BackgroundWorker();
            this.pnl_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olv_pics)).BeginInit();
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
            // olv_pics
            // 
            this.olv_pics.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.olv_pics.AllColumns.Add(this.olvcol_name);
            this.olv_pics.AllColumns.Add(this.olvcol_directory);
            this.olv_pics.AllColumns.Add(this.olvcol_Image);
            resources.ApplyResources(this.olv_pics, "olv_pics");
            this.olv_pics.CellEditUseWholeCell = false;
            this.olv_pics.CheckBoxes = true;
            this.olv_pics.CheckedAspectName = "IsSelected";
            this.olv_pics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcol_name,
            this.olvcol_directory,
            this.olvcol_Image});
            this.olv_pics.CopySelectionOnControlC = false;
            this.olv_pics.Cursor = System.Windows.Forms.Cursors.Default;
            this.olv_pics.HideSelection = false;
            this.olv_pics.ItemRenderer = this.imr_item;
            this.olv_pics.LargeImageList = this.imglst_Pics;
            this.olv_pics.Name = "olv_pics";
            this.olv_pics.ShowFilterMenuOnRightClick = false;
            this.olv_pics.ShowHeaderInAllViews = false;
            this.olv_pics.ShowItemCountOnGroups = true;
            this.olv_pics.UseCompatibleStateImageBehavior = false;
            this.olv_pics.View = System.Windows.Forms.View.LargeIcon;
            // 
            // olvcol_name
            // 
            this.olvcol_name.AspectName = "FileInfo.Name";
            this.olvcol_name.AutoCompleteEditor = false;
            this.olvcol_name.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvcol_name.Groupable = false;
            this.olvcol_name.IsEditable = false;
            resources.ApplyResources(this.olvcol_name, "olvcol_name");
            // 
            // olvcol_Image
            // 
            this.olvcol_Image.AspectName = "FileInfo.FullName";
            this.olvcol_Image.AutoCompleteEditor = false;
            this.olvcol_Image.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvcol_Image.Groupable = false;
            this.olvcol_Image.ImageAspectName = "FileInfo.FullName";
            this.olvcol_Image.IsEditable = false;
            this.olvcol_Image.Renderer = this.imr_item;
            resources.ApplyResources(this.olvcol_Image, "olvcol_Image");
            // 
            // olvcol_directory
            // 
            this.olvcol_directory.AspectName = "FileInfo.DirectoryName";
            this.olvcol_directory.AutoCompleteEditor = false;
            this.olvcol_directory.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.olvcol_directory.IsEditable = false;
            this.olvcol_directory.Searchable = false;
            this.olvcol_directory.Sortable = false;
            resources.ApplyResources(this.olvcol_directory, "olvcol_directory");
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
            this.Controls.Add(this.olv_pics);
            this.Controls.Add(this.lbl_nbPics);
            this.Controls.Add(this.lvw_Pics);
            this.Controls.Add(this.pnl_buttons);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Pictures";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Frm_Pictures_Load);
            this.pnl_buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olv_pics)).EndInit();
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
        private BrightIdeasSoftware.ObjectListView olv_pics;
        private BrightIdeasSoftware.OLVColumn olvcol_name;
        private BrightIdeasSoftware.OLVColumn olvcol_Image;
        private BrightIdeasSoftware.OLVColumn olvcol_directory;
        private System.ComponentModel.BackgroundWorker bwk_picsLoader;
    }
}