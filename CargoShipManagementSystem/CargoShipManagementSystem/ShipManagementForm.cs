using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic; // For List

namespace CargoShipManagementSystem
{
    public partial class ShipManagementForm : Form
    {
        // Connection string loaded from App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["CargoShipDB"].ConnectionString;

        private int _selectedShipId = -1; // To store the ShipID of the selected row for Update/Delete
        private const string SearchPlaceholderText = "Search by Name, Call Sign, Location..."; // Placeholder text for search box

        public ShipManagementForm()
        {
            InitializeComponent();
            InitializeSearchBox(); // Initialize the search text box with placeholder
            InitializeShipStatusComboBox(); // Initialize the status combo box
        }

        private void ShipManagementForm_Load(object sender, EventArgs e)
        {
            LoadShipData(); // Load data when the form loads
            LoadBerthsIntoComboBox(); // Load berths into the combo box for assignment
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the current form
        }

        // Method to initialize the search text box with placeholder
        private void InitializeSearchBox()
        {
            txtSearchShip.Text = SearchPlaceholderText;
            txtSearchShip.ForeColor = System.Drawing.SystemColors.GrayText;
        }

        // Event handler for when the search textbox gains focus
        private void txtSearchShip_Enter(object sender, EventArgs e)
        {
            if (txtSearchShip.Text == SearchPlaceholderText)
            {
                txtSearchShip.Text = "";
                txtSearchShip.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        // Event handler for when the search textbox loses focus
        private void txtSearchShip_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchShip.Text))
            {
                txtSearchShip.Text = SearchPlaceholderText;
                txtSearchShip.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        // Event handler for Search button click
        private void btnSearchShip_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchShip.Text.Trim();
            if (searchTerm == SearchPlaceholderText)
            {
                searchTerm = ""; // Treat placeholder as empty search
            }
            LoadShipData(searchTerm); // Load data with the search term
        }

        // Method to initialize the Ship Status ComboBox
        private void InitializeShipStatusComboBox()
        {
            cmbShipStatus.Items.Add("Docked");
            cmbShipStatus.Items.Add("In Transit");
            cmbShipStatus.Items.Add("Maintenance");
            cmbShipStatus.SelectedIndex = 0; // Default to 'Docked'
            cmbShipStatus.DropDownStyle = ComboBoxStyle.DropDownList; // Make it non-editable
        }

        // Method to load berths into the ComboBox for assignment
        private void LoadBerthsIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT BerthID, Name, Status FROM Berths ORDER BY Name";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a default "None" option to allow unassigning from a berth
                    DataRow newRow = dt.NewRow();
                    newRow["BerthID"] = DBNull.Value; // Use DBNull for the NULL foreign key
                    newRow["Name"] = "-- Select Berth --";
                    dt.Rows.InsertAt(newRow, 0);

