using System;

namespace Import
{
    partial class frm_Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.tip_filenamePattern = new System.Windows.Forms.ToolTip(this.components);
            this.tbx_filenamePattern = new System.Windows.Forms.TextBox();
            this.tbx_subdirectoryPattern = new System.Windows.Forms.TextBox();
            this.tbx_tag = new System.Windows.Forms.TextBox();
            this.btn_selectPics = new System.Windows.Forms.Button();
            this.fbd_pathFrom = new System.Windows.Forms.FolderBrowserDialog();
            this.lbl_nbPic = new System.Windows.Forms.Label();
            this.grp_photos = new System.Windows.Forms.GroupBox();
            this.btn_editMetadata = new System.Windows.Forms.Button();
            this.cbx_excludeJPEG = new System.Windows.Forms.CheckBox();
            this.lbl_filenamePattern = new System.Windows.Forms.Label();
            this.lbl_subdirectoryPattern = new System.Windows.Forms.Label();
            this.cbx_createSubdirectory = new System.Windows.Forms.CheckBox();
            this.grp_options = new System.Windows.Forms.GroupBox();
            this.lbl_tag = new System.Windows.Forms.Label();
            this.btn_import = new System.Windows.Forms.Button();
            this.lbl_pathTo = new System.Windows.Forms.Label();
            this.tbx_pathTo = new System.Windows.Forms.TextBox();
            this.btn_pathTo = new System.Windows.Forms.Button();
            this.grp_to = new System.Windows.Forms.GroupBox();
            this.pbr_progress = new System.Windows.Forms.ProgressBar();
            this.lbl_pathFrom = new System.Windows.Forms.Label();
            this.grp_from = new System.Windows.Forms.GroupBox();
            this.tbx_pathFrom = new System.Windows.Forms.TextBox();
            this.cbx_recursive = new System.Windows.Forms.CheckBox();
            this.btn_pathFrom = new System.Windows.Forms.Button();
            this.fbd_pathTo = new System.Windows.Forms.FolderBrowserDialog();
            this.tip_subdirectoryPattern = new System.Windows.Forms.ToolTip(this.components);
            this.bwk_searchPics = new System.ComponentModel.BackgroundWorker();
            this.bwk_copyPics = new System.ComponentModel.BackgroundWorker();
            this.grp_photos.SuspendLayout();
            this.grp_options.SuspendLayout();
            this.grp_to.SuspendLayout();
            this.grp_from.SuspendLayout();
            this.SuspendLayout();
            // 
            // tip_filenamePattern
            // 
            this.tip_filenamePattern.AutomaticDelay = 100;
            this.tip_filenamePattern.AutoPopDelay = 10000;
            this.tip_filenamePattern.InitialDelay = 100;
            this.tip_filenamePattern.ReshowDelay = 20;
            this.tip_filenamePattern.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tip_filenamePattern.ToolTipTitle = "Pattern fields";
            // 
            // tbx_filenamePattern
            // 
            resources.ApplyResources(this.tbx_filenamePattern, "tbx_filenamePattern");
            this.tbx_filenamePattern.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbx_filenamePattern.AllowDrop = true;
            this.tbx_filenamePattern.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("tbx_filenamePattern.AutoCompleteCustomSource"),
            resources.GetString("tbx_filenamePattern.AutoCompleteCustomSource1"),
            resources.GetString("tbx_filenamePattern.AutoCompleteCustomSource2"),
            resources.GetString("tbx_filenamePattern.AutoCompleteCustomSource3"),
            resources.GetString("tbx_filenamePattern.AutoCompleteCustomSource4")});
            this.tbx_filenamePattern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbx_filenamePattern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbx_filenamePattern.HideSelection = false;
            this.tbx_filenamePattern.Name = "tbx_filenamePattern";
            this.tip_filenamePattern.SetToolTip(this.tbx_filenamePattern, resources.GetString("tbx_filenamePattern.ToolTip"));
            // 
            // tbx_subdirectoryPattern
            // 
            resources.ApplyResources(this.tbx_subdirectoryPattern, "tbx_subdirectoryPattern");
            this.tbx_subdirectoryPattern.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbx_subdirectoryPattern.AllowDrop = true;
            this.tbx_subdirectoryPattern.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("tbx_subdirectoryPattern.AutoCompleteCustomSource"),
            resources.GetString("tbx_subdirectoryPattern.AutoCompleteCustomSource1"),
            resources.GetString("tbx_subdirectoryPattern.AutoCompleteCustomSource2"),
            resources.GetString("tbx_subdirectoryPattern.AutoCompleteCustomSource3")});
            this.tbx_subdirectoryPattern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbx_subdirectoryPattern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbx_subdirectoryPattern.HideSelection = false;
            this.tbx_subdirectoryPattern.Name = "tbx_subdirectoryPattern";
            this.tip_subdirectoryPattern.SetToolTip(this.tbx_subdirectoryPattern, resources.GetString("tbx_subdirectoryPattern.ToolTip"));
            this.tip_filenamePattern.SetToolTip(this.tbx_subdirectoryPattern, resources.GetString("tbx_subdirectoryPattern.ToolTip1"));
            // 
            // tbx_tag
            // 
            resources.ApplyResources(this.tbx_tag, "tbx_tag");
            this.tbx_tag.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbx_tag.AllowDrop = true;
            this.tbx_tag.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("tbx_tag.AutoCompleteCustomSource"),
            resources.GetString("tbx_tag.AutoCompleteCustomSource1"),
            resources.GetString("tbx_tag.AutoCompleteCustomSource2"),
            resources.GetString("tbx_tag.AutoCompleteCustomSource3"),
            resources.GetString("tbx_tag.AutoCompleteCustomSource4")});
            this.tbx_tag.HideSelection = false;
            this.tbx_tag.Name = "tbx_tag";
            // 
            // btn_selectPics
            // 
            resources.ApplyResources(this.btn_selectPics, "btn_selectPics");
            this.btn_selectPics.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_selectPics.Name = "btn_selectPics";
            this.btn_selectPics.UseVisualStyleBackColor = true;
            this.btn_selectPics.Click += new System.EventHandler(this.Btn_selectPics);
            // 
            // fbd_pathFrom
            // 
            this.fbd_pathFrom.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbd_pathFrom.ShowNewFolderButton = false;
            // 
            // lbl_nbPic
            // 
            resources.ApplyResources(this.lbl_nbPic, "lbl_nbPic");
            this.lbl_nbPic.CausesValidation = false;
            this.lbl_nbPic.Name = "lbl_nbPic";
            // 
            // grp_photos
            // 
            this.grp_photos.CausesValidation = false;
            this.grp_photos.Controls.Add(this.btn_editMetadata);
            this.grp_photos.Controls.Add(this.cbx_excludeJPEG);
            this.grp_photos.Controls.Add(this.btn_selectPics);
            this.grp_photos.Controls.Add(this.lbl_nbPic);
            resources.ApplyResources(this.grp_photos, "grp_photos");
            this.grp_photos.Name = "grp_photos";
            this.grp_photos.TabStop = false;
            // 
            // btn_editMetadata
            // 
            resources.ApplyResources(this.btn_editMetadata, "btn_editMetadata");
            this.btn_editMetadata.Name = "btn_editMetadata";
            this.btn_editMetadata.UseVisualStyleBackColor = true;
            this.btn_editMetadata.Click += new System.EventHandler(this.Btn_editMetadata_Click);
            // 
            // cbx_excludeJPEG
            // 
            resources.ApplyResources(this.cbx_excludeJPEG, "cbx_excludeJPEG");
            this.cbx_excludeJPEG.CausesValidation = false;
            this.cbx_excludeJPEG.Checked = true;
            this.cbx_excludeJPEG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_excludeJPEG.Name = "cbx_excludeJPEG";
            this.cbx_excludeJPEG.UseVisualStyleBackColor = true;
            this.cbx_excludeJPEG.CheckedChanged += new System.EventHandler(this.Cbx_excludeJPEG_CheckedChanged);
            // 
            // lbl_filenamePattern
            // 
            resources.ApplyResources(this.lbl_filenamePattern, "lbl_filenamePattern");
            this.lbl_filenamePattern.CausesValidation = false;
            this.lbl_filenamePattern.Name = "lbl_filenamePattern";
            // 
            // lbl_subdirectoryPattern
            // 
            resources.ApplyResources(this.lbl_subdirectoryPattern, "lbl_subdirectoryPattern");
            this.lbl_subdirectoryPattern.CausesValidation = false;
            this.lbl_subdirectoryPattern.Name = "lbl_subdirectoryPattern";
            // 
            // cbx_createSubdirectory
            // 
            resources.ApplyResources(this.cbx_createSubdirectory, "cbx_createSubdirectory");
            this.cbx_createSubdirectory.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.cbx_createSubdirectory.CausesValidation = false;
            this.cbx_createSubdirectory.Checked = true;
            this.cbx_createSubdirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_createSubdirectory.Name = "cbx_createSubdirectory";
            this.cbx_createSubdirectory.UseVisualStyleBackColor = true;
            // 
            // grp_options
            // 
            this.grp_options.CausesValidation = false;
            this.grp_options.Controls.Add(this.lbl_tag);
            this.grp_options.Controls.Add(this.tbx_tag);
            this.grp_options.Controls.Add(this.lbl_filenamePattern);
            this.grp_options.Controls.Add(this.tbx_filenamePattern);
            this.grp_options.Controls.Add(this.lbl_subdirectoryPattern);
            this.grp_options.Controls.Add(this.tbx_subdirectoryPattern);
            this.grp_options.Controls.Add(this.cbx_createSubdirectory);
            resources.ApplyResources(this.grp_options, "grp_options");
            this.grp_options.Name = "grp_options";
            this.grp_options.TabStop = false;
            // 
            // lbl_tag
            // 
            resources.ApplyResources(this.lbl_tag, "lbl_tag");
            this.lbl_tag.CausesValidation = false;
            this.lbl_tag.Name = "lbl_tag";
            // 
            // btn_import
            // 
            resources.ApplyResources(this.btn_import, "btn_import");
            this.btn_import.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_import.Name = "btn_import";
            this.btn_import.UseVisualStyleBackColor = true;
            // 
            // lbl_pathTo
            // 
            resources.ApplyResources(this.lbl_pathTo, "lbl_pathTo");
            this.lbl_pathTo.CausesValidation = false;
            this.lbl_pathTo.Name = "lbl_pathTo";
            // 
            // tbx_pathTo
            // 
            resources.ApplyResources(this.tbx_pathTo, "tbx_pathTo");
            this.tbx_pathTo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbx_pathTo.AllowDrop = true;
            this.tbx_pathTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbx_pathTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tbx_pathTo.CausesValidation = false;
            this.tbx_pathTo.Name = "tbx_pathTo";
            // 
            // btn_pathTo
            // 
            resources.ApplyResources(this.btn_pathTo, "btn_pathTo");
            this.btn_pathTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_pathTo.Name = "btn_pathTo";
            this.btn_pathTo.UseVisualStyleBackColor = true;
            this.btn_pathTo.Click += new System.EventHandler(this.Btn_pathTo_Click);
            // 
            // grp_to
            // 
            this.grp_to.CausesValidation = false;
            this.grp_to.Controls.Add(this.lbl_pathTo);
            this.grp_to.Controls.Add(this.tbx_pathTo);
            this.grp_to.Controls.Add(this.btn_pathTo);
            resources.ApplyResources(this.grp_to, "grp_to");
            this.grp_to.Name = "grp_to";
            this.grp_to.TabStop = false;
            // 
            // pbr_progress
            // 
            this.pbr_progress.AccessibleRole = System.Windows.Forms.AccessibleRole.ProgressBar;
            resources.ApplyResources(this.pbr_progress, "pbr_progress");
            this.pbr_progress.Name = "pbr_progress";
            // 
            // lbl_pathFrom
            // 
            resources.ApplyResources(this.lbl_pathFrom, "lbl_pathFrom");
            this.lbl_pathFrom.CausesValidation = false;
            this.lbl_pathFrom.Name = "lbl_pathFrom";
            // 
            // grp_from
            // 
            this.grp_from.CausesValidation = false;
            this.grp_from.Controls.Add(this.lbl_pathFrom);
            this.grp_from.Controls.Add(this.tbx_pathFrom);
            this.grp_from.Controls.Add(this.cbx_recursive);
            this.grp_from.Controls.Add(this.btn_pathFrom);
            resources.ApplyResources(this.grp_from, "grp_from");
            this.grp_from.Name = "grp_from";
            this.grp_from.TabStop = false;
            // 
            // tbx_pathFrom
            // 
            resources.ApplyResources(this.tbx_pathFrom, "tbx_pathFrom");
            this.tbx_pathFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbx_pathFrom.AllowDrop = true;
            this.tbx_pathFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbx_pathFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tbx_pathFrom.HideSelection = false;
            this.tbx_pathFrom.Name = "tbx_pathFrom";
            this.tbx_pathFrom.TextChanged += new System.EventHandler(this.Tbx_pathFrom_TextChanged);
            // 
            // cbx_recursive
            // 
            resources.ApplyResources(this.cbx_recursive, "cbx_recursive");
            this.cbx_recursive.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.cbx_recursive.Checked = true;
            this.cbx_recursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_recursive.Name = "cbx_recursive";
            this.cbx_recursive.UseVisualStyleBackColor = true;
            this.cbx_recursive.CheckedChanged += new System.EventHandler(this.Cbx_recursive_CheckedChanged);
            // 
            // btn_pathFrom
            // 
            resources.ApplyResources(this.btn_pathFrom, "btn_pathFrom");
            this.btn_pathFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_pathFrom.Name = "btn_pathFrom";
            this.btn_pathFrom.UseVisualStyleBackColor = true;
            this.btn_pathFrom.Click += new System.EventHandler(this.Btn_pathFrom_Click);
            // 
            // fbd_pathTo
            // 
            resources.ApplyResources(this.fbd_pathTo, "fbd_pathTo");
            // 
            // tip_subdirectoryPattern
            // 
            this.tip_subdirectoryPattern.AutomaticDelay = 100;
            this.tip_subdirectoryPattern.AutoPopDelay = 10000;
            this.tip_subdirectoryPattern.InitialDelay = 100;
            this.tip_subdirectoryPattern.ReshowDelay = 20;
            this.tip_subdirectoryPattern.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tip_subdirectoryPattern.ToolTipTitle = "Pattern fields";
            // 
            // bwk_searchPics
            // 
            this.bwk_searchPics.WorkerReportsProgress = true;
            this.bwk_searchPics.WorkerSupportsCancellation = true;
            this.bwk_searchPics.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bwk_searchPics_DoWork);
            this.bwk_searchPics.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Bwk_searchPics_ProgressChanged);
            this.bwk_searchPics.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bwk_searchPics_RunWorkerCompleted);
            // 
            // bwk_copyPics
            // 
            this.bwk_copyPics.WorkerReportsProgress = true;
            this.bwk_copyPics.WorkerSupportsCancellation = true;
            this.bwk_copyPics.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bwk_copyPics_DoWork);
            this.bwk_copyPics.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Bwk_copyPics_ProgressChanged);
            this.bwk_copyPics.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Bwk_copyPics_RunWorkerCompleted);
            // 
            // frm_Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grp_photos);
            this.Controls.Add(this.grp_options);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.grp_to);
            this.Controls.Add(this.pbr_progress);
            this.Controls.Add(this.grp_from);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.grp_photos.ResumeLayout(false);
            this.grp_photos.PerformLayout();
            this.grp_options.ResumeLayout(false);
            this.grp_options.PerformLayout();
            this.grp_to.ResumeLayout(false);
            this.grp_to.PerformLayout();
            this.grp_from.ResumeLayout(false);
            this.grp_from.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tip_filenamePattern;
        private System.Windows.Forms.Button btn_selectPics;
        private System.Windows.Forms.FolderBrowserDialog fbd_pathFrom;
        private System.Windows.Forms.Label lbl_nbPic;
        private System.Windows.Forms.GroupBox grp_photos;
        private System.Windows.Forms.Label lbl_filenamePattern;
        private System.Windows.Forms.TextBox tbx_filenamePattern;
        private System.Windows.Forms.Label lbl_subdirectoryPattern;
        private System.Windows.Forms.TextBox tbx_subdirectoryPattern;
        private System.Windows.Forms.CheckBox cbx_createSubdirectory;
        private System.Windows.Forms.GroupBox grp_options;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Label lbl_pathTo;
        private System.Windows.Forms.TextBox tbx_pathTo;
        private System.Windows.Forms.Button btn_pathTo;
        private System.Windows.Forms.GroupBox grp_to;
        private System.Windows.Forms.ProgressBar pbr_progress;
        private System.Windows.Forms.Label lbl_pathFrom;
        private System.Windows.Forms.GroupBox grp_from;
        private System.Windows.Forms.TextBox tbx_pathFrom;
        private System.Windows.Forms.CheckBox cbx_recursive;
        private System.Windows.Forms.Button btn_pathFrom;
        private System.Windows.Forms.FolderBrowserDialog fbd_pathTo;
        private System.Windows.Forms.ToolTip tip_subdirectoryPattern;
        private System.Windows.Forms.CheckBox cbx_excludeJPEG;
        private System.Windows.Forms.Button btn_editMetadata;
        private System.Windows.Forms.Label lbl_tag;
        private System.Windows.Forms.TextBox tbx_tag;
        private System.ComponentModel.BackgroundWorker bwk_searchPics;
        private System.ComponentModel.BackgroundWorker bwk_copyPics;
    }
}

