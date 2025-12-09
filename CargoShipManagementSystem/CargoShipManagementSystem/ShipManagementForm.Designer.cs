namespace CargoShipManagementSystem
{
    partial class ShipManagementForm
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
            this.dgvShips = new System.Windows.Forms.DataGridView();
            this.groupBoxShipActions = new System.Windows.Forms.GroupBox();
            this.txtShipDraft = new System.Windows.Forms.TextBox();
            this.lblShipDraft = new System.Windows.Forms.Label();
            this.txtShipLength = new System.Windows.Forms.TextBox();
            this.lblShipLength = new System.Windows.Forms.Label();
            this.cmbAssignBerth = new System.Windows.Forms.ComboBox();
            this.lblAssignBerth = new System.Windows.Forms.Label();
            this.cmbShipStatus = new System.Windows.Forms.ComboBox();
            this.lblShipStatus = new System.Windows.Forms.Label();
            this.btnDeleteShip = new System.Windows.Forms.Button();
            this.btnUpdateShip = new System.Windows.Forms.Button();
            this.btnAddShip = new System.Windows.Forms.Button();
            this.txtShipCurrentLocation = new System.Windows.Forms.TextBox();
            this.lblShipCurrentLocation = new System.Windows.Forms.Label();
            this.txtShipCapacityVolume = new System.Windows.Forms.TextBox();
            this.lblShipCapacityVolume = new System.Windows.Forms.Label();
            this.txtShipCapacityWeight = new System.Windows.Forms.TextBox();
            this.lblShipCapacityWeight = new System.Windows.Forms.Label();
            this.txtShipCallSign = new System.Windows.Forms.TextBox();
            this.lblShipCallSign = new System.Windows.Forms.Label();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.lblShipName = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.txtSearchShip = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearchShip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShips)).BeginInit();
            this.groupBoxShipActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ship Management";
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
            // dgvShips
            // 
            this.dgvShips.AllowUserToAddRows = false;
            this.dgvShips.AllowUserToDeleteRows = false;
            this.dgvShips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShips.Location = new System.Drawing.Point(28, 120);
            this.dgvShips.Name = "dgvShips";
            this.dgvShips.ReadOnly = true;
            this.dgvShips.RowHeadersWidth = 47;
            this.dgvShips.Size = new System.Drawing.Size(740, 210);
            this.dgvShips.TabIndex = 2;
            this.dgvShips.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShips_CellClick);
            // 
            // groupBoxShipActions
            // 
            this.groupBoxShipActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxShipActions.Controls.Add(this.txtShipDraft);
            this.groupBoxShipActions.Controls.Add(this.lblShipDraft);
            this.groupBoxShipActions.Controls.Add(this.txtShipLength);
            this.groupBoxShipActions.Controls.Add(this.lblShipLength);
            this.groupBoxShipActions.Controls.Add(this.cmbAssignBerth);
            this.groupBoxShipActions.Controls.Add(this.lblAssignBerth);
            this.groupBoxShipActions.Controls.Add(this.cmbShipStatus);
            this.groupBoxShipActions.Controls.Add(this.lblShipStatus);
            this.groupBoxShipActions.Controls.Add(this.btnDeleteShip);
            this.groupBoxShipActions.Controls.Add(this.btnUpdateShip);
            this.groupBoxShipActions.Controls.Add(this.btnAddShip);
            this.groupBoxShipActions.Controls.Add(this.txtShipCurrentLocation);
            this.groupBoxShipActions.Controls.Add(this.lblShipCurrentLocation);
            this.groupBoxShipActions.Controls.Add(this.txtShipCapacityVolume);
            this.groupBoxShipActions.Controls.Add(this.lblShipCapacityVolume);
            this.groupBoxShipActions.Controls.Add(this.txtShipCapacityWeight);
            this.groupBoxShipActions.Controls.Add(this.lblShipCapacityWeight);
            this.groupBoxShipActions.Controls.Add(this.txtShipCallSign);
            this.groupBoxShipActions.Controls.Add(this.lblShipCallSign);
            this.groupBoxShipActions.Controls.Add(this.txtShipName);
            this.groupBoxShipActions.Controls.Add(this.lblShipName);
            this.groupBoxShipActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxShipActions.Location = new System.Drawing.Point(28, 350);
            this.groupBoxShipActions.Name = "groupBoxShipActions";
            this.groupBoxShipActions.Size = new System.Drawing.Size(740, 230);
            this.groupBoxShipActions.TabIndex = 3;
            this.groupBoxShipActions.TabStop = false;
            this.groupBoxShipActions.Text = "Ship Actions";
            // 
            // txtShipDraft
            // 
            this.txtShipDraft.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipDraft.Location = new System.Drawing.Point(490, 66);
            this.txtShipDraft.Name = "txtShipDraft";
            this.txtShipDraft.Size = new System.Drawing.Size(200, 28);
            this.txtShipDraft.TabIndex = 19;
            this.txtShipDraft.TextChanged += new System.EventHandler(this.txtShipDraft_TextChanged);
            // 
            // lblShipDraft
            // 
            this.lblShipDraft.AutoSize = true;
            this.lblShipDraft.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipDraft.Location = new System.Drawing.Point(400, 66);
            this.lblShipDraft.Name = "lblShipDraft";
            this.lblShipDraft.Size = new System.Drawing.Size(48, 21);
            this.lblShipDraft.TabIndex = 18;
            this.lblShipDraft.Text = "Draft:";
            this.lblShipDraft.Click += new System.EventHandler(this.lblShipDraft_Click);
            // 
            // txtShipLength
            // 
            this.txtShipLength.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipLength.Location = new System.Drawing.Point(490, 32);
            this.txtShipLength.Name = "txtShipLength";
            this.txtShipLength.Size = new System.Drawing.Size(200, 28);
            this.txtShipLength.TabIndex = 17;
            this.txtShipLength.TextChanged += new System.EventHandler(this.txtShipLength_TextChanged);
            // 
            // lblShipLength
            // 
            this.lblShipLength.AutoSize = true;
            this.lblShipLength.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipLength.Location = new System.Drawing.Point(400, 35);
            this.lblShipLength.Name = "lblShipLength";
            this.lblShipLength.Size = new System.Drawing.Size(61, 21);
            this.lblShipLength.TabIndex = 16;
            this.lblShipLength.Text = "Length:";
            this.lblShipLength.Click += new System.EventHandler(this.lblShipLength_Click);
            // 
            // cmbAssignBerth
            // 
            this.cmbAssignBerth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignBerth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAssignBerth.FormattingEnabled = true;
            this.cmbAssignBerth.Location = new System.Drawing.Point(506, 136);
            this.cmbAssignBerth.Name = "cmbAssignBerth";
            this.cmbAssignBerth.Size = new System.Drawing.Size(200, 28);
            this.cmbAssignBerth.TabIndex = 15;
            // 
            // lblAssignBerth
            // 
            this.lblAssignBerth.AutoSize = true;
            this.lblAssignBerth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignBerth.Location = new System.Drawing.Point(400, 139);
            this.lblAssignBerth.Name = "lblAssignBerth";
            this.lblAssignBerth.Size = new System.Drawing.Size(100, 21);
            this.lblAssignBerth.TabIndex = 14;
            this.lblAssignBerth.Text = "Assign Berth:";
            this.lblAssignBerth.Click += new System.EventHandler(this.lblAssignBerth_Click);
            // 
            // cmbShipStatus
            // 
            this.cmbShipStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShipStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShipStatus.FormattingEnabled = true;
            this.cmbShipStatus.Location = new System.Drawing.Point(490, 102);
            this.cmbShipStatus.Name = "cmbShipStatus";
            this.cmbShipStatus.Size = new System.Drawing.Size(200, 28);
            this.cmbShipStatus.TabIndex = 13;
            // 
            // lblShipStatus
            // 
            this.lblShipStatus.AutoSize = true;
            this.lblShipStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipStatus.Location = new System.Drawing.Point(400, 99);
            this.lblShipStatus.Name = "lblShipStatus";
            this.lblShipStatus.Size = new System.Drawing.Size(55, 21);
            this.lblShipStatus.TabIndex = 12;
            this.lblShipStatus.Text = "Status:";
            this.lblShipStatus.Click += new System.EventHandler(this.lblShipStatus_Click);
            // 
            // btnDeleteShip
            // 
            this.btnDeleteShip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeleteShip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteShip.Location = new System.Drawing.Point(490, 198);
            this.btnDeleteShip.Name = "btnDeleteShip";
            this.btnDeleteShip.Size = new System.Drawing.Size(140, 40);
            this.btnDeleteShip.TabIndex = 12;
            this.btnDeleteShip.Text = "Delete Ship";
            this.btnDeleteShip.UseVisualStyleBackColor = false;
            this.btnDeleteShip.Click += new System.EventHandler(this.btnDeleteShip_Click);
            // 
            // btnUpdateShip
            // 
            this.btnUpdateShip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpdateShip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateShip.Location = new System.Drawing.Point(298, 199);
            this.btnUpdateShip.Name = "btnUpdateShip";
            this.btnUpdateShip.Size = new System.Drawing.Size(140, 40);
            this.btnUpdateShip.TabIndex = 11;
            this.btnUpdateShip.Text = "Update Ship";
            this.btnUpdateShip.UseVisualStyleBackColor = false;
            this.btnUpdateShip.Click += new System.EventHandler(this.btnUpdateShip_Click);
            // 
            // btnAddShip
            // 
            this.btnAddShip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddShip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddShip.Location = new System.Drawing.Point(92, 199);
            this.btnAddShip.Name = "btnAddShip";
            this.btnAddShip.Size = new System.Drawing.Size(140, 40);
            this.btnAddShip.TabIndex = 10;
            this.btnAddShip.Text = "Add Ship";
            this.btnAddShip.UseVisualStyleBackColor = false;
            this.btnAddShip.Click += new System.EventHandler(this.btnAddShip_Click);
            // 
            // txtShipCurrentLocation
            // 
            this.txtShipCurrentLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipCurrentLocation.Location = new System.Drawing.Point(160, 165);
            this.txtShipCurrentLocation.Name = "txtShipCurrentLocation";
            this.txtShipCurrentLocation.Size = new System.Drawing.Size(160, 28);
            this.txtShipCurrentLocation.TabIndex = 9;
            // 
            // lblShipCurrentLocation
            // 
            this.lblShipCurrentLocation.AutoSize = true;
            this.lblShipCurrentLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipCurrentLocation.Location = new System.Drawing.Point(20, 168);
            this.lblShipCurrentLocation.Name = "lblShipCurrentLocation";
            this.lblShipCurrentLocation.Size = new System.Drawing.Size(129, 21);
            this.lblShipCurrentLocation.TabIndex = 8;
            this.lblShipCurrentLocation.Text = "Current Location:";
            // 
            // txtShipCapacityVolume
            // 
            this.txtShipCapacityVolume.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipCapacityVolume.Location = new System.Drawing.Point(160, 130);
            this.txtShipCapacityVolume.Name = "txtShipCapacityVolume";
            this.txtShipCapacityVolume.Size = new System.Drawing.Size(160, 28);
            this.txtShipCapacityVolume.TabIndex = 7;
            // 
            // lblShipCapacityVolume
            // 
            this.lblShipCapacityVolume.AutoSize = true;
            this.lblShipCapacityVolume.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipCapacityVolume.Location = new System.Drawing.Point(20, 133);
            this.lblShipCapacityVolume.Name = "lblShipCapacityVolume";
            this.lblShipCapacityVolume.Size = new System.Drawing.Size(129, 21);
            this.lblShipCapacityVolume.TabIndex = 6;
            this.lblShipCapacityVolume.Text = "Capacity Volume:";
            // 
            // txtShipCapacityWeight
            // 
            this.txtShipCapacityWeight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipCapacityWeight.Location = new System.Drawing.Point(160, 95);
            this.txtShipCapacityWeight.Name = "txtShipCapacityWeight";
            this.txtShipCapacityWeight.Size = new System.Drawing.Size(160, 28);
            this.txtShipCapacityWeight.TabIndex = 5;
            // 
            // lblShipCapacityWeight
            // 
            this.lblShipCapacityWeight.AutoSize = true;
            this.lblShipCapacityWeight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipCapacityWeight.Location = new System.Drawing.Point(20, 98);
            this.lblShipCapacityWeight.Name = "lblShipCapacityWeight";
            this.lblShipCapacityWeight.Size = new System.Drawing.Size(125, 21);
            this.lblShipCapacityWeight.TabIndex = 4;
            this.lblShipCapacityWeight.Text = "Capacity Weight:";
            // 
            // txtShipCallSign
            // 
            this.txtShipCallSign.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipCallSign.Location = new System.Drawing.Point(120, 60);
            this.txtShipCallSign.Name = "txtShipCallSign";
            this.txtShipCallSign.Size = new System.Drawing.Size(200, 28);
            this.txtShipCallSign.TabIndex = 3;
            // 
            // lblShipCallSign
            // 
            this.lblShipCallSign.AutoSize = true;
            this.lblShipCallSign.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipCallSign.Location = new System.Drawing.Point(20, 63);
            this.lblShipCallSign.Name = "lblShipCallSign";
            this.lblShipCallSign.Size = new System.Drawing.Size(74, 21);
            this.lblShipCallSign.TabIndex = 2;
            this.lblShipCallSign.Text = "Call Sign:";
            // 
            // txtShipName
            // 
            this.txtShipName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipName.Location = new System.Drawing.Point(120, 25);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(200, 28);
            this.txtShipName.TabIndex = 1;
            // 
            // lblShipName
            // 
            this.lblShipName.AutoSize = true;
            this.lblShipName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipName.Location = new System.Drawing.Point(20, 28);
            this.lblShipName.Name = "lblShipName";
            this.lblShipName.Size = new System.Drawing.Size(55, 21);
            this.lblShipName.TabIndex = 0;
            this.lblShipName.Text = "Name:";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(520, 20);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(140, 35);
            this.btnGenerateReport.TabIndex = 4;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // txtSearchShip
            // 
            this.txtSearchShip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchShip.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchShip.Location = new System.Drawing.Point(120, 85);
            this.txtSearchShip.Name = "txtSearchShip";
            this.txtSearchShip.Size = new System.Drawing.Size(250, 28);
            this.txtSearchShip.TabIndex = 5;
            this.txtSearchShip.Text = "Search by Name, Call Sign, Location...";
            this.txtSearchShip.Enter += new System.EventHandler(this.txtSearchShip_Enter);
            this.txtSearchShip.Leave += new System.EventHandler(this.txtSearchShip_Leave);
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
            // btnSearchShip
            // 
            this.btnSearchShip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearchShip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchShip.Location = new System.Drawing.Point(380, 80);
            this.btnSearchShip.Name = "btnSearchShip";
            this.btnSearchShip.Size = new System.Drawing.Size(100, 35);
            this.btnSearchShip.TabIndex = 6;
            this.btnSearchShip.Text = "Search";
            this.btnSearchShip.UseVisualStyleBackColor = false;
            this.btnSearchShip.Click += new System.EventHandler(this.btnSearchShip_Click);
            // 
            // ShipManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnSearchShip);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchShip);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.groupBoxShipActions);
            this.Controls.Add(this.dgvShips);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Name = "ShipManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ship Management";
            this.Load += new System.EventHandler(this.ShipManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShips)).EndInit();
            this.groupBoxShipActions.ResumeLayout(false);
            this.groupBoxShipActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvShips;
        private System.Windows.Forms.GroupBox groupBoxShipActions;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.Label lblShipName;
        private System.Windows.Forms.TextBox txtShipCallSign;
        private System.Windows.Forms.Label lblShipCallSign;
        private System.Windows.Forms.TextBox txtShipCapacityVolume;
        private System.Windows.Forms.Label lblShipCapacityVolume;
        private System.Windows.Forms.TextBox txtShipCapacityWeight;
        private System.Windows.Forms.Label lblShipCapacityWeight;
        private System.Windows.Forms.TextBox txtShipCurrentLocation;
        private System.Windows.Forms.Label lblShipCurrentLocation;
        private System.Windows.Forms.Button btnAddShip;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnDeleteShip;
        private System.Windows.Forms.Button btnUpdateShip;
        private System.Windows.Forms.TextBox txtSearchShip;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearchShip;
        private System.Windows.Forms.ComboBox cmbShipStatus;
        private System.Windows.Forms.Label lblShipStatus;
        private System.Windows.Forms.ComboBox cmbAssignBerth;
        private System.Windows.Forms.Label lblAssignBerth;
        private System.Windows.Forms.TextBox txtShipDraft;
        private System.Windows.Forms.Label lblShipDraft;
        private System.Windows.Forms.TextBox txtShipLength;
        private System.Windows.Forms.Label lblShipLength;
    }
}
