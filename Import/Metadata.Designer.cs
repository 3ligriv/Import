namespace Import
{
    partial class frm_Metadata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Metadata));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.pnl_buttons = new System.Windows.Forms.Panel();
            this.dgv_metadata = new System.Windows.Forms.DataGridView();
            this.col_select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_metadata)).BeginInit();
            this.SuspendLayout();
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
            // pnl_buttons
            // 
            resources.ApplyResources(this.pnl_buttons, "pnl_buttons");
            this.pnl_buttons.Controls.Add(this.btn_select);
            this.pnl_buttons.Controls.Add(this.btn_cancel);
            this.pnl_buttons.Name = "pnl_buttons";
            // 
            // dgv_metadata
            // 
            this.dgv_metadata.AllowUserToAddRows = false;
            this.dgv_metadata.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_metadata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgv_metadata, "dgv_metadata");
            this.dgv_metadata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_metadata.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv_metadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_metadata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_select,
            this.col_name,
            this.col_value});
            this.dgv_metadata.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgv_metadata.MultiSelect = false;
            this.dgv_metadata.Name = "dgv_metadata";
            this.dgv_metadata.RowHeadersVisible = false;
            this.dgv_metadata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // col_select
            // 
            this.col_select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.col_select, "col_select");
            this.col_select.Name = "col_select";
            // 
            // col_name
            // 
            this.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.col_name, "col_name");
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_value
            // 
            this.col_value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.col_value, "col_value");
            this.col_value.Name = "col_value";
            // 
            // frm_Metadata
            // 
            this.AcceptButton = this.btn_select;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.Controls.Add(this.dgv_metadata);
            this.Controls.Add(this.pnl_buttons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Metadata";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.pnl_buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_metadata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel pnl_buttons;
        private System.Windows.Forms.DataGridView dgv_metadata;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_value;
    }
}