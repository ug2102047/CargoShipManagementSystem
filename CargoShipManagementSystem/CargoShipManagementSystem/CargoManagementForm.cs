using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic; // Needed for List

namespace CargoShipManagementSystem
{
    public partial class CargoManagementForm : Form
    {
        // Connection string loaded from App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["CargoShipDB"].ConnectionString;

        private int _selectedCargoId = -1; // To store the CargoID of the selected row for Update/Delete
        private const string SearchPlaceholderText = "Search by Name, Origin, Destination..."; // Placeholder text for search box

        public CargoManagementForm()
        {
            InitializeComponent();
            InitializeSearchBox(); // Initialize the search text box with placeholder
        }

        private void CargoManagementForm_Load(object sender, EventArgs e)
        {
            LoadCargoData(); // Load data when the form loads initially (no filter)
            LoadShipsIntoComboBox(); // Load ships into the combo box
            InitializeCargoStatusComboBox(); // Initialize the status combo box
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the current form
        }

        // Method to initialize the search text box with placeholder
        private void InitializeSearchBox()
        {
            txtSearchCargo.Text = SearchPlaceholderText;
            txtSearchCargo.ForeColor = System.Drawing.SystemColors.GrayText;
        }

        // Event handler for when the search textbox gains focus
        private void txtSearchCargo_Enter(object sender, EventArgs e)
        {
            if (txtSearchCargo.Text == SearchPlaceholderText)
            {
                txtSearchCargo.Text = "";
                txtSearchCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        // Event handler for when the search textbox loses focus
        private void txtSearchCargo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCargo.Text))
            {
                txtSearchCargo.Text = SearchPlaceholderText;
                txtSearchCargo.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        // Event handler for Search button click
        private void btnSearchCargo_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchCargo.Text.Trim();
            if (searchTerm == SearchPlaceholderText)
            {
                searchTerm = ""; // Treat placeholder as empty search
            }
            LoadCargoData(searchTerm); // Load data with the search term
        }


        // Method to load cargo data into the DataGridView with optional search term
        private void LoadCargoData(string searchTerm = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT
                            c.CargoID,
                            c.Name,
                            c.Description,
                            c.Weight,
                            c.Volume,
                            c.Status,
                            c.Origin,
                            c.Destination,
                            s.Name AS ShipName, -- Display Ship Name
                            c.ShipID,           -- Keep ShipID for internal logic
                            c.LastUpdated
                        FROM
                            Cargo c
                        LEFT JOIN
                            Ships s ON c.ShipID = s.ShipID
                        WHERE 1=1"; // Always true condition to easily append AND clauses

                    // Add search conditions if a search term is provided
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " AND (c.Name LIKE @SearchTerm OR c.Description LIKE @SearchTerm OR " +
                                 "c.Origin LIKE @SearchTerm OR c.Destination LIKE @SearchTerm)";
                    }

                    // Order by Name for consistent display
                    query += " ORDER BY c.Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvCargo.DataSource = dt; // Set the DataTable as the DataGridView's data source

