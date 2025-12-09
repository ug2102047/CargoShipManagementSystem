namespace CargoShipManagementSystem
{
    partial class DashboardForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCargoManagement = new System.Windows.Forms.Button();
            this.btnShipManagement = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBerthManagement = new System.Windows.Forms.Button();
            this.groupBoxCargoSummary = new System.Windows.Forms.GroupBox();
            this.lblCargoCancelled = new System.Windows.Forms.Label();
            this.lblCargoDelivered = new System.Windows.Forms.Label();
            this.lblCargoInTransit = new System.Windows.Forms.Label();
            this.lblCargoLoaded = new System.Windows.Forms.Label();
            this.lblCargoPending = new System.Windows.Forms.Label();
            this.lblTotalCargo = new System.Windows.Forms.Label();
            this.groupBoxShipSummary = new System.Windows.Forms.GroupBox();
            this.lblShipMaintenance = new System.Windows.Forms.Label();
            this.lblShipInTransit = new System.Windows.Forms.Label();
            this.lblShipDocked = new System.Windows.Forms.Label();
            this.lblTotalShips = new System.Windows.Forms.Label();
            this.groupBoxBerthSummary = new System.Windows.Forms.GroupBox();
            this.lblBerthUnderMaintenance = new System.Windows.Forms.Label();
            this.lblBerthOccupied = new System.Windows.Forms.Label();
            this.lblBerthFree = new System.Windows.Forms.Label();
            this.lblTotalBerths = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxCargoSummary.SuspendLayout();
            this.groupBoxShipSummary.SuspendLayout();
            this.groupBoxBerthSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(30, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(324, 38);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to Dashboard";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(680, 30);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 35);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCargoManagement
            // 
            this.btnCargoManagement.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCargoManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargoManagement.Location = new System.Drawing.Point(3, 3);
            this.btnCargoManagement.Name = "btnCargoManagement";
            this.btnCargoManagement.Size = new System.Drawing.Size(200, 50);
            this.btnCargoManagement.TabIndex = 2;
            this.btnCargoManagement.Text = "Cargo Management";
            this.btnCargoManagement.UseVisualStyleBackColor = false;
            this.btnCargoManagement.Click += new System.EventHandler(this.btnCargoManagement_Click);
            // 
            // btnShipManagement
            // 
            this.btnShipManagement.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnShipManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShipManagement.Location = new System.Drawing.Point(3, 59);
            this.btnShipManagement.Name = "btnShipManagement";
            this.btnShipManagement.Size = new System.Drawing.Size(200, 50);
            this.btnShipManagement.TabIndex = 3;
            this.btnShipManagement.Text = "Ship Management";
            this.btnShipManagement.UseVisualStyleBackColor = false;
            this.btnShipManagement.Click += new System.EventHandler(this.btnShipManagement_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(3, 171);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(200, 50);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "Reports/Invoicing";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCargoManagement);
            this.flowLayoutPanel1.Controls.Add(this.btnShipManagement);
            this.flowLayoutPanel1.Controls.Add(this.btnBerthManagement);
            this.flowLayoutPanel1.Controls.Add(this.btnReports);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(30, 90);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(210, 480);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnBerthManagement
            // 
            this.btnBerthManagement.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBerthManagement.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBerthManagement.Location = new System.Drawing.Point(3, 115);
            this.btnBerthManagement.Name = "btnBerthManagement";
            this.btnBerthManagement.Size = new System.Drawing.Size(200, 50);
            this.btnBerthManagement.TabIndex = 5;
            this.btnBerthManagement.Text = "Berth Management";
            this.btnBerthManagement.UseVisualStyleBackColor = false;
            this.btnBerthManagement.Click += new System.EventHandler(this.btnBerthManagement_Click);
            // 
            // groupBoxCargoSummary
            // 
            this.groupBoxCargoSummary.BackColor = System.Drawing.Color.Violet;
            this.groupBoxCargoSummary.Controls.Add(this.lblCargoCancelled);
            this.groupBoxCargoSummary.Controls.Add(this.lblCargoDelivered);
            this.groupBoxCargoSummary.Controls.Add(this.lblCargoInTransit);
            this.groupBoxCargoSummary.Controls.Add(this.lblCargoLoaded);
            this.groupBoxCargoSummary.Controls.Add(this.lblCargoPending);
            this.groupBoxCargoSummary.Controls.Add(this.lblTotalCargo);
            this.groupBoxCargoSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxCargoSummary.Location = new System.Drawing.Point(260, 93);
            this.groupBoxCargoSummary.Name = "groupBoxCargoSummary";
            this.groupBoxCargoSummary.Size = new System.Drawing.Size(250, 197);
            this.groupBoxCargoSummary.TabIndex = 6;
            this.groupBoxCargoSummary.TabStop = false;
            this.groupBoxCargoSummary.Text = "Cargo Summary";
            // 
            // lblCargoCancelled
            // 
            this.lblCargoCancelled.AutoSize = true;
            this.lblCargoCancelled.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoCancelled.Location = new System.Drawing.Point(20, 160);
            this.lblCargoCancelled.Name = "lblCargoCancelled";
            this.lblCargoCancelled.Size = new System.Drawing.Size(93, 21);
            this.lblCargoCancelled.TabIndex = 5;
            this.lblCargoCancelled.Text = "Cancelled: 0";
            // 
            // lblCargoDelivered
            // 
            this.lblCargoDelivered.AutoSize = true;
            this.lblCargoDelivered.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoDelivered.Location = new System.Drawing.Point(20, 135);
            this.lblCargoDelivered.Name = "lblCargoDelivered";
            this.lblCargoDelivered.Size = new System.Drawing.Size(92, 21);
            this.lblCargoDelivered.TabIndex = 4;
            this.lblCargoDelivered.Text = "Delivered: 0";
            // 
            // lblCargoInTransit
            // 
            this.lblCargoInTransit.AutoSize = true;
            this.lblCargoInTransit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoInTransit.Location = new System.Drawing.Point(20, 110);
            this.lblCargoInTransit.Name = "lblCargoInTransit";
            this.lblCargoInTransit.Size = new System.Drawing.Size(89, 21);
            this.lblCargoInTransit.TabIndex = 3;
            this.lblCargoInTransit.Text = "In Transit: 0";
            // 
            // lblCargoLoaded
            // 
            this.lblCargoLoaded.AutoSize = true;
            this.lblCargoLoaded.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoLoaded.Location = new System.Drawing.Point(20, 85);
            this.lblCargoLoaded.Name = "lblCargoLoaded";
            this.lblCargoLoaded.Size = new System.Drawing.Size(77, 21);
            this.lblCargoLoaded.TabIndex = 2;
            this.lblCargoLoaded.Text = "Loaded: 0";
            // 
            // lblCargoPending
            // 
            this.lblCargoPending.AutoSize = true;
            this.lblCargoPending.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoPending.Location = new System.Drawing.Point(20, 60);
            this.lblCargoPending.Name = "lblCargoPending";
            this.lblCargoPending.Size = new System.Drawing.Size(82, 21);
            this.lblCargoPending.TabIndex = 1;
            this.lblCargoPending.Text = "Pending: 0";
            // 
            // lblTotalCargo
            // 
            this.lblTotalCargo.AutoSize = true;
            this.lblTotalCargo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCargo.Location = new System.Drawing.Point(20, 30);
            this.lblTotalCargo.Name = "lblTotalCargo";
            this.lblTotalCargo.Size = new System.Drawing.Size(114, 21);
            this.lblTotalCargo.TabIndex = 0;
            this.lblTotalCargo.Text = "Total Cargo: 0";
            // 
            // groupBoxShipSummary
            // 
            this.groupBoxShipSummary.BackColor = System.Drawing.Color.Violet;
            this.groupBoxShipSummary.Controls.Add(this.lblShipMaintenance);
            this.groupBoxShipSummary.Controls.Add(this.lblShipInTransit);
            this.groupBoxShipSummary.Controls.Add(this.lblShipDocked);
            this.groupBoxShipSummary.Controls.Add(this.lblTotalShips);
            this.groupBoxShipSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxShipSummary.Location = new System.Drawing.Point(520, 93);
            this.groupBoxShipSummary.Name = "groupBoxShipSummary";
            this.groupBoxShipSummary.Size = new System.Drawing.Size(250, 197);
            this.groupBoxShipSummary.TabIndex = 7;
            this.groupBoxShipSummary.TabStop = false;
            this.groupBoxShipSummary.Text = "Ship Summary";
            // 
            // lblShipMaintenance
            // 
            this.lblShipMaintenance.AutoSize = true;
            this.lblShipMaintenance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipMaintenance.Location = new System.Drawing.Point(20, 110);
            this.lblShipMaintenance.Name = "lblShipMaintenance";
            this.lblShipMaintenance.Size = new System.Drawing.Size(115, 21);
            this.lblShipMaintenance.TabIndex = 3;
            this.lblShipMaintenance.Text = "Maintenance: 0";
            // 
            // lblShipInTransit
            // 
            this.lblShipInTransit.AutoSize = true;
            this.lblShipInTransit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipInTransit.Location = new System.Drawing.Point(20, 85);
            this.lblShipInTransit.Name = "lblShipInTransit";
            this.lblShipInTransit.Size = new System.Drawing.Size(89, 21);
            this.lblShipInTransit.TabIndex = 2;
            this.lblShipInTransit.Text = "In Transit: 0";
            // 
            // lblShipDocked
            // 
            this.lblShipDocked.AutoSize = true;
            this.lblShipDocked.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipDocked.Location = new System.Drawing.Point(20, 60);
            this.lblShipDocked.Name = "lblShipDocked";
            this.lblShipDocked.Size = new System.Drawing.Size(78, 21);
            this.lblShipDocked.TabIndex = 1;
            this.lblShipDocked.Text = "Docked: 0";
            // 
            // lblTotalShips
            // 
            this.lblTotalShips.AutoSize = true;
            this.lblTotalShips.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalShips.Location = new System.Drawing.Point(20, 30);
            this.lblTotalShips.Name = "lblTotalShips";
            this.lblTotalShips.Size = new System.Drawing.Size(110, 21);
            this.lblTotalShips.TabIndex = 0;
            this.lblTotalShips.Text = "Total Ships: 0";
            // 
            // groupBoxBerthSummary
            // 
            this.groupBoxBerthSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupBoxBerthSummary.Controls.Add(this.lblBerthUnderMaintenance);
            this.groupBoxBerthSummary.Controls.Add(this.lblBerthOccupied);
            this.groupBoxBerthSummary.Controls.Add(this.lblBerthFree);
            this.groupBoxBerthSummary.Controls.Add(this.lblTotalBerths);
            this.groupBoxBerthSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBerthSummary.Location = new System.Drawing.Point(260, 310);
            this.groupBoxBerthSummary.Name = "groupBoxBerthSummary";
            this.groupBoxBerthSummary.Size = new System.Drawing.Size(250, 200);
            this.groupBoxBerthSummary.TabIndex = 8;
            this.groupBoxBerthSummary.TabStop = false;
            this.groupBoxBerthSummary.Text = "Berth Summary";
            // 
            // lblBerthUnderMaintenance
            // 
            this.lblBerthUnderMaintenance.AutoSize = true;
            this.lblBerthUnderMaintenance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBerthUnderMaintenance.Location = new System.Drawing.Point(20, 110);
            this.lblBerthUnderMaintenance.Name = "lblBerthUnderMaintenance";
            this.lblBerthUnderMaintenance.Size = new System.Drawing.Size(162, 21);
            this.lblBerthUnderMaintenance.TabIndex = 3;
            this.lblBerthUnderMaintenance.Text = "Under Maintenance: 0";
            // 
            // lblBerthOccupied
            // 
            this.lblBerthOccupied.AutoSize = true;
            this.lblBerthOccupied.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBerthOccupied.Location = new System.Drawing.Point(20, 85);
            this.lblBerthOccupied.Name = "lblBerthOccupied";
            this.lblBerthOccupied.Size = new System.Drawing.Size(91, 21);
            this.lblBerthOccupied.TabIndex = 2;
            this.lblBerthOccupied.Text = "Occupied: 0";
            // 
            // lblBerthFree
            // 
            this.lblBerthFree.AutoSize = true;
            this.lblBerthFree.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBerthFree.Location = new System.Drawing.Point(20, 60);
            this.lblBerthFree.Name = "lblBerthFree";
            this.lblBerthFree.Size = new System.Drawing.Size(56, 21);
            this.lblBerthFree.TabIndex = 1;
            this.lblBerthFree.Text = "Free: 0";
            // 
            // lblTotalBerths
            // 
            this.lblTotalBerths.AutoSize = true;
            this.lblTotalBerths.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBerths.Location = new System.Drawing.Point(20, 30);
            this.lblTotalBerths.Name = "lblTotalBerths";
            this.lblTotalBerths.Size = new System.Drawing.Size(117, 21);
            this.lblTotalBerths.TabIndex = 0;
            this.lblTotalBerths.Text = "Total Berths: 0";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.groupBoxBerthSummary);
            this.Controls.Add(this.groupBoxShipSummary);
            this.Controls.Add(this.groupBoxCargoSummary);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBoxCargoSummary.ResumeLayout(false);
            this.groupBoxCargoSummary.PerformLayout();
            this.groupBoxShipSummary.ResumeLayout(false);
            this.groupBoxShipSummary.PerformLayout();
            this.groupBoxBerthSummary.ResumeLayout(false);
            this.groupBoxBerthSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCargoManagement;
        private System.Windows.Forms.Button btnShipManagement;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnBerthManagement;
        private System.Windows.Forms.GroupBox groupBoxCargoSummary;
        private System.Windows.Forms.Label lblTotalCargo;
        private System.Windows.Forms.Label lblCargoCancelled;
        private System.Windows.Forms.Label lblCargoDelivered;
        private System.Windows.Forms.Label lblCargoInTransit;
        private System.Windows.Forms.Label lblCargoLoaded;
        private System.Windows.Forms.Label lblCargoPending;
        private System.Windows.Forms.GroupBox groupBoxShipSummary;
        private System.Windows.Forms.Label lblTotalShips;
        private System.Windows.Forms.Label lblShipMaintenance;
        private System.Windows.Forms.Label lblShipInTransit;
        private System.Windows.Forms.Label lblShipDocked;
        private System.Windows.Forms.GroupBox groupBoxBerthSummary; // New
        private System.Windows.Forms.Label lblTotalBerths; // New
        private System.Windows.Forms.Label lblBerthUnderMaintenance; // New
        private System.Windows.Forms.Label lblBerthOccupied; // New
        private System.Windows.Forms.Label lblBerthFree; // New
    }
}
