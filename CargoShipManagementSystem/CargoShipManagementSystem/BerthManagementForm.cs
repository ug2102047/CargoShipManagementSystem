using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CargoShipManagementSystem
{
    public partial class BerthManagementForm : Form
    {
        // Connection string loaded from App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["CargoShipDB"].ConnectionString;

        private int _selectedBerthId = -1; // To store the BerthID of the selected row for Update/Delete
        private const string SearchPlaceholderText = "Search by Name..."; // Placeholder text for search box

        public BerthManagementForm()
        {
            InitializeComponent();
            InitializeSearchBox();
            InitializeBerthStatusComboBox();
        }

        private void BerthManagementForm_Load(object sender, EventArgs e)
        {
            LoadBerthData(); // Load data when the form loads
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Initialize Search Box placeholder text
        private void InitializeSearchBox()
        {
            txtSearchBerth.Text = SearchPlaceholderText;
            txtSearchBerth.ForeColor = System.Drawing.SystemColors.GrayText;
        }

        // Event handler for when the search textbox gains focus
        private void txtSearchBerth_Enter(object sender, EventArgs e)
        {
            if (txtSearchBerth.Text == SearchPlaceholderText)
            {
                txtSearchBerth.Text = "";
                txtSearchBerth.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        // Event handler for when the search textbox loses focus
        private void txtSearchBerth_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchBerth.Text))
            {
                txtSearchBerth.Text = SearchPlaceholderText;
                txtSearchBerth.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        // Event handler for Search button click
        private void btnSearchBerth_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchBerth.Text.Trim();
            if (searchTerm == SearchPlaceholderText)
            {
                searchTerm = ""; // Treat placeholder as empty search
            }
            LoadBerthData(searchTerm); // Load data with the search term
        }

        // Initialize Berth Status ComboBox
        private void InitializeBerthStatusComboBox()
        {
            cmbBerthStatus.Items.Add("Free");
            cmbBerthStatus.Items.Add("Occupied");
            cmbBerthStatus.Items.Add("Under Maintenance");
            cmbBerthStatus.SelectedIndex = 0; // Default to 'Free'
            cmbBerthStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Method to load berth data into the DataGridView with optional search term
        private void LoadBerthData(string searchTerm = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT BerthID, Name, MaxLength, MaxDraft, Status, LastUpdated FROM Berths WHERE 1=1";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " AND Name LIKE @SearchTerm";
                    }
                    query += " ORDER BY Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvBerths.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading berths: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading berths: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        // Event handler for DataGridView cell click
        private void dgvBerths_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBerths.Rows[e.RowIndex];
                _selectedBerthId = Convert.ToInt32(row.Cells["BerthID"].Value);

                txtBerthName.Text = row.Cells["Name"].Value.ToString();
                txtMaxLength.Text = row.Cells["MaxLength"].Value.ToString();
                txtMaxDraft.Text = row.Cells["MaxDraft"].Value.ToString();
                cmbBerthStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            }
        }

        // Event handler for Add Berth button
        private void btnAddBerth_Click(object sender, EventArgs e)
        {
            string name = txtBerthName.Text.Trim();
            string status = cmbBerthStatus.SelectedItem?.ToString() ?? "Free";

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a Berth Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal maxLength = 0;
            decimal maxDraft = 0;

            if (!string.IsNullOrEmpty(txtMaxLength.Text) && !decimal.TryParse(txtMaxLength.Text, out maxLength))
            {
                MessageBox.Show("Invalid value for Max Length. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtMaxDraft.Text) && !decimal.TryParse(txtMaxDraft.Text, out maxDraft))
            {
                MessageBox.Show("Invalid value for Max Draft. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Berths (Name, MaxLength, MaxDraft, Status, LastUpdated) VALUES (@Name, @MaxLength, @MaxDraft, @Status, GETDATE())";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@MaxLength", maxLength);
                        command.Parameters.AddWithValue("@MaxDraft", maxDraft);
                        command.Parameters.AddWithValue("@Status", status);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Berth added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearBerthInputFields();
                            LoadBerthData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add berth.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                {
                    MessageBox.Show("Berth name already exists. Please choose a different name.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Database Error adding berth: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while adding berth: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        // Event handler for Update Berth button
        private void btnUpdateBerth_Click(object sender, EventArgs e)
        {
            if (_selectedBerthId == -1)
            {
                MessageBox.Show("Please select a berth from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtBerthName.Text.Trim();
            string status = cmbBerthStatus.SelectedItem?.ToString() ?? "Free";

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter a Berth Name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal maxLength = 0;
            decimal maxDraft = 0;

            if (!string.IsNullOrEmpty(txtMaxLength.Text) && !decimal.TryParse(txtMaxLength.Text, out maxLength))
            {
                MessageBox.Show("Invalid value for Max Length. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtMaxDraft.Text) && !decimal.TryParse(txtMaxDraft.Text, out maxDraft))
            {
                MessageBox.Show("Invalid value for Max Draft. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Berths SET Name = @Name, MaxLength = @MaxLength, MaxDraft = @MaxDraft, Status = @Status, LastUpdated = GETDATE() WHERE BerthID = @BerthID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@MaxLength", maxLength);
                        command.Parameters.AddWithValue("@MaxDraft", maxDraft);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@BerthID", _selectedBerthId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Berth updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearBerthInputFields();
                            LoadBerthData();
                            _selectedBerthId = -1;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update berth. Berth might not exist or no changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                {
                    MessageBox.Show("Berth name already exists. Please choose a different name.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Database Error updating berth: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating berth: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        // Event handler for Delete Berth button
        private void btnDeleteBerth_Click(object sender, EventArgs e)
        {
            if (_selectedBerthId == -1)
            {
                MessageBox.Show("Please select a berth from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Are you sure you want to delete Berth: {txtBerthName.Text} (ID: {_selectedBerthId})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Berths WHERE BerthID = @BerthID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@BerthID", _selectedBerthId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Berth deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearBerthInputFields();
                                LoadBerthData();
                                _selectedBerthId = -1;
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete berth. Berth might not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key constraint violation (ships might be assigned to this berth)
                    {
                        MessageBox.Show("Cannot delete this berth because there are ships currently assigned to it. Please reassign the ships first.", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Database Error deleting berth: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("SQL Error: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred while deleting berth: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("General Error: " + ex.Message);
                }
            }
        }

        // Helper method to clear input fields and reset selected ID
        private void ClearBerthInputFields()
        {
            txtBerthName.Clear();
            txtMaxLength.Clear();
            txtMaxDraft.Clear();
            cmbBerthStatus.SelectedIndex = 0; // Reset to 'Free'
            _selectedBerthId = -1;
            InitializeSearchBox(); // Reset search box text and color
        }
    }
}
