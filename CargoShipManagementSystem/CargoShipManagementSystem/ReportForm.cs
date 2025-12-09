using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics; // Required for Process.Start
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;
using System.Linq; // For LINQ operations on DataRows

namespace CargoShipManagementSystem
{
    public partial class ReportForm : Form
    {
        // Connection string loaded from App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["CargoShipDB"].ConnectionString;

        // DataTable to hold cargo selected for invoicing
        private DataTable _invoiceCargoDataTable = new DataTable();

        public ReportForm()
        {
            InitializeComponent();
            InitializeInvoiceCargoDataTable(); // Setup invoice DGV and its DataTable schema
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Set default selected item for the ComboBox
            if (cmbReportType.Items.Count > 0)
            {
                cmbReportType.SelectedIndex = 0; // Select "All Cargo Report" by default
            }

            // Load ships into the filter ComboBox
            LoadShipsIntoFilterComboBox();
            UpdateControlVisibility(); // Set initial visibility for all controls
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to initialize the DataGridView for invoice cargo selection
        private void InitializeInvoiceCargoDataTable()
        {
            // Define columns for the invoice DataGridView's data source
            _invoiceCargoDataTable.Columns.Add("CargoID", typeof(int));
            _invoiceCargoDataTable.Columns.Add("Name", typeof(string));
            _invoiceCargoDataTable.Columns.Add("Description", typeof(string));
            _invoiceCargoDataTable.Columns.Add("Weight", typeof(decimal));
            _invoiceCargoDataTable.Columns.Add("Volume", typeof(decimal));
            _invoiceCargoDataTable.Columns.Add("ShipName", typeof(string)); // To show ship name in invoice DGV
            _invoiceCargoDataTable.Columns.Add("CostPerUnit", typeof(decimal)); // Editable: For invoicing calculation
            _invoiceCargoDataTable.Columns.Add("TotalCost", typeof(decimal)); // Calculated field

            dgvInvoiceCargoSelection.DataSource = _invoiceCargoDataTable;

            // Set column properties for display and editing
            dgvInvoiceCargoSelection.Columns["CargoID"].Visible = false; // Hide CargoID
            dgvInvoiceCargoSelection.Columns["Name"].ReadOnly = true;
            dgvInvoiceCargoSelection.Columns["Description"].ReadOnly = true;
            dgvInvoiceCargoSelection.Columns["Weight"].ReadOnly = true;
            dgvInvoiceCargoSelection.Columns["Volume"].ReadOnly = true;
            dgvInvoiceCargoSelection.Columns["ShipName"].ReadOnly = true;
            dgvInvoiceCargoSelection.Columns["TotalCost"].ReadOnly = true; // Total Cost is calculated

            // Make CostPerUnit editable
            dgvInvoiceCargoSelection.Columns["CostPerUnit"].ReadOnly = false;
            dgvInvoiceCargoSelection.Columns["CostPerUnit"].HeaderText = "Cost/Unit (Weight)";
            dgvInvoiceCargoSelection.Columns["TotalCost"].HeaderText = "Total Cost";
        }

        // Event handler for DataGridView cell edit ending
        private void dgvInvoiceCargoSelection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the edited column is "CostPerUnit"
            if (dgvInvoiceCargoSelection.Columns[e.ColumnIndex].Name == "CostPerUnit")
            {
                if (e.RowIndex >= 0) // Ensure a valid row is edited
                {
                    DataGridViewRow editedRow = dgvInvoiceCargoSelection.Rows[e.RowIndex];
                    decimal costPerUnit;

                    // Try to parse the new value for CostPerUnit
                    if (decimal.TryParse(editedRow.Cells["CostPerUnit"].Value?.ToString(), out costPerUnit))
                    {
                        // Ensure costPerUnit is not negative
                        if (costPerUnit < 0)
                        {
                            MessageBox.Show("Cost per unit cannot be negative. Setting to 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            editedRow.Cells["CostPerUnit"].Value = 0m;
                            costPerUnit = 0m;
                        }

                        // Get Weight from the same row
                        decimal weight = Convert.ToDecimal(editedRow.Cells["Weight"].Value);

                        // Recalculate TotalCost for the row
                        editedRow.Cells["TotalCost"].Value = weight * costPerUnit;

                        // Recalculate the Grand Total for all items
                        CalculateGrandTotal();
                    }
                    else
                    {
                        // If parsing fails, revert to previous value or set to 0
                        MessageBox.Show("Invalid input for Cost/Unit. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Revert to original value (or set to 0 to prevent further errors)
                        editedRow.Cells["CostPerUnit"].Value = 0m; // Or load original from DB if tracking
                        editedRow.Cells["TotalCost"].Value = 0m;
                        CalculateGrandTotal(); // Update total after invalid entry
                    }
                }
            }
        }

        // Method to calculate and display the Grand Total
        private void CalculateGrandTotal()
        {
            decimal grandTotal = 0;
            foreach (DataRow row in _invoiceCargoDataTable.Rows)
            {
                if (row["TotalCost"] != DBNull.Value)
                {
                    grandTotal += Convert.ToDecimal(row["TotalCost"]);
                }
            }
            lblGrandTotal.Text = $"Grand Total: {grandTotal:C2}"; // Format as currency
        }

        // Event handler for Report Type ComboBox selection change
        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlVisibility(); // Update visibility based on selection
            string selectedReportType = cmbReportType.SelectedItem?.ToString();

            // Only load report data if it's not the "Generate Invoice" option
            if (selectedReportType != "Generate Invoice")
            {
                LoadReportData(selectedReportType);
            }
            else
            {
                dgvReportPreview.DataSource = null; // Clear general report preview
                // When switching to Invoice mode, ensure initial grand total is calculated
                CalculateGrandTotal();
            }
        }

        // Method to dynamically show/hide report and invoice controls
        private void UpdateControlVisibility()
        {
            string selectedReportType = cmbReportType.SelectedItem?.ToString();

            bool isReportMode = selectedReportType != "Generate Invoice";
            bool isFilteredCargoReport = selectedReportType == "Cargo by Ship Report";

            // General Report controls
            dgvReportPreview.Visible = isReportMode;
            btnGeneratePdf.Visible = isReportMode;
            btnPrintReport.Visible = isReportMode;

            // Filter controls for Cargo by Ship Report
            lblFilterShip.Visible = isReportMode && isFilteredCargoReport;
            cmbFilterShip.Visible = isReportMode && isFilteredCargoReport;
            btnApplyFilter.Visible = isReportMode && isFilteredCargoReport;

            // Invoice Generation controls
            groupBoxInvoiceGeneration.Visible = !isReportMode;
            if (!isReportMode)
            {
                _invoiceCargoDataTable.Clear(); // Clear previous selections when switching to invoice mode
                CalculateGrandTotal(); // Reset total when switching to invoice mode
            }
        }

        // Method to load ships into the filter ComboBox
        private void LoadShipsIntoFilterComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ShipID, Name FROM Ships ORDER BY Name";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a "All Ships" option for filtering
                    DataRow newRow = dt.NewRow();
                    newRow["ShipID"] = DBNull.Value; // Represents no specific ship filter
                    newRow["Name"] = "-- All Ships --";
                    dt.Rows.InsertAt(newRow, 0);

                    cmbFilterShip.DataSource = dt;
                    cmbFilterShip.DisplayMember = "Name";
                    cmbFilterShip.ValueMember = "ShipID";
                    cmbFilterShip.SelectedValue = DBNull.Value; // Select "All Ships" by default
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading ships for filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading ships for filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        // Method to load data into the DataGridView based on report type and filter
        private void LoadReportData(string reportType)
        {
            DataTable dt = new DataTable();
            string query = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (reportType == "All Cargo Report")
                    {
                        query = @"SELECT
                                    c.CargoID,
                                    c.Name,
                                    c.Description,
                                    c.Weight,
                                    c.Volume,
                                    c.Status,
                                    c.Origin,
                                    c.Destination,
                                    s.Name AS AssignedShip, -- Display Ship Name
                                    c.LastUpdated
                                FROM
                                    Cargo c
                                LEFT JOIN
                                    Ships s ON c.ShipID = s.ShipID";
                    }
                    else if (reportType == "All Ships Report")
                    {
                        query = "SELECT ShipID, Name, CallSign, CapacityWeight, CapacityVolume, CurrentLocation, Status, LastUpdated FROM Ships";
                    }
                    else if (reportType == "Cargo by Ship Report")
                    {
                        query = @"SELECT
                                    c.CargoID,
                                    c.Name,
                                    c.Description,
                                    c.Weight,
                                    c.Volume,
                                    c.Status,
                                    c.Origin,
                                    c.Destination,
                                    s.Name AS AssignedShip,
                                    c.LastUpdated
                                FROM
                                    Cargo c
                                LEFT JOIN
                                    Ships s ON c.ShipID = s.ShipID
                                WHERE 1 = 1";

                        if (cmbFilterShip.SelectedValue != null && cmbFilterShip.SelectedValue != DBNull.Value)
                        {
                            query += " AND c.ShipID = @ShipID";
                        }
                    }
                    else
                    {
                        dgvReportPreview.DataSource = null; // Clear data if no valid report type selected
                        return;
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (reportType == "Cargo by Ship Report" && cmbFilterShip.SelectedValue != null && cmbFilterShip.SelectedValue != DBNull.Value)
                        {
                            command.Parameters.AddWithValue("@ShipID", Convert.ToInt32(cmbFilterShip.SelectedValue));
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                        dgvReportPreview.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading report data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading report data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        // Event handler for Apply Filter button
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem?.ToString() == "Cargo by Ship Report")
            {
                LoadReportData("Cargo by Ship Report");
            }
        }

        // Event handler for Generate PDF (for general reports)
        private void btnGeneratePdf_Click(object sender, EventArgs e)
        {
            if (dgvReportPreview.Rows.Count == 0)
            {
                MessageBox.Show("No data to generate report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string reportType = cmbReportType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(reportType) || reportType == "Generate Invoice")
            {
                MessageBox.Show("Please select a valid report type (not 'Generate Invoice') first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"{reportType.Replace(" ", "")}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

            if (reportType == "Cargo by Ship Report" && cmbFilterShip.SelectedValue != null && cmbFilterShip.SelectedValue != DBNull.Value)
            {
                string shipName = cmbFilterShip.Text;
                saveFileDialog.FileName = $"CargoBy{shipName.Replace(" ", "")}Report_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                GenerateStandardPdfReport(filePath, reportType, dgvReportPreview);
            }
        }

        // Event handler for Print Report (for general reports)
        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (dgvReportPreview.Rows.Count == 0)
            {
                MessageBox.Show("No data to print. Generate a report first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string reportType = cmbReportType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(reportType) || reportType == "Generate Invoice")
            {
                MessageBox.Show("Please select a valid report type (not 'Generate Invoice') first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tempFilePath = Path.Combine(Path.GetTempPath(), $"{reportType.Replace(" ", "")}_PrintPreview_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            if (reportType == "Cargo by Ship Report" && cmbFilterShip.SelectedValue != null && cmbFilterShip.SelectedValue != DBNull.Value)
            {
                string shipName = cmbFilterShip.Text;
                tempFilePath = Path.Combine(Path.GetTempPath(), $"CargoBy{shipName.Replace(" ", "")}Report_PrintPreview_{DateTime.Now:yyyyMMddHHmmss}.pdf");
            }
            GenerateStandardPdfReport(tempFilePath, reportType, dgvReportPreview, true); // True for print mode
        }

        // Helper method to generate a standard PDF report from a DataGridView
        private void GenerateStandardPdfReport(string filePath, string reportType, DataGridView dgv, bool isPrint = false)
        {
            try
            {
                Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                string titleText = $"{reportType} - Generated on {DateTime.Now:dd-MM-yyyy HH:mm}";
                if (reportType == "Cargo by Ship Report" && cmbFilterShip.SelectedValue != null && cmbFilterShip.SelectedValue != DBNull.Value)
                {
                    titleText = $"Cargo Report for Ship: {cmbFilterShip.Text} - Generated on {DateTime.Now:dd-MM-yyyy HH:mm}";
                }
                if (isPrint)
                {
                    titleText = $"Print Preview: {titleText}";
                }

                Paragraph title = new Paragraph(titleText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK));
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 10f;
                doc.Add(title);

                PdfPTable pdfTable = new PdfPTable(dgv.ColumnCount);
                pdfTable.WidthPercentage = 100;
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.DefaultCell.BorderWidth = 1;
                pdfTable.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;

                // Add headers
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.BLACK)));
                    headerCell.BackgroundColor = new BaseColor(240, 240, 240);
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(headerCell);
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(new Phrase(cell.Value?.ToString() ?? "", FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK)));
                    }
                }

                doc.Add(pdfTable);
                doc.Close();

                if (!isPrint)
                {
                    MessageBox.Show($"Report generated successfully at:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(filePath);
                }
                else
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = filePath,
                        Verb = "Print",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    Process printProcess = new Process();
                    printProcess.StartInfo = psi;
                    printProcess.Start();
                    MessageBox.Show($"Attempting to print report from:\n{filePath}\n\nYour system's default PDF viewer will handle the print dialog.", "Print Initiated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating/printing PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("PDF Generation/Print Error: " + ex.Message);
            }
        }


        // Event handler for "Select Cargo for Invoice" button
        private void btnSelectCargoForInvoice_Click(object sender, EventArgs e)
        {
            // Open a new form to allow users to select cargo items
            using (CargoSelectionForm cargoSelectForm = new CargoSelectionForm(connectionString))
            {
                if (cargoSelectForm.ShowDialog() == DialogResult.OK)
                {
                    // Get selected cargo from the selection form
                    List<int> selectedCargoIds = cargoSelectForm.SelectedCargoIds;
                    _invoiceCargoDataTable.Clear(); // Clear previous selections

                    if (selectedCargoIds.Any())
                    {
                        // Fetch full details of selected cargo items and add to _invoiceCargoDataTable
                        LoadSelectedCargoForInvoice(selectedCargoIds);
                    }
                    CalculateGrandTotal(); // Update grand total after loading selected cargo
                }
            }
        }

        // Method to load selected cargo details into the invoice DataGridView
        private void LoadSelectedCargoForInvoice(List<int> cargoIds)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Using IN clause to select multiple cargo items
                    string cargoIdsString = string.Join(",", cargoIds);
                    string query = $@"
                        SELECT
                            c.CargoID,
                            c.Name,
                            c.Description,
                            c.Weight,
                            c.Volume,
                            s.Name AS ShipName -- Get ship name if assigned
                        FROM
                            Cargo c
                        LEFT JOIN
                            Ships s ON c.ShipID = s.ShipID
                        WHERE
                            c.CargoID IN ({cargoIdsString})";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable selectedCargoDt = new DataTable();
                        adapter.Fill(selectedCargoDt);

                        foreach (DataRow row in selectedCargoDt.Rows)
                        {
                            DataRow newRow = _invoiceCargoDataTable.NewRow();
                            newRow["CargoID"] = row["CargoID"];
                            newRow["Name"] = row["Name"];
                            newRow["Description"] = row["Description"];
                            newRow["Weight"] = row["Weight"];
                            newRow["Volume"] = row["Volume"];
                            newRow["ShipName"] = row["ShipName"];
                            // For demo, assign a dummy cost. In a real app, this would be fetched or calculated.
                            newRow["CostPerUnit"] = 100.00m; // Example: $100 per unit of weight
                            // Calculate initial TotalCost
                            newRow["TotalCost"] = Convert.ToDecimal(row["Weight"]) * Convert.ToDecimal(newRow["CostPerUnit"]);
                            _invoiceCargoDataTable.Rows.Add(newRow);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading selected cargo for invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred loading selected cargo for invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }


        // Event handler for "Generate Invoice PDF" button
        private void btnGenerateInvoicePdf_Click(object sender, EventArgs e)
        {
            if (_invoiceCargoDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Please select cargo items for the invoice first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Invoice_{DateTime.Now:yyyyMMddHHmmss}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                GenerateInvoicePdf(filePath);
            }
        }

        // Method to generate the invoice PDF
        private void GenerateInvoicePdf(string filePath)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 50, 50, 50, 50); // A4 portrait for invoice
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Company Header (simplified)
                Paragraph companyName = new Paragraph("CargoShip Management Co.", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.BLACK));
                companyName.Alignment = Element.ALIGN_CENTER;
                doc.Add(companyName);

                Paragraph companyAddress = new Paragraph("123 Ocean Drive, Port City, Bangladesh", FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY));
                companyAddress.Alignment = Element.ALIGN_CENTER;
                companyAddress.SpacingAfter = 20f;
                doc.Add(companyAddress);

                // Invoice Title and Date
                Paragraph invoiceTitle = new Paragraph("INVOICE", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.DARK_GRAY));
                invoiceTitle.Alignment = Element.ALIGN_RIGHT;
                doc.Add(invoiceTitle);

