namespace CargoShipManagementSystem
{
    partial class CargoManagementForm
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
            this.dgvCargo = new System.Windows.Forms.DataGridView();
            this.groupBoxCargoActions = new System.Windows.Forms.GroupBox();
            this.cmbCargoStatus = new System.Windows.Forms.ComboBox();
            this.lblCargoStatus = new System.Windows.Forms.Label();
            this.cmbAssignShip = new System.Windows.Forms.ComboBox();
            this.lblAssignShip = new System.Windows.Forms.Label();
            this.btnDeleteCargo = new System.Windows.Forms.Button();
            this.btnUpdateCargo = new System.Windows.Forms.Button();
            this.btnAddCargo = new System.Windows.Forms.Button();
            this.lblCargoDestination = new System.Windows.Forms.Label();
            this.txtCargoOrigin = new System.Windows.Forms.TextBox();
            this.lblCargoOrigin = new System.Windows.Forms.Label();
            this.txtCargoVolume = new System.Windows.Forms.TextBox();
            this.lblCargoVolume = new System.Windows.Forms.Label();
            this.txtCargoWeight = new System.Windows.Forms.TextBox();
            this.lblCargoWeight = new System.Windows.Forms.Label();
            this.txtCargoName = new System.Windows.Forms.TextBox();
            this.lblCargoName = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.txtSearchCargo = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearchCargo = new System.Windows.Forms.Button();
            this.txtCargoDestination = new System.Windows.Forms.TextBox();
            this.lblCargoDescription = new System.Windows.Forms.Label();
            this.txtCargoDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).BeginInit();
            this.groupBoxCargoActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(366, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cargo Management";
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
            // dgvCargo
            // 
            this.dgvCargo.AllowUserToAddRows = false;
            this.dgvCargo.AllowUserToDeleteRows = false;
            this.dgvCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCargo.Location = new System.Drawing.Point(28, 120);
            this.dgvCargo.Name = "dgvCargo";
            this.dgvCargo.ReadOnly = true;
            this.dgvCargo.RowHeadersWidth = 47;
            this.dgvCargo.Size = new System.Drawing.Size(740, 210);
            this.dgvCargo.TabIndex = 2;
            this.dgvCargo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCargo_CellClick);
            // 
            // groupBoxCargoActions
            // 
            this.groupBoxCargoActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCargoActions.Controls.Add(this.cmbCargoStatus);
            this.groupBoxCargoActions.Controls.Add(this.lblCargoStatus);
            this.groupBoxCargoActions.Controls.Add(this.cmbAssignShip);
            this.groupBoxCargoActions.Controls.Add(this.lblAssignShip);
            this.groupBoxCargoActions.Controls.Add(this.btnDeleteCargo);
            this.groupBoxCargoActions.Controls.Add(this.btnUpdateCargo);
            this.groupBoxCargoActions.Controls.Add(this.btnAddCargo);
            this.groupBoxCargoActions.Controls.Add(this.txtCargoDestination);
            this.groupBoxCargoActions.Controls.Add(this.lblCargoDestination);
            this.groupBoxCargoActions.Controls.Add(this.txtCargoOrigin);
            this.groupBoxCargoActions.Controls.Add(this.lblCargoOrigin);
            this.groupBoxCargoActions.Controls.Add(this.txtCargoVolume);
            this.groupBoxCargoActions.Controls.Add(this.lblCargoVolume);
            this.groupBoxCargoActions.Controls.Add(this.txtCargoWeight);
            this.groupBoxCargoActions.Controls.Add(this.lblCargoWeight);
            this.groupBoxCargoActions.Controls.Add(this.txtCargoDescription);
            this.groupBoxCargoActions.Controls.Add(this.lblCargoDescription);
            this.groupBoxCargoActions.Controls.Add(this.txtCargoName);
            this.groupBoxCargoActions.Controls.Add(this.lblCargoName);
            this.groupBoxCargoActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCargoActions.Location = new System.Drawing.Point(28, 350);
            this.groupBoxCargoActions.Name = "groupBoxCargoActions";
            this.groupBoxCargoActions.Size = new System.Drawing.Size(740, 230);
            this.groupBoxCargoActions.TabIndex = 3;
            this.groupBoxCargoActions.TabStop = false;
            this.groupBoxCargoActions.Text = "Cargo Actions";
            // 
            // cmbCargoStatus
            // 
            this.cmbCargoStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCargoStatus.FormattingEnabled = true;
            this.cmbCargoStatus.Location = new System.Drawing.Point(490, 137);
            this.cmbCargoStatus.Name = "cmbCargoStatus";
            this.cmbCargoStatus.Size = new System.Drawing.Size(200, 28);
            this.cmbCargoStatus.TabIndex = 16;
            this.cmbCargoStatus.SelectedIndexChanged += new System.EventHandler(this.cmbCargoStatus_SelectedIndexChanged);
            // 
            // lblCargoStatus
            // 
            this.lblCargoStatus.AutoSize = true;
            this.lblCargoStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoStatus.Location = new System.Drawing.Point(400, 137);
            this.lblCargoStatus.Name = "lblCargoStatus";
            this.lblCargoStatus.Size = new System.Drawing.Size(55, 21);
            this.lblCargoStatus.TabIndex = 15;
            this.lblCargoStatus.Text = "Status:";
            // 
            // cmbAssignShip
            // 
            this.cmbAssignShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignShip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAssignShip.FormattingEnabled = true;
            this.cmbAssignShip.Location = new System.Drawing.Point(490, 60);
            this.cmbAssignShip.Name = "cmbAssignShip";
            this.cmbAssignShip.Size = new System.Drawing.Size(200, 28);
            this.cmbAssignShip.TabIndex = 14;
            // 
            // lblAssignShip
            // 
            this.lblAssignShip.AutoSize = true;
            this.lblAssignShip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignShip.Location = new System.Drawing.Point(400, 63);
            this.lblAssignShip.Name = "lblAssignShip";
            this.lblAssignShip.Size = new System.Drawing.Size(94, 21);
            this.lblAssignShip.TabIndex = 13;
            this.lblAssignShip.Text = "Assign Ship:";
            // 
            // btnDeleteCargo
            // 
            this.btnDeleteCargo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeleteCargo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCargo.Location = new System.Drawing.Point(490, 198);
            this.btnDeleteCargo.Name = "btnDeleteCargo";
            this.btnDeleteCargo.Size = new System.Drawing.Size(140, 40);
            this.btnDeleteCargo.TabIndex = 14;
            this.btnDeleteCargo.Text = "Delete Cargo";
            this.btnDeleteCargo.UseVisualStyleBackColor = false;
            this.btnDeleteCargo.Click += new System.EventHandler(this.btnDeleteCargo_Click);
            // 
            // btnUpdateCargo
            // 
            this.btnUpdateCargo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpdateCargo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCargo.Location = new System.Drawing.Point(326, 199);
            this.btnUpdateCargo.Name = "btnUpdateCargo";
            this.btnUpdateCargo.Size = new System.Drawing.Size(140, 40);
            this.btnUpdateCargo.TabIndex = 13;
            this.btnUpdateCargo.Text = "Update Cargo";
            this.btnUpdateCargo.UseVisualStyleBackColor = false;
            this.btnUpdateCargo.Click += new System.EventHandler(this.btnUpdateCargo_Click);
            // 
            // btnAddCargo
            // 
            this.btnAddCargo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddCargo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCargo.Location = new System.Drawing.Point(151, 199);
            this.btnAddCargo.Name = "btnAddCargo";
            this.btnAddCargo.Size = new System.Drawing.Size(140, 40);
            this.btnAddCargo.TabIndex = 12;
            this.btnAddCargo.Text = "Add Cargo";
            this.btnAddCargo.UseVisualStyleBackColor = false;
            this.btnAddCargo.Click += new System.EventHandler(this.btnAddCargo_Click);
            // 
            // lblCargoDestination
            // 
            this.lblCargoDestination.AutoSize = true;
            this.lblCargoDestination.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoDestination.Location = new System.Drawing.Point(20, 168);
            this.lblCargoDestination.Name = "lblCargoDestination";
            this.lblCargoDestination.Size = new System.Drawing.Size(92, 21);
            this.lblCargoDestination.TabIndex = 10;
            this.lblCargoDestination.Text = "Destination:";
            // 
            // txtCargoOrigin
            // 
            this.txtCargoOrigin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargoOrigin.Location = new System.Drawing.Point(120, 130);
            this.txtCargoOrigin.Name = "txtCargoOrigin";
            this.txtCargoOrigin.Size = new System.Drawing.Size(200, 28);
            this.txtCargoOrigin.TabIndex = 9;
            // 
            // lblCargoOrigin
            // 
            this.lblCargoOrigin.AutoSize = true;
            this.lblCargoOrigin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoOrigin.Location = new System.Drawing.Point(20, 133);
            this.lblCargoOrigin.Name = "lblCargoOrigin";
            this.lblCargoOrigin.Size = new System.Drawing.Size(57, 21);
            this.lblCargoOrigin.TabIndex = 8;
            this.lblCargoOrigin.Text = "Origin:";
            // 
            // txtCargoVolume
            // 
            this.txtCargoVolume.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargoVolume.Location = new System.Drawing.Point(490, 95);
            this.txtCargoVolume.Name = "txtCargoVolume";
            this.txtCargoVolume.Size = new System.Drawing.Size(200, 28);
            this.txtCargoVolume.TabIndex = 7;
            // 
            // lblCargoVolume
            // 
            this.lblCargoVolume.AutoSize = true;
            this.lblCargoVolume.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoVolume.Location = new System.Drawing.Point(400, 98);
            this.lblCargoVolume.Name = "lblCargoVolume";
            this.lblCargoVolume.Size = new System.Drawing.Size(66, 21);
            this.lblCargoVolume.TabIndex = 6;
            this.lblCargoVolume.Text = "Volume:";
            // 
            // txtCargoWeight
            // 
            this.txtCargoWeight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargoWeight.Location = new System.Drawing.Point(120, 95);
            this.txtCargoWeight.Name = "txtCargoWeight";
            this.txtCargoWeight.Size = new System.Drawing.Size(200, 28);
            this.txtCargoWeight.TabIndex = 5;
            // 
            // lblCargoWeight
            // 
            this.lblCargoWeight.AutoSize = true;
            this.lblCargoWeight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoWeight.Location = new System.Drawing.Point(20, 98);
            this.lblCargoWeight.Name = "lblCargoWeight";
            this.lblCargoWeight.Size = new System.Drawing.Size(62, 21);
            this.lblCargoWeight.TabIndex = 4;
            this.lblCargoWeight.Text = "Weight:";
            // 
            // txtCargoName
            // 
            this.txtCargoName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargoName.Location = new System.Drawing.Point(120, 25);
            this.txtCargoName.Name = "txtCargoName";
            this.txtCargoName.Size = new System.Drawing.Size(200, 28);
            this.txtCargoName.TabIndex = 1;
            // 
            // lblCargoName
            // 
            this.lblCargoName.AutoSize = true;
            this.lblCargoName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoName.Location = new System.Drawing.Point(20, 28);
            this.lblCargoName.Name = "lblCargoName";
            this.lblCargoName.Size = new System.Drawing.Size(55, 21);
            this.lblCargoName.TabIndex = 0;
            this.lblCargoName.Text = "Name:";
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
            // txtSearchCargo
            // 
            this.txtSearchCargo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCargo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchCargo.Location = new System.Drawing.Point(120, 85);
            this.txtSearchCargo.Name = "txtSearchCargo";
            this.txtSearchCargo.Size = new System.Drawing.Size(250, 28);
            this.txtSearchCargo.TabIndex = 5;
            this.txtSearchCargo.Text = "Search by Name, Origin, Destination...";
            this.txtSearchCargo.Enter += new System.EventHandler(this.txtSearchCargo_Enter);
            this.txtSearchCargo.Leave += new System.EventHandler(this.txtSearchCargo_Leave);
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
            // btnSearchCargo
            // 
            this.btnSearchCargo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearchCargo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCargo.Location = new System.Drawing.Point(380, 80);
            this.btnSearchCargo.Name = "btnSearchCargo";
            this.btnSearchCargo.Size = new System.Drawing.Size(100, 35);
            this.btnSearchCargo.TabIndex = 6;
            this.btnSearchCargo.Text = "Search";
            this.btnSearchCargo.UseVisualStyleBackColor = false;
            this.btnSearchCargo.Click += new System.EventHandler(this.btnSearchCargo_Click);
            // 
            // txtCargoDestination
            // 
            this.txtCargoDestination.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargoDestination.Location = new System.Drawing.Point(120, 165);
            this.txtCargoDestination.Name = "txtCargoDestination";
            this.txtCargoDestination.Size = new System.Drawing.Size(200, 28);
            this.txtCargoDestination.TabIndex = 11;
            // 
            // lblCargoDescription
            // 
            this.lblCargoDescription.AutoSize = true;
            this.lblCargoDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoDescription.Location = new System.Drawing.Point(20, 63);
            this.lblCargoDescription.Name = "lblCargoDescription";
            this.lblCargoDescription.Size = new System.Drawing.Size(92, 21);
            this.lblCargoDescription.TabIndex = 2;
            this.lblCargoDescription.Text = "Description:";
            // 
            // txtCargoDescription
            // 
            this.txtCargoDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargoDescription.Location = new System.Drawing.Point(120, 60);
            this.txtCargoDescription.Name = "txtCargoDescription";
            this.txtCargoDescription.Size = new System.Drawing.Size(200, 28);
            this.txtCargoDescription.TabIndex = 3;
            // 
            // CargoManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnSearchCargo);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchCargo);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.groupBoxCargoActions);
            this.Controls.Add(this.dgvCargo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Name = "CargoManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargo Management";
            this.Load += new System.EventHandler(this.CargoManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).EndInit();
            this.groupBoxCargoActions.ResumeLayout(false);
            this.groupBoxCargoActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvCargo;
        private System.Windows.Forms.GroupBox groupBoxCargoActions;
        private System.Windows.Forms.TextBox txtCargoName;
        private System.Windows.Forms.Label lblCargoName;
        private System.Windows.Forms.TextBox txtCargoVolume;
        private System.Windows.Forms.Label lblCargoVolume;
        private System.Windows.Forms.TextBox txtCargoWeight;
        private System.Windows.Forms.Label lblCargoWeight;
        private System.Windows.Forms.Label lblCargoDestination;
        private System.Windows.Forms.TextBox txtCargoOrigin;
        private System.Windows.Forms.Label lblCargoOrigin;
        private System.Windows.Forms.Button btnAddCargo;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnDeleteCargo;
        private System.Windows.Forms.Button btnUpdateCargo;
        private System.Windows.Forms.ComboBox cmbAssignShip;
        private System.Windows.Forms.Label lblAssignShip;
        private System.Windows.Forms.Label lblCargoStatus;
        private System.Windows.Forms.ComboBox cmbCargoStatus;
        private System.Windows.Forms.TextBox txtSearchCargo;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearchCargo;
        private System.Windows.Forms.TextBox txtCargoDestination;
        private System.Windows.Forms.TextBox txtCargoDescription;
        private System.Windows.Forms.Label lblCargoDescription;
    }
}
