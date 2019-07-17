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
            this.pnl_buttons.SuspendLayout();
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
            this.lvw_Pics.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.Lvw_Pics_ItemSelectionChanged);
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
            // frm_Pictures
            // 
            this.AcceptButton = this.btn_select;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
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
    }
}