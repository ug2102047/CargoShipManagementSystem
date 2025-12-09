namespace CargoShipManagementSystem
{
    partial class ReportForm
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
            this.lblSelectReport = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.btnGeneratePdf = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.dgvReportPreview = new System.Windows.Forms.DataGridView();
            this.lblFilterShip = new System.Windows.Forms.Label();
            this.cmbFilterShip = new System.Windows.Forms.ComboBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.groupBoxInvoiceGeneration = new System.Windows.Forms.GroupBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.btnGenerateInvoicePdf = new System.Windows.Forms.Button();
            this.btnSelectCargoForInvoice = new System.Windows.Forms.Button();
            this.dgvInvoiceCargoSelection = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportPreview)).BeginInit();
            this.groupBoxInvoiceGeneration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceCargoSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(355, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reports / Invoicing";
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
            // lblSelectReport
            // 
            this.lblSelectReport.AutoSize = true;
            this.lblSelectReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectReport.Location = new System.Drawing.Point(25, 90);
            this.lblSelectReport.Name = "lblSelectReport";
            this.lblSelectReport.Size = new System.Drawing.Size(105, 21);
            this.lblSelectReport.TabIndex = 2;
            this.lblSelectReport.Text = "Select Report:";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "All Cargo Report",
            "All Ships Report",
            "Cargo by Ship Report",
            "Generate Invoice"});
            this.cmbReportType.Location = new System.Drawing.Point(125, 87);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(200, 28);
            this.cmbReportType.TabIndex = 3;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // btnGeneratePdf
            // 
            this.btnGeneratePdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePdf.Location = new System.Drawing.Point(350, 80);
            this.btnGeneratePdf.Name = "btnGeneratePdf";
            this.btnGeneratePdf.Size = new System.Drawing.Size(120, 35);
            this.btnGeneratePdf.TabIndex = 4;
            this.btnGeneratePdf.Text = "Generate PDF";
            this.btnGeneratePdf.UseVisualStyleBackColor = true;
            this.btnGeneratePdf.Click += new System.EventHandler(this.btnGeneratePdf_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.Location = new System.Drawing.Point(480, 80);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(120, 35);
            this.btnPrintReport.TabIndex = 5;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // dgvReportPreview
            // 
            this.dgvReportPreview.AllowUserToAddRows = false;
            this.dgvReportPreview.AllowUserToDeleteRows = false;
            this.dgvReportPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReportPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportPreview.Location = new System.Drawing.Point(28, 180);
            this.dgvReportPreview.Name = "dgvReportPreview";
            this.dgvReportPreview.ReadOnly = true;
            this.dgvReportPreview.RowHeadersWidth = 47;
            this.dgvReportPreview.Size = new System.Drawing.Size(740, 390);
            this.dgvReportPreview.TabIndex = 6;
            // 
            // lblFilterShip
            // 
            this.lblFilterShip.AutoSize = true;
            this.lblFilterShip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterShip.Location = new System.Drawing.Point(25, 130);
            this.lblFilterShip.Name = "lblFilterShip";
            this.lblFilterShip.Size = new System.Drawing.Size(83, 21);
            this.lblFilterShip.TabIndex = 7;
            this.lblFilterShip.Text = "Filter Ship:";
            this.lblFilterShip.Visible = false;
            // 
            // cmbFilterShip
            // 
            this.cmbFilterShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterShip.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterShip.FormattingEnabled = true;
            this.cmbFilterShip.Location = new System.Drawing.Point(125, 127);
            this.cmbFilterShip.Name = "cmbFilterShip";
            this.cmbFilterShip.Size = new System.Drawing.Size(200, 28);
            this.cmbFilterShip.TabIndex = 8;
            this.cmbFilterShip.Visible = false;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilter.Location = new System.Drawing.Point(350, 120);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(120, 35);
            this.btnApplyFilter.TabIndex = 9;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Visible = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // groupBoxInvoiceGeneration
            // 
            this.groupBoxInvoiceGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInvoiceGeneration.Controls.Add(this.lblGrandTotal);
            this.groupBoxInvoiceGeneration.Controls.Add(this.btnGenerateInvoicePdf);
            this.groupBoxInvoiceGeneration.Controls.Add(this.btnSelectCargoForInvoice);
            this.groupBoxInvoiceGeneration.Controls.Add(this.dgvInvoiceCargoSelection);
            this.groupBoxInvoiceGeneration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInvoiceGeneration.Location = new System.Drawing.Point(28, 160);
            this.groupBoxInvoiceGeneration.Name = "groupBoxInvoiceGeneration";
            this.groupBoxInvoiceGeneration.Size = new System.Drawing.Size(740, 410);
            this.groupBoxInvoiceGeneration.TabIndex = 10;
            this.groupBoxInvoiceGeneration.TabStop = false;
            this.groupBoxInvoiceGeneration.Text = "Invoice Generation";
            this.groupBoxInvoiceGeneration.Visible = false;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(437, 382);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(175, 25);
            this.lblGrandTotal.TabIndex = 3;
            this.lblGrandTotal.Text = "Grand Total: $0.00";
            // 
            // btnGenerateInvoicePdf
            // 
            this.btnGenerateInvoicePdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateInvoicePdf.Location = new System.Drawing.Point(200, 30);
            this.btnGenerateInvoicePdf.Name = "btnGenerateInvoicePdf";
            this.btnGenerateInvoicePdf.Size = new System.Drawing.Size(180, 35);
            this.btnGenerateInvoicePdf.TabIndex = 2;
            this.btnGenerateInvoicePdf.Text = "Generate Invoice PDF";
            this.btnGenerateInvoicePdf.UseVisualStyleBackColor = true;
            this.btnGenerateInvoicePdf.Click += new System.EventHandler(this.btnGenerateInvoicePdf_Click);
            // 
            // btnSelectCargoForInvoice
            // 
            this.btnSelectCargoForInvoice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectCargoForInvoice.Location = new System.Drawing.Point(15, 30);
            this.btnSelectCargoForInvoice.Name = "btnSelectCargoForInvoice";
            this.btnSelectCargoForInvoice.Size = new System.Drawing.Size(180, 35);
            this.btnSelectCargoForInvoice.TabIndex = 1;
            this.btnSelectCargoForInvoice.Text = "Select Cargo for Invoice";
            this.btnSelectCargoForInvoice.UseVisualStyleBackColor = true;
            this.btnSelectCargoForInvoice.Click += new System.EventHandler(this.btnSelectCargoForInvoice_Click);
            // 
            // dgvInvoiceCargoSelection
            // 
            this.dgvInvoiceCargoSelection.AllowUserToAddRows = false;
            this.dgvInvoiceCargoSelection.AllowUserToDeleteRows = false;
            this.dgvInvoiceCargoSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoiceCargoSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceCargoSelection.Location = new System.Drawing.Point(15, 80);
            this.dgvInvoiceCargoSelection.Name = "dgvInvoiceCargoSelection";
            this.dgvInvoiceCargoSelection.RowHeadersWidth = 47;
            this.dgvInvoiceCargoSelection.Size = new System.Drawing.Size(710, 280);
            this.dgvInvoiceCargoSelection.TabIndex = 0;
            this.dgvInvoiceCargoSelection.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceCargoSelection_CellEndEdit);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.groupBoxInvoiceGeneration);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.cmbFilterShip);
            this.Controls.Add(this.lblFilterShip);
            this.Controls.Add(this.dgvReportPreview);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.btnGeneratePdf);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblSelectReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports / Invoicing";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportPreview)).EndInit();
            this.groupBoxInvoiceGeneration.ResumeLayout(false);
            this.groupBoxInvoiceGeneration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceCargoSelection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSelectReport;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Button btnGeneratePdf;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DataGridView dgvReportPreview;
        private System.Windows.Forms.Label lblFilterShip;
        private System.Windows.Forms.ComboBox cmbFilterShip;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.GroupBox groupBoxInvoiceGeneration;
        private System.Windows.Forms.Button btnGenerateInvoicePdf;
        private System.Windows.Forms.Button btnSelectCargoForInvoice;
        private System.Windows.Forms.DataGridView dgvInvoiceCargoSelection;
        private System.Windows.Forms.Label lblGrandTotal; // New
    }
}
