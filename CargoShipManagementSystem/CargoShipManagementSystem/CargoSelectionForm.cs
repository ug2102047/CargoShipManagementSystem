using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CargoShipManagementSystem
{
    public partial class CargoSelectionForm : Form
    {
        private string _connectionString;
        public List<int> SelectedCargoIds { get; private set; } = new List<int>();

        public CargoSelectionForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            // Allow multiple row selection
            dgvAllCargo.MultiSelect = true;
            dgvAllCargo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CargoSelectionForm_Load(object sender, EventArgs e)
        {
            LoadAllCargoData();
        }

        private void LoadAllCargoData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    // Load all cargo, including ShipName for better context
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
                            s.Name AS ShipName,
                            c.LastUpdated
                        FROM
                            Cargo c
                        LEFT JOIN
                            Ships s ON c.ShipID = s.ShipID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAllCargo.DataSource = dt;

                    // Hide ShipID column if present, as ShipName is more user-friendly
                    if (dgvAllCargo.Columns.Contains("ShipID"))
                    {
                        dgvAllCargo.Columns["ShipID"].Visible = false;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading cargo for selection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while loading cargo for selection: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedCargoIds.Clear();
            foreach (DataGridViewRow row in dgvAllCargo.SelectedRows)
            {
                // Ensure CargoID column exists and is not DBNull
                if (row.Cells["CargoID"].Value != null && row.Cells["CargoID"].Value != DBNull.Value)
                {
                    SelectedCargoIds.Add(Convert.ToInt32(row.Cells["CargoID"].Value));
                }
            }

            if (!SelectedCargoIds.Any())
            {
                MessageBox.Show("Please select at least one cargo item for the invoice.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK; // Indicate successful selection
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indicate cancellation
            this.Close();
        }
    }
}
