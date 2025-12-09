namespace CargoShipManagementSystem
{
    partial class BerthManagementForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvBerths = new System.Windows.Forms.DataGridView();
            this.groupBoxBerthActions = new System.Windows.Forms.GroupBox();
            this.cmbBerthStatus = new System.Windows.Forms.ComboBox();
            this.lblBerthStatus = new System.Windows.Forms.Label();
            this.btnDeleteBerth = new System.Windows.Forms.Button();
            this.btnUpdateBerth = new System.Windows.Forms.Button();
            this.btnAddBerth = new System.Windows.Forms.Button();
            this.txtMaxDraft = new System.Windows.Forms.TextBox();
            this.lblMaxDraft = new System.Windows.Forms.Label();
            this.txtMaxLength = new System.Windows.Forms.TextBox();
            this.lblMaxLength = new System.Windows.Forms.Label();
            this.txtBerthName = new System.Windows.Forms.TextBox();
            this.lblBerthName = new System.Windows.Forms.Label();
            this.txtSearchBerth = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearchBerth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBerths)).BeginInit();
            this.groupBoxBerthActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(358, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Berth Management";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(690, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvBerths
            // 
            this.dgvBerths.AllowUserToAddRows = false;
            this.dgvBerths.AllowUserToDeleteRows = false;
            this.dgvBerths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBerths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBerths.Location = new System.Drawing.Point(28, 120);
            this.dgvBerths.Name = "dgvBerths";
            this.dgvBerths.ReadOnly = true;
            this.dgvBerths.RowHeadersWidth = 47;
            this.dgvBerths.Size = new System.Drawing.Size(740, 210);
            this.dgvBerths.TabIndex = 2;
            this.dgvBerths.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBerths_CellClick);
            // 
            // groupBoxBerthActions
            // 
            this.groupBoxBerthActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBerthActions.Controls.Add(this.cmbBerthStatus);
            this.groupBoxBerthActions.Controls.Add(this.lblBerthStatus);
            this.groupBoxBerthActions.Controls.Add(this.btnDeleteBerth);
            this.groupBoxBerthActions.Controls.Add(this.btnUpdateBerth);
            this.groupBoxBerthActions.Controls.Add(this.btnAddBerth);
            this.groupBoxBerthActions.Controls.Add(this.txtMaxDraft);
            this.groupBoxBerthActions.Controls.Add(this.lblMaxDraft);
            this.groupBoxBerthActions.Controls.Add(this.txtMaxLength);
            this.groupBoxBerthActions.Controls.Add(this.lblMaxLength);
            this.groupBoxBerthActions.Controls.Add(this.txtBerthName);
            this.groupBoxBerthActions.Controls.Add(this.lblBerthName);
            this.groupBoxBerthActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBerthActions.Location = new System.Drawing.Point(28, 350);
            this.groupBoxBerthActions.Name = "groupBoxBerthActions";
            this.groupBoxBerthActions.Size = new System.Drawing.Size(740, 230);
            this.groupBoxBerthActions.TabIndex = 3;
            this.groupBoxBerthActions.TabStop = false;
            this.groupBoxBerthActions.Text = "Berth Actions";
            // 
            // cmbBerthStatus
            // 
            this.cmbBerthStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBerthStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBerthStatus.FormattingEnabled = true;
            this.cmbBerthStatus.Location = new System.Drawing.Point(490, 60);
            this.cmbBerthStatus.Name = "cmbBerthStatus";
            this.cmbBerthStatus.Size = new System.Drawing.Size(200, 28);
            this.cmbBerthStatus.TabIndex = 10;
            // 
            // lblBerthStatus
            // 
            this.lblBerthStatus.AutoSize = true;
            this.lblBerthStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBerthStatus.Location = new System.Drawing.Point(400, 63);
            this.lblBerthStatus.Name = "lblBerthStatus";
            this.lblBerthStatus.Size = new System.Drawing.Size(55, 21);
            this.lblBerthStatus.TabIndex = 9;
            this.lblBerthStatus.Text = "Status:";
            // 
            // btnDeleteBerth
            // 
            this.btnDeleteBerth.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeleteBerth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBerth.Location = new System.Drawing.Point(440, 180);
            this.btnDeleteBerth.Name = "btnDeleteBerth";
            this.btnDeleteBerth.Size = new System.Drawing.Size(140, 40);
            this.btnDeleteBerth.TabIndex = 8;
            this.btnDeleteBerth.Text = "Delete Berth";
            this.btnDeleteBerth.UseVisualStyleBackColor = false;
            this.btnDeleteBerth.Click += new System.EventHandler(this.btnDeleteBerth_Click);
            // 
            // btnUpdateBerth
            // 
            this.btnUpdateBerth.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpdateBerth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateBerth.Location = new System.Drawing.Point(290, 180);
            this.btnUpdateBerth.Name = "btnUpdateBerth";
            this.btnUpdateBerth.Size = new System.Drawing.Size(140, 40);
            this.btnUpdateBerth.TabIndex = 7;
            this.btnUpdateBerth.Text = "Update Berth";
            this.btnUpdateBerth.UseVisualStyleBackColor = false;
            this.btnUpdateBerth.Click += new System.EventHandler(this.btnUpdateBerth_Click);
            // 
            // btnAddBerth
            // 
            this.btnAddBerth.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddBerth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBerth.Location = new System.Drawing.Point(140, 180);
            this.btnAddBerth.Name = "btnAddBerth";
            this.btnAddBerth.Size = new System.Drawing.Size(140, 40);
            this.btnAddBerth.TabIndex = 6;
            this.btnAddBerth.Text = "Add Berth";
            this.btnAddBerth.UseVisualStyleBackColor = false;
            this.btnAddBerth.Click += new System.EventHandler(this.btnAddBerth_Click);
            // 
            // txtMaxDraft
            // 
            this.txtMaxDraft.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxDraft.Location = new System.Drawing.Point(120, 130);
            this.txtMaxDraft.Name = "txtMaxDraft";
            this.txtMaxDraft.Size = new System.Drawing.Size(200, 28);
            this.txtMaxDraft.TabIndex = 5;
            // 
            // lblMaxDraft
            // 
            this.lblMaxDraft.AutoSize = true;
            this.lblMaxDraft.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxDraft.Location = new System.Drawing.Point(20, 133);
            this.lblMaxDraft.Name = "lblMaxDraft";
            this.lblMaxDraft.Size = new System.Drawing.Size(81, 21);
            this.lblMaxDraft.TabIndex = 4;
            this.lblMaxDraft.Text = "Max Draft:";
            // 
            // txtMaxLength
            // 
            this.txtMaxLength.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxLength.Location = new System.Drawing.Point(120, 95);
            this.txtMaxLength.Name = "txtMaxLength";
            this.txtMaxLength.Size = new System.Drawing.Size(200, 28);
            this.txtMaxLength.TabIndex = 3;
            // 
            // lblMaxLength
            // 
            this.lblMaxLength.AutoSize = true;
            this.lblMaxLength.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLength.Location = new System.Drawing.Point(20, 98);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(94, 21);
            this.lblMaxLength.TabIndex = 2;
            this.lblMaxLength.Text = "Max Length:";
            // 
            // txtBerthName
            // 
            this.txtBerthName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBerthName.Location = new System.Drawing.Point(120, 60);
            this.txtBerthName.Name = "txtBerthName";
            this.txtBerthName.Size = new System.Drawing.Size(200, 28);
            this.txtBerthName.TabIndex = 1;
            // 
            // lblBerthName
            // 
            this.lblBerthName.AutoSize = true;
            this.lblBerthName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBerthName.Location = new System.Drawing.Point(20, 63);
            this.lblBerthName.Name = "lblBerthName";
            this.lblBerthName.Size = new System.Drawing.Size(55, 21);
            this.lblBerthName.TabIndex = 0;
            this.lblBerthName.Text = "Name:";
            // 
            // txtSearchBerth
            // 
            this.txtSearchBerth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBerth.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchBerth.Location = new System.Drawing.Point(120, 85);
            this.txtSearchBerth.Name = "txtSearchBerth";
            this.txtSearchBerth.Size = new System.Drawing.Size(250, 28);
            this.txtSearchBerth.TabIndex = 5;
            this.txtSearchBerth.Text = "Search by Name...";
            this.txtSearchBerth.Enter += new System.EventHandler(this.txtSearchBerth_Enter);
            this.txtSearchBerth.Leave += new System.EventHandler(this.txtSearchBerth_Leave);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(25, 88);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(60, 21);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search:";
            // 
            // btnSearchBerth
            // 
            this.btnSearchBerth.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearchBerth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBerth.Location = new System.Drawing.Point(380, 80);
            this.btnSearchBerth.Name = "btnSearchBerth";
            this.btnSearchBerth.Size = new System.Drawing.Size(100, 35);
            this.btnSearchBerth.TabIndex = 6;
            this.btnSearchBerth.Text = "Search";
            this.btnSearchBerth.UseVisualStyleBackColor = false;
            this.btnSearchBerth.Click += new System.EventHandler(this.btnSearchBerth_Click);
            // 
            // BerthManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnSearchBerth);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchBerth);
            this.Controls.Add(this.groupBoxBerthActions);
            this.Controls.Add(this.dgvBerths);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Name = "BerthManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Berth Management";
            this.Load += new System.EventHandler(this.BerthManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBerths)).EndInit();
            this.groupBoxBerthActions.ResumeLayout(false);
            this.groupBoxBerthActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvBerths;
        private System.Windows.Forms.GroupBox groupBoxBerthActions;
        private System.Windows.Forms.TextBox txtBerthName;
        private System.Windows.Forms.Label lblBerthName;
        private System.Windows.Forms.TextBox txtMaxLength;
        private System.Windows.Forms.Label lblMaxLength;
        private System.Windows.Forms.TextBox txtMaxDraft;
        private System.Windows.Forms.Label lblMaxDraft;
        private System.Windows.Forms.ComboBox cmbBerthStatus;
        private System.Windows.Forms.Label lblBerthStatus;
        private System.Windows.Forms.Button btnDeleteBerth;
        private System.Windows.Forms.Button btnUpdateBerth;
        private System.Windows.Forms.Button btnAddBerth;
        private System.Windows.Forms.TextBox txtSearchBerth;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearchBerth;
    }
}