                    cmbAssignBerth.DataSource = dt;
                    cmbAssignBerth.DisplayMember = "Name"; // Display berth name
                    cmbAssignBerth.ValueMember = "BerthID"; // Use BerthID as the actual value
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading berths for assignment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message); // For debugging
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading berths for assignment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message); // For debugging
            }
        }


        // Method to load ship data into the DataGridView with optional search term
        private void LoadShipData(string searchTerm = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Modified query to join with Berths table and display Berth Name
                    string query = @"
                        SELECT
                            s.ShipID,
                            s.Name,
                            s.CallSign,
                            s.CapacityWeight,
                            s.CapacityVolume,
                            s.Length,       -- Include Length
                            s.Draft,        -- Include Draft
                            s.CurrentLocation,
                            s.Status,
                            b.Name AS AssignedBerth, -- Display Berth Name
                            s.CurrentBerthID,       -- Keep CurrentBerthID for internal logic
                            s.LastUpdated
                        FROM
                            Ships s
                        LEFT JOIN
                            Berths b ON s.CurrentBerthID = b.BerthID
                        WHERE 1=1";

                    // Add search conditions if a search term is provided
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " AND (s.Name LIKE @SearchTerm OR s.CallSign LIKE @SearchTerm OR s.CurrentLocation LIKE @SearchTerm)";
                    }

                    // Order by Name for consistent display
                    query += " ORDER BY s.Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvShips.DataSource = dt; // Set the DataTable as the DataGridView's data source

                        // Optional: Hide the raw CurrentBerthID column if you only want to show AssignedBerth
                        if (dgvShips.Columns.Contains("CurrentBerthID"))
                        {
                            dgvShips.Columns["CurrentBerthID"].Visible = false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading ships: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message); // For debugging
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading ships: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message); // For debugging
            }
        }

        // Event handler for DataGridView cell click
        // Populates input fields with data from the selected row
        private void dgvShips_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvShips.Rows[e.RowIndex];

                // Store the ShipID for update/delete operations
                _selectedShipId = Convert.ToInt32(row.Cells["ShipID"].Value);

                // Populate textboxes with selected row data
                txtShipName.Text = row.Cells["Name"].Value.ToString();
                txtShipCallSign.Text = row.Cells["CallSign"].Value.ToString();
                txtShipCapacityWeight.Text = row.Cells["CapacityWeight"].Value.ToString();
                txtShipCapacityVolume.Text = row.Cells["CapacityVolume"].Value.ToString();
                txtShipLength.Text = row.Cells["Length"].Value.ToString(); // Populate Length
                txtShipDraft.Text = row.Cells["Draft"].Value.ToString();   // Populate Draft
                txtShipCurrentLocation.Text = row.Cells["CurrentLocation"].Value.ToString();

                // Select the current status in the Status ComboBox
                if (row.Cells["Status"].Value != DBNull.Value)
                {
                    cmbShipStatus.SelectedItem = row.Cells["Status"].Value.ToString();
                }
                else
                {
                    cmbShipStatus.SelectedIndex = 0; // Default to 'Docked' if status is null/empty
                }

                // Select the assigned berth in the ComboBox
                if (row.Cells["CurrentBerthID"].Value != DBNull.Value)
                {
                    cmbAssignBerth.SelectedValue = row.Cells["CurrentBerthID"].Value;
                }
                else
                {
                    // Select the "None" option if no berth is assigned
                    cmbAssignBerth.SelectedValue = DBNull.Value;
                }
            }
        }

        // Event handler for Add Ship button
        private void btnAddShip_Click(object sender, EventArgs e)
        {
            // Get data from textboxes
            string name = txtShipName.Text.Trim();
            string callSign = txtShipCallSign.Text.Trim();
            string currentLocation = txtShipCurrentLocation.Text.Trim();
            string status = cmbShipStatus.SelectedItem?.ToString() ?? "Docked";

            // Validate inputs
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(callSign) || string.IsNullOrEmpty(currentLocation))
            {
                MessageBox.Show("Please fill in Ship Name, Call Sign, and Current Location.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate and parse numerical inputs
            decimal capacityWeight = 0;
            decimal capacityVolume = 0;
            decimal length = 0; // New
            decimal draft = 0;  // New

            if (!string.IsNullOrEmpty(txtShipCapacityWeight.Text) && !decimal.TryParse(txtShipCapacityWeight.Text, out capacityWeight))
            {
                MessageBox.Show("Invalid value for Capacity Weight. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (!string.IsNullOrEmpty(txtShipLength.Text) && !decimal.TryParse(txtShipLength.Text, out length))
            {
                MessageBox.Show("Invalid value for Length. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtShipDraft.Text) && !decimal.TryParse(txtShipDraft.Text, out draft))
            {
                MessageBox.Show("Invalid value for Draft. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // New ships start unassigned from a berth
            int? newBerthId = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Ships (Name, CallSign, CapacityWeight, CapacityVolume, Length, Draft, CurrentLocation, Status, CurrentBerthID, LastUpdated) " +
                                   "VALUES (@Name, @CallSign, @CapacityWeight, @CapacityVolume, @Length, @Draft, @CurrentLocation, @Status, @CurrentBerthID, GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@CallSign", callSign);
                        command.Parameters.AddWithValue("@CapacityWeight", capacityWeight);
                        command.Parameters.AddWithValue("@CapacityVolume", capacityVolume);
                        command.Parameters.AddWithValue("@Length", length); // Add Length
                        command.Parameters.AddWithValue("@Draft", draft);     // Add Draft
                        command.Parameters.AddWithValue("@CurrentLocation", currentLocation);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@CurrentBerthID", newBerthId.HasValue ? (object)newBerthId.Value : DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ship added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearShipInputFields();
                            LoadShipData(); // Refresh the DataGridView to show the new ship
                        }
                        else
                        {
                            MessageBox.Show("Failed to add ship.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation (Name or CallSign)
                {
                    MessageBox.Show("Ship name or Call Sign already exists. Please enter unique values.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Database Error adding ship: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while adding ship: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        // Event handler for Update Ship button
        private void btnUpdateShip_Click(object sender, EventArgs e)
        {
            if (_selectedShipId == -1)
            {
                MessageBox.Show("Please select a ship from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get updated data from textboxes
            string name = txtShipName.Text.Trim();
            string callSign = txtShipCallSign.Text.Trim();
            string currentLocation = txtShipCurrentLocation.Text.Trim();
            string status = cmbShipStatus.SelectedItem?.ToString() ?? "Docked";

            // Get selected BerthID from ComboBox
            object selectedBerthIdObj = cmbAssignBerth.SelectedValue;
            int? newBerthId = (selectedBerthIdObj == null || selectedBerthIdObj == DBNull.Value) ? (int?)null : Convert.ToInt32(selectedBerthIdObj);

            // Validate inputs
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(callSign) || string.IsNullOrEmpty(currentLocation))
            {
                MessageBox.Show("Please fill in Ship Name, Call Sign, and Current Location.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate and parse numerical inputs
            decimal capacityWeight = 0;
            decimal capacityVolume = 0;
            decimal length = 0; // New
            decimal draft = 0;  // New

            if (!string.IsNullOrEmpty(txtShipCapacityWeight.Text) && !decimal.TryParse(txtShipCapacityWeight.Text, out capacityWeight))
            {
                MessageBox.Show("Invalid value for Capacity Weight. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtShipCapacityVolume.Text) && !decimal.TryParse(txtShipCapacityVolume.Text, out capacityVolume))
            {
                MessageBox.Show("Invalid value for Capacity Volume. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtShipLength.Text) && !decimal.TryParse(txtShipLength.Text, out length))
            {
                MessageBox.Show("Invalid value for Length. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtShipDraft.Text) && !decimal.TryParse(txtShipDraft.Text, out draft))
            {
                MessageBox.Show("Invalid value for Draft. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Berth Assignment and Validation Logic ---
            try
            {
                // Get old berth ID before potential update
                int? oldBerthId = GetShipBerthId(_selectedShipId);

                if (newBerthId.HasValue) // If a berth is being assigned or changed
                {
                    BerthDetails berthDetails = GetBerthDetails(newBerthId.Value);
                    if (berthDetails == null)
                    {
                        MessageBox.Show("Selected berth details could not be retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check if berth is already occupied by another ship
                    // If berth status is occupied and it's a different berth or the same berth but occupied by a *different* ship
                    if (berthDetails.Status == "Occupied" && (oldBerthId != newBerthId || (oldBerthId == newBerthId && berthDetails.OccupyingShipID.HasValue && berthDetails.OccupyingShipID.Value != _selectedShipId)))
                    {
                        MessageBox.Show($"Berth '{berthDetails.Name}' is currently occupied. Please choose a different berth or change its status.", "Berth Occupied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (berthDetails.Status == "Under Maintenance") // If under maintenance
                    {
                        MessageBox.Show($"Berth '{berthDetails.Name}' is currently under maintenance. Cannot assign ships.", "Berth Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validate ship dimensions against berth capacity
                    if (length > berthDetails.MaxLength || draft > berthDetails.MaxDraft)
                    {
                        MessageBox.Show($"Ship dimensions exceed selected berth capacity:\n" +
                                        $"Ship Length: {length:N2}m (Berth Max: {berthDetails.MaxLength:N2}m)\n" +
                                        $"Ship Draft: {draft:N2}m (Berth Max: {berthDetails.MaxDraft:N2}m)",
                                        "Berth Capacity Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Prevent update
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during berth validation: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Berth Validation Error: " + ex.Message);
                return;
            }
            // --- End Berth Assignment and Validation Logic ---


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Ships SET Name = @Name, CallSign = @CallSign, CapacityWeight = @CapacityWeight, " +
                                   "CapacityVolume = @CapacityVolume, Length = @Length, Draft = @Draft, CurrentLocation = @CurrentLocation, Status = @Status, " +
                                   "CurrentBerthID = @CurrentBerthID, LastUpdated = GETDATE() " +
                                   "WHERE ShipID = @ShipID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@CallSign", callSign);
                        command.Parameters.AddWithValue("@CapacityWeight", capacityWeight);
                        command.Parameters.AddWithValue("@CapacityVolume", capacityVolume);
                        command.Parameters.AddWithValue("@Length", length); // Add Length
                        command.Parameters.AddWithValue("@Draft", draft);     // Add Draft
                        command.Parameters.AddWithValue("@CurrentLocation", currentLocation);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@CurrentBerthID", newBerthId.HasValue ? (object)newBerthId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@ShipID", _selectedShipId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ship updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearShipInputFields(); // Clear textboxes
                            LoadShipData(); // Refresh the DataGridView
                            _selectedShipId = -1; // Reset selected ID

                            // --- Automated Berth Status Update Logic ---
                            int? oldBerthId = GetShipBerthId(_selectedShipId); // Re-fetch to be safe (though should be same as 'oldBerthId' from above)

                            if (oldBerthId.HasValue && oldBerthId != newBerthId)
                            {
                                // If ship moved from a berth or unassigned from one
                                ReevaluateBerthStatus(oldBerthId.Value);
                            }

                            if (newBerthId.HasValue)
                            {
                                // If ship is assigned to a new berth, set that berth to 'Occupied'
                                UpdateBerthStatus(newBerthId.Value, "Occupied");
                            }
                            // --- End Automated Berth Status Update Logic ---
                        }
                        else
                        {
                            MessageBox.Show("Failed to update ship. Ship might not exist or no changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation (Name or CallSign)
                {
                    MessageBox.Show("Ship name or Call Sign already exists. Please enter unique values.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Database Error updating ship: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating ship: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        // Event handler for Delete Ship button
        private void btnDeleteShip_Click(object sender, EventArgs e)
        {
            if (_selectedShipId == -1)
            {
                MessageBox.Show("Please select a ship from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Are you sure you want to delete Ship ID: {_selectedShipId} ({txtShipName.Text})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                int? berthIdBeforeDelete = null;
                // Get the berth ID before deleting the ship
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string getBerthIdQuery = "SELECT CurrentBerthID FROM Ships WHERE ShipID = @ShipID";
                        using (SqlCommand cmd = new SqlCommand(getBerthIdQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@ShipID", _selectedShipId);
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                berthIdBeforeDelete = Convert.ToInt32(result);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting CurrentBerthID before deleting ship: {ex.Message}");
                    // Continue with deletion, but log this error.
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Ships WHERE ShipID = @ShipID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ShipID", _selectedShipId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Ship deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearShipInputFields(); // Clear textboxes
                                LoadShipData(); // Refresh the DataGridView
                                _selectedShipId = -1; // Reset selected ID

                                // Re-evaluate berth status after ship deletion
                                if (berthIdBeforeDelete.HasValue)
                                {
                                    ReevaluateBerthStatus(berthIdBeforeDelete.Value);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete ship. Ship might not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Check for foreign key constraint violation (e.g., if cargo is still assigned to this ship)
                    if (ex.Number == 547) // SQL Server foreign key violation error number
                    {
                        MessageBox.Show("Cannot delete this ship because there are still cargo items assigned to it. Please reassign or delete the cargo first.", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Database Error deleting ship: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("SQL Error: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred while deleting ship: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("General Error: " + ex.Message);
                }
            }
        }

        // Event handler for Generate Report button
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Open the ReportForm
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        // Helper method to clear input fields
        private void ClearShipInputFields()
        {
            txtShipName.Clear();
            txtShipCallSign.Clear();
            txtShipCapacityWeight.Clear();
            txtShipCapacityVolume.Clear();
            txtShipLength.Clear(); // Clear Length
            txtShipDraft.Clear();   // Clear Draft
            txtShipCurrentLocation.Clear();
            cmbShipStatus.SelectedIndex = 0; // Reset status to 'Docked'
            cmbAssignBerth.SelectedValue = DBNull.Value; // Reset berth to "None"
            _selectedShipId = -1; // Also reset the selected ID
            InitializeSearchBox(); // Reset search box text and color
        }

        // --- Helper Methods for Berth Management Integration ---

        // Custom class to hold berth details for validation
        private class BerthDetails
        {
            public string Name { get; set; }
            public string Status { get; set; }
            public decimal MaxLength { get; set; }
            public decimal MaxDraft { get; set; }
            public int? OccupyingShipID { get; set; } // New: To check if a ship is currently occupying it
        }

        // Method to get a berth's details for validation
        private BerthDetails GetBerthDetails(int berthId)
        {
            BerthDetails details = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Include OccupyingShipID in the query
                    string query = "SELECT b.Name, b.Status, b.MaxLength, b.MaxDraft, s.ShipID AS OccupyingShipID FROM Berths b LEFT JOIN Ships s ON b.BerthID = s.CurrentBerthID WHERE b.BerthID = @BerthID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BerthID", berthId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                details = new BerthDetails
                                {
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Status = reader.GetString(reader.GetOrdinal("Status")),
                                    MaxLength = reader.GetDecimal(reader.GetOrdinal("MaxLength")),
                                    MaxDraft = reader.GetDecimal(reader.GetOrdinal("MaxDraft")),
                                    OccupyingShipID = reader.IsDBNull(reader.GetOrdinal("OccupyingShipID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("OccupyingShipID"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting berth details for BerthID {berthId}: {ex.Message}");
                throw; // Re-throw to be caught by calling method
            }
            return details;
        }

        // Method to get a ship's current assigned BerthID
        private int? GetShipBerthId(int shipId)
        {
            int? berthId = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CurrentBerthID FROM Ships WHERE ShipID = @ShipID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShipID", shipId);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            berthId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting ship's current berth for ShipID {shipId}: {ex.Message}");
                // Log but don't re-throw, as it's a helper for pre-check
            }
            return berthId;
        }


        // Method to update a berth's status
        private void UpdateBerthStatus(int berthId, string newStatus)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Berths SET Status = @NewStatus, LastUpdated = GETDATE() WHERE BerthID = @BerthID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewStatus", newStatus);
                        command.Parameters.AddWithValue("@BerthID", berthId);
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Berth {berthId} status updated to '{newStatus}' automatically.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating berth status for BerthID {berthId}: {ex.Message}");
                // Log this, but don't stop the main ship update process for this side effect
            }
        }

        // Method to re-evaluate a berth's status based on assigned ships
        private void ReevaluateBerthStatus(int berthId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Check if any ships are still assigned to this berth
                    string query = "SELECT COUNT(*) FROM Ships WHERE CurrentBerthID = @BerthID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BerthID", berthId);
                        int assignedShipsCount = (int)command.ExecuteScalar();

                        if (assignedShipsCount > 0)
                        {
                            // If there are still ships assigned, ensure berth is 'Occupied'
                            UpdateBerthStatus(berthId, "Occupied");
                        }
                        else
                        {
                            // If no ships assigned, revert to 'Free'
                            UpdateBerthStatus(berthId, "Free");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error re-evaluating berth status for BerthID {berthId}: {ex.Message}");
            }
        }

        private void lblShipLength_Click(object sender, EventArgs e)
        {

        }

        private void lblShipDraft_Click(object sender, EventArgs e)
        {

        }

        private void txtShipLength_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblShipStatus_Click(object sender, EventArgs e)
        {

        }

        private void txtShipDraft_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAssignBerth_Click(object sender, EventArgs e)
        {

        }
    }
}