                Paragraph invoiceDate = new Paragraph($"Date: {DateTime.Now:dd-MM-yyyy}", FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK));
                invoiceDate.Alignment = Element.ALIGN_RIGHT;
                invoiceDate.SpacingAfter = 30f;
                doc.Add(invoiceDate);

                // Cargo Items Table
                PdfPTable pdfTable = new PdfPTable(dgvInvoiceCargoSelection.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible)); // Only visible columns
                pdfTable.WidthPercentage = 100;
                // Dynamically set widths for visible columns
                List<float> widths = new List<float>();
                foreach (DataGridViewColumn column in dgvInvoiceCargoSelection.Columns)
                {
                    if (column.Visible)
                    {
                        if (column.Name == "Name") widths.Add(2f);
                        else if (column.Name == "Description") widths.Add(3f);
                        else if (column.Name == "Weight") widths.Add(1f);
                        else if (column.Name == "Volume") widths.Add(1f);
                        else if (column.Name == "ShipName") widths.Add(1.5f);
                        else if (column.Name == "CostPerUnit") widths.Add(1.5f);
                        else if (column.Name == "TotalCost") widths.Add(1.5f);
                        else widths.Add(1f); // Default for other visible columns
                    }
                }
                pdfTable.SetWidths(widths.ToArray());

                pdfTable.DefaultCell.Padding = 5;
                pdfTable.DefaultCell.BorderWidth = 1;
                pdfTable.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
                pdfTable.SpacingBefore = 10f;
                pdfTable.SpacingAfter = 20f;

                // Add headers for visible columns from the DGV
                foreach (DataGridViewColumn column in dgvInvoiceCargoSelection.Columns)
                {
                    if (column.Visible)
                    {
                        PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK)));
                        headerCell.BackgroundColor = new BaseColor(220, 230, 240); // Light blue background
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(headerCell);
                    }
                }

                decimal grandTotal = 0;
                // Add data rows from the _invoiceCargoDataTable (which is the source of dgvInvoiceCargoSelection)
                foreach (DataRow row in _invoiceCargoDataTable.Rows)
                {
                    // Add cell content for each visible column, matching the order of headers
                    foreach (DataGridViewColumn column in dgvInvoiceCargoSelection.Columns)
                    {
                        if (column.Visible)
                        {
                            object cellValue = row[column.Name];
                            string formattedValue = cellValue?.ToString() ?? "";

                            // Special formatting for currency columns
                            if (column.Name == "CostPerUnit" || column.Name == "TotalCost")
                            {
                                if (decimal.TryParse(cellValue?.ToString(), out decimal numericValue))
                                {
                                    formattedValue = numericValue.ToString("C2"); // Currency format
                                }
                            }
                            pdfTable.AddCell(new Phrase(formattedValue, FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK)));
                        }
                    }
                    if (row["TotalCost"] != DBNull.Value)
                    {
                        grandTotal += Convert.ToDecimal(row["TotalCost"]);
                    }
                }

                doc.Add(pdfTable);

                // Add Grand Total
                Paragraph total = new Paragraph($"Grand Total: {grandTotal:C2}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK));
                total.Alignment = Element.ALIGN_RIGHT;
                doc.Add(total);

                doc.Close();

                MessageBox.Show($"Invoice generated successfully at:\n{filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Invoice PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Invoice PDF Generation Error: " + ex.Message);
            }
        }
    }
}