                        // Optional: Hide the raw ShipID column if you only want to show ShipName
                        if (dgvCargo.Columns.Contains("ShipID"))
                        {
                            dgvCargo.Columns["ShipID"].Visible = false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message); // For debugging
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message); // For debugging
            }
        }

        // Method to load ships into the ComboBox
        private void LoadShipsIntoComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Query to get ShipID and Name
                    string query = "SELECT ShipID, Name FROM Ships ORDER BY Name";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a default "None" option to allow unassigning cargo
                    DataRow newRow = dt.NewRow();
                    newRow["ShipID"] = DBNull.Value; // Use DBNull for the NULL foreign key
                    newRow["Name"] = "-- Select Ship --";
                    dt.Rows.InsertAt(newRow, 0);

                    cmbAssignShip.DataSource = dt;
                    cmbAssignShip.DisplayMember = "Name"; // Display ship name
                    cmbAssignShip.ValueMember = "ShipID"; // Use ShipID as the actual value
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading ships for assignment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message); // For debugging
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading ships for assignment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message); // For debugging
            }
        }

        // Method to initialize the Cargo Status ComboBox
        private void InitializeCargoStatusComboBox()
        {
            cmbCargoStatus.Items.Add("Pending");
            cmbCargoStatus.Items.Add("Loaded");
            cmbCargoStatus.Items.Add("In Transit");
            cmbCargoStatus.Items.Add("Delivered");
            cmbCargoStatus.Items.Add("Cancelled");
            cmbCargoStatus.DropDownStyle = ComboBoxStyle.DropDownList; // Make it non-editable
        }

        // Event handler for DataGridView cell click
        // Populates input fields with data from the selected row
        private void dgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvCargo.Rows[e.RowIndex];

                // Store the CargoID for update/delete operations
                _selectedCargoId = Convert.ToInt32(row.Cells["CargoID"].Value);

                // Populate textboxes with selected row data
                txtCargoName.Text = row.Cells["Name"].Value.ToString();
                txtCargoDescription.Text = row.Cells["Description"].Value?.ToString(); // Handle DBNull
                txtCargoWeight.Text = row.Cells["Weight"].Value.ToString();
                txtCargoVolume.Text = row.Cells["Volume"].Value.ToString();
                txtCargoOrigin.Text = row.Cells["Origin"].Value.ToString();
                txtCargoDestination.Text = row.Cells["Destination"].Value.ToString();

                // Select the assigned ship in the ComboBox
                if (row.Cells["ShipID"].Value != DBNull.Value)
                {
                    cmbAssignShip.SelectedValue = row.Cells["ShipID"].Value;
                }
                else
                {
                    // Select the "None" option if no ship is assigned
                    cmbAssignShip.SelectedValue = DBNull.Value;
                }

                // Select the current status in the Status ComboBox
                if (row.Cells["Status"].Value != DBNull.Value)
                {
                    cmbCargoStatus.SelectedItem = row.Cells["Status"].Value.ToString();
                }
                else
                {
                    cmbCargoStatus.SelectedItem = "Pending"; // Default or first item
                }
            }
        }

        // Event handler for Add Cargo button
        private void btnAddCargo_Click(object sender, EventArgs e)
        {
            // Get data from textboxes
            string name = txtCargoName.Text.Trim();
            string description = txtCargoDescription.Text.Trim();
            string origin = txtCargoOrigin.Text.Trim();
            string destination = txtCargoDestination.Text.Trim();
            string status = cmbCargoStatus.SelectedItem?.ToString() ?? "Pending"; // Get status from new ComboBox, default to "Pending"

            // Validate inputs
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Please fill in Cargo Name, Origin, and Destination.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate and parse numerical inputs
            decimal weight = 0;
            decimal volume = 0;

            if (!string.IsNullOrEmpty(txtCargoWeight.Text) && !decimal.TryParse(txtCargoWeight.Text, out weight))
            {
                MessageBox.Show("Invalid value for Weight. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtCargoVolume.Text) && !decimal.TryParse(txtCargoVolume.Text, out volume))
            {
                MessageBox.Show("Invalid value for Volume. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Cargo (Name, Description, Weight, Volume, Status, Origin, Destination, LastUpdated) " +
                                   "VALUES (@Name, @Description, @Weight, @Volume, @Status, @Origin, @Destination, GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
                        command.Parameters.AddWithValue("@Weight", weight);
                        command.Parameters.AddWithValue("@Volume", volume);
                        command.Parameters.AddWithValue("@Status", status); // Add status parameter for new cargo
                        command.Parameters.AddWithValue("@Origin", origin);
                        command.Parameters.AddWithValue("@Destination", destination);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cargo added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearCargoInputFields(); // Clear textboxes after successful add
                            LoadCargoData(); // Refresh the DataGridView to show the new cargo
                        }
                        else
                        {
                            MessageBox.Show("Failed to add cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error adding cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message); // For debugging
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while adding cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message); // For debugging
            }
        }

        // Event handler for Update Cargo button
        private void btnUpdateCargo_Click(object sender, EventArgs e)
        {
            if (_selectedCargoId == -1)
            {
                MessageBox.Show("Please select a cargo from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get updated data from textboxes
            string name = txtCargoName.Text.Trim();
            string description = txtCargoDescription.Text.Trim();
            string origin = txtCargoOrigin.Text.Trim();
            string destination = txtCargoDestination.Text.Trim();
            string newStatus = cmbCargoStatus.SelectedItem?.ToString() ?? "Pending"; // Get status from ComboBox


            // Get selected ShipID from ComboBox
            object selectedShipId = cmbAssignShip.SelectedValue;
            // If the "-- Select Ship --" option (or any DBNull.Value) is chosen, treat it as null
            int? newShipId = (selectedShipId == null || selectedShipId == DBNull.Value) ? (int?)null : Convert.ToInt32(selectedShipId);

            // Validate inputs
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Please fill in Cargo Name, Origin, and Destination.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate and parse numerical inputs
            decimal weight = 0;
            decimal volume = 0;

            if (!string.IsNullOrEmpty(txtCargoWeight.Text) && !decimal.TryParse(txtCargoWeight.Text, out weight))
            {
                MessageBox.Show("Invalid value for Weight. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtCargoVolume.Text) && !decimal.TryParse(txtCargoVolume.Text, out volume))
            {
                MessageBox.Show("Invalid value for Volume. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Capacity Validation Logic ---
            try
            {
                // If a ship is being assigned or changed to a new ship
                if (newShipId.HasValue)
                {
                    ShipCapacity shipCapacity = GetShipCapacity(newShipId.Value);
                    if (shipCapacity == null)
                    {
                        MessageBox.Show("Selected ship's capacity could not be retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Calculate current load on the target ship, excluding the cargo being updated if it was already on this ship
                    (decimal currentLoadWeight, decimal currentLoadVolume) = GetShipCurrentLoad(newShipId.Value, _selectedCargoId);

                    // Calculate projected total load
                    decimal projectedWeight = currentLoadWeight + weight;
                    decimal projectedVolume = currentLoadVolume + volume;

                    // Check against ship's total capacity
                    if (projectedWeight > shipCapacity.CapacityWeight || projectedVolume > shipCapacity.CapacityVolume)
                    {
                        MessageBox.Show($"Cannot assign cargo to this ship. Exceeds capacity:\n" +
                                        $"Weight: {projectedWeight:N2} / {shipCapacity.CapacityWeight:N2} (max)\n" +
                                        $"Volume: {projectedVolume:N2} / {shipCapacity.CapacityVolume:N2} (max)",
                                        "Capacity Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Prevent update
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during capacity validation: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Capacity Validation Error: " + ex.Message);
                return;
            }
            // --- End Capacity Validation Logic ---


            try
            {
                // Get old ship ID and status BEFORE the update
                int? oldShipId = null;
                string oldStatus = "";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string getOldDataQuery = "SELECT ShipID, Status FROM Cargo WHERE CargoID = @CargoID";
                    using (SqlCommand oldDataCommand = new SqlCommand(getOldDataQuery, connection))
                    {
                        oldDataCommand.Parameters.AddWithValue("@CargoID", _selectedCargoId);
                        using (SqlDataReader reader = oldDataCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oldShipId = reader.IsDBNull(reader.GetOrdinal("ShipID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ShipID"));
                                oldStatus = reader.GetString(reader.GetOrdinal("Status"));
                            }
                        }
                    }
                }


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Include ShipID and Status in the update query
                    string query = "UPDATE Cargo SET Name = @Name, Description = @Description, Weight = @Weight, " +
                                   "Volume = @Volume, Status = @Status, Origin = @Origin, Destination = @Destination, " +
                                   "ShipID = @ShipID, LastUpdated = GETDATE() " +
                                   "WHERE CargoID = @CargoID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
                        command.Parameters.AddWithValue("@Weight", weight);
                        command.Parameters.AddWithValue("@Volume", volume);
                        command.Parameters.AddWithValue("@Status", newStatus); // Add status parameter
                        command.Parameters.AddWithValue("@Origin", origin);
                        command.Parameters.AddWithValue("@Destination", destination);
                        // Add ShipID parameter, handle nullability
                        command.Parameters.AddWithValue("@ShipID", newShipId.HasValue ? (object)newShipId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@CargoID", _selectedCargoId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cargo updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearCargoInputFields(); // Clear textboxes
                            LoadCargoData(); // Refresh the DataGridView
                            _selectedCargoId = -1; // Reset selected ID

                            // --- Automated Ship Status Update Logic ---
                            // If ship ID changed or status changed from/to 'Loaded'/'In Transit'
                            bool statusBecomingActive = (newStatus == "Loaded" || newStatus == "In Transit");
                            bool statusBecomingInactive = (oldStatus == "Loaded" || oldStatus == "In Transit") &&
                                                          (newStatus != "Loaded" && newStatus != "In Transit");
                            bool shipAssignedOrChanged = newShipId.HasValue;

                            if (shipAssignedOrChanged && statusBecomingActive)
                            {
                                UpdateShipStatus(newShipId.Value, "In Transit");
                            }
                            else if (oldShipId.HasValue && (statusBecomingInactive || (newShipId.HasValue && newShipId != oldShipId) || !newShipId.HasValue))
                            {
                                // If old ship was assigned, re-evaluate its status if cargo went inactive or moved
                                ReevaluateShipStatus(oldShipId.Value);
                            }
                            if (newShipId.HasValue && newShipId != oldShipId)
                            {
                                // If cargo moved to a new ship and its status is active, update the new ship
                                if (statusBecomingActive)
                                {
                                    UpdateShipStatus(newShipId.Value, "In Transit");
                                }
                            }
                            // --- End Automated Ship Status Update Logic ---

                        }
                        else
                        {
                            MessageBox.Show("Failed to update cargo. Cargo might not exist or no changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error updating cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        // Event handler for Delete Cargo button
        private void btnDeleteCargo_Click(object sender, EventArgs e)
        {
            if (_selectedCargoId == -1)
            {
                MessageBox.Show("Please select a cargo from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Are you sure you want to delete Cargo ID: {_selectedCargoId} ({txtCargoName.Text})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                int? shipIdBeforeDelete = null;
                // Get the ship ID before deleting the cargo
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string getShipIdQuery = "SELECT ShipID FROM Cargo WHERE CargoID = @CargoID";
                        using (SqlCommand cmd = new SqlCommand(getShipIdQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@CargoID", _selectedCargoId);
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                shipIdBeforeDelete = Convert.ToInt32(result);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting ShipID before deleting cargo: {ex.Message}");
                    // Continue with deletion, but log this error.
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Cargo WHERE CargoID = @CargoID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CargoID", _selectedCargoId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cargo deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearCargoInputFields(); // Clear textboxes
                                LoadCargoData(); // Refresh the DataGridView
                                _selectedCargoId = -1; // Reset selected ID

                                // Re-evaluate ship status after cargo deletion
                                if (shipIdBeforeDelete.HasValue)
                                {
                                    ReevaluateShipStatus(shipIdBeforeDelete.Value);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete cargo. Cargo might not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error deleting cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred while deleting cargo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ClearCargoInputFields()
        {
            txtCargoName.Clear();
            txtCargoDescription.Clear();
            txtCargoWeight.Clear();
            txtCargoVolume.Clear();
            txtCargoOrigin.Clear();
            txtCargoDestination.Clear();
            cmbAssignShip.SelectedValue = DBNull.Value; // Reset ComboBox to "None"
            cmbCargoStatus.SelectedItem = "Pending"; // Reset status to "Pending"
            _selectedCargoId = -1; // Also reset the selected ID
            InitializeSearchBox(); // Reset search box text and color
        }

        // --- Helper Methods for Capacity Tracking and Ship Status Automation ---

        // Custom class to hold ship capacity details
        private class ShipCapacity
        {
            public decimal CapacityWeight { get; set; }
            public decimal CapacityVolume { get; set; }
        }

        // Method to get a ship's total capacity
        private ShipCapacity GetShipCapacity(int shipId)
        {
            ShipCapacity capacity = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CapacityWeight, CapacityVolume FROM Ships WHERE ShipID = @ShipID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShipID", shipId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                capacity = new ShipCapacity
                                {
                                    CapacityWeight = reader.GetDecimal(reader.GetOrdinal("CapacityWeight")),
                                    CapacityVolume = reader.GetDecimal(reader.GetOrdinal("CapacityVolume"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting ship capacity for ShipID {shipId}: {ex.Message}");
                throw; // Re-throw to be caught by calling method
            }
            return capacity;
        }

        // Method to get the current total loaded weight and volume for a ship,
        // optionally excluding a specific cargo item (useful during update)
        private (decimal totalWeight, decimal totalVolume) GetShipCurrentLoad(int shipId, int? excludeCargoId = null)
        {
            decimal totalWeight = 0;
            decimal totalVolume = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ISNULL(SUM(Weight), 0) AS TotalWeight, ISNULL(SUM(Volume), 0) AS TotalVolume " +
                                   "FROM Cargo WHERE ShipID = @ShipID";

                    if (excludeCargoId.HasValue && excludeCargoId.Value != -1)
                    {
                        query += " AND CargoID != @ExcludeCargoID";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShipID", shipId);
                        if (excludeCargoId.HasValue && excludeCargoId.Value != -1)
                        {
                            command.Parameters.AddWithValue("@ExcludeCargoID", excludeCargoId.Value);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalWeight = reader.GetDecimal(reader.GetOrdinal("TotalWeight"));
                                totalVolume = reader.GetDecimal(reader.GetOrdinal("TotalVolume"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting current load for ShipID {shipId}: {ex.Message}");
                throw; // Re-throw to be caught by calling method
            }
            return (totalWeight, totalVolume);
        }

        // Helper method to get the current cargo's details from the database
        // Needed to compare original ShipID/Weight/Volume before update
        private Cargo GetCargoDetails(int cargoId)
        {
            Cargo cargo = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Weight, Volume, ShipID, Status FROM Cargo WHERE CargoID = @CargoID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CargoID", cargoId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cargo = new Cargo
                                {
                                    CargoID = cargoId,
                                    Weight = reader.GetDecimal(reader.GetOrdinal("Weight")),
                                    Volume = reader.GetDecimal(reader.GetOrdinal("Volume")),
                                    ShipID = reader.IsDBNull(reader.GetOrdinal("ShipID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ShipID")),
                                    Status = reader.GetString(reader.GetOrdinal("Status"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting cargo details for CargoID {cargoId}: {ex.Message}");
                throw; // Re-throw to be caught by calling method
            }
            return cargo;
        }

        // Private nested class to represent Cargo details for internal use
        private class Cargo
        {
            public int CargoID { get; set; }
            public decimal Weight { get; set; }
            public decimal Volume { get; set; }
            public int? ShipID { get; set; } // Nullable int
            public string Status { get; set; }
        }

        // Method to update a ship's status
        private void UpdateShipStatus(int shipId, string newStatus)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Ships SET Status = @NewStatus, LastUpdated = GETDATE() WHERE ShipID = @ShipID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewStatus", newStatus);
                        command.Parameters.AddWithValue("@ShipID", shipId);
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Ship {shipId} status updated to '{newStatus}' automatically.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating ship status for ShipID {shipId}: {ex.Message}");
                // Log this, but don't stop the main cargo update process for this side effect
            }
        }

        // Method to re-evaluate a ship's status based on its assigned cargo
        private void ReevaluateShipStatus(int shipId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Check if any cargo on this ship is 'Loaded' or 'In Transit'
                    string query = "SELECT COUNT(*) FROM Cargo WHERE ShipID = @ShipID AND (Status = 'Loaded' OR Status = 'In Transit')";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShipID", shipId);
                        int activeCargoCount = (int)command.ExecuteScalar();

                        if (activeCargoCount > 0)
                        {
                            // If there's still active cargo, ensure ship is 'In Transit'
                            UpdateShipStatus(shipId, "In Transit");
                        }
                        else
                        {
                            // If no active cargo, revert to 'Docked'
                            UpdateShipStatus(shipId, "Docked");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error re-evaluating ship status for ShipID {shipId}: {ex.Message}");
            }
        }

        private void cmbCargoStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
