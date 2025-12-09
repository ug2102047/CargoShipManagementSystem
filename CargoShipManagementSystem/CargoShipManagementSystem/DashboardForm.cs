using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CargoShipManagementSystem
{
    public partial class DashboardForm : Form
    {
        private int _currentUserId;
        private string _currentUserRole;

        // Connection string loaded from App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["CargoShipDB"].ConnectionString;

        // Constructor to receive user information from LoginForm
        public DashboardForm(int userId, string userRole)
        {
            InitializeComponent();
            _currentUserId = userId;
            _currentUserRole = userRole;
            // Display welcome message with username and role
            lblWelcome.Text = $"Welcome, {_currentUserRole} (User ID: {_currentUserId})!";
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadDashboardSummary(); // Load summary data when the form loads initially
        }

        // Override OnActivated to refresh data whenever the form becomes active
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            LoadDashboardSummary(); // Reload summary data to ensure it's up-to-date
        }

        // Method to load summary data for cargo, ships, and berths
        private void LoadDashboardSummary()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // --- Cargo Summary ---
                    string cargoQuery = @"
                        SELECT
                            COUNT(*) AS TotalCargo,
                            SUM(CASE WHEN Status = 'Pending' THEN 1 ELSE 0 END) AS PendingCargo,
                            SUM(CASE WHEN Status = 'Loaded' THEN 1 ELSE 0 END) AS LoadedCargo,
                            SUM(CASE WHEN Status = 'In Transit' THEN 1 ELSE 0 END) AS InTransitCargo,
                            SUM(CASE WHEN Status = 'Delivered' THEN 1 ELSE 0 END) AS DeliveredCargo,
                            SUM(CASE WHEN Status = 'Cancelled' THEN 1 ELSE 0 END) AS CancelledCargo
                        FROM Cargo;";

                    using (SqlCommand cargoCommand = new SqlCommand(cargoQuery, connection))
                    {
                        using (SqlDataReader reader = cargoCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTotalCargo.Text = $"Total Cargo: {reader["TotalCargo"]}";
                                lblCargoPending.Text = $"Pending: {reader["PendingCargo"]}";
                                lblCargoLoaded.Text = $"Loaded: {reader["LoadedCargo"]}";
                                lblCargoInTransit.Text = $"In Transit: {reader["InTransitCargo"]}";
                                lblCargoDelivered.Text = $"Delivered: {reader["DeliveredCargo"]}";
                                lblCargoCancelled.Text = $"Cancelled: {reader["CancelledCargo"]}";
                            }
                        }
                    }

                    // --- Ship Summary ---
                    string shipQuery = @"
                        SELECT
                            COUNT(*) AS TotalShips,
                            SUM(CASE WHEN Status = 'Docked' THEN 1 ELSE 0 END) AS DockedShips,
                            SUM(CASE WHEN Status = 'In Transit' THEN 1 ELSE 0 END) AS InTransitShips,
                            SUM(CASE WHEN Status = 'Maintenance' THEN 1 ELSE 0 END) AS MaintenanceShips
                        FROM Ships;";

                    using (SqlCommand shipCommand = new SqlCommand(shipQuery, connection))
                    {
                        using (SqlDataReader reader = shipCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTotalShips.Text = $"Total Ships: {reader["TotalShips"]}";
                                lblShipDocked.Text = $"Docked: {reader["DockedShips"]}";
                                lblShipInTransit.Text = $"In Transit: {reader["InTransitShips"]}";
                                lblShipMaintenance.Text = $"Maintenance: {reader["MaintenanceShips"]}";
                            }
                        }
                    }

                    // --- Berth Summary (New) ---
                    string berthQuery = @"
                        SELECT
                            COUNT(*) AS TotalBerths,
                            SUM(CASE WHEN Status = 'Free' THEN 1 ELSE 0 END) AS FreeBerths,
                            SUM(CASE WHEN Status = 'Occupied' THEN 1 ELSE 0 END) AS OccupiedBerths,
                            SUM(CASE WHEN Status = 'Under Maintenance' THEN 1 ELSE 0 END) AS UnderMaintenanceBerths
                        FROM Berths;";

                    using (SqlCommand berthCommand = new SqlCommand(berthQuery, connection))
                    {
                        using (SqlDataReader reader = berthCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTotalBerths.Text = $"Total Berths: {reader["TotalBerths"]}";
                                lblBerthFree.Text = $"Free: {reader["FreeBerths"]}";
                                lblBerthOccupied.Text = $"Occupied: {reader["OccupiedBerths"]}";
                                lblBerthUnderMaintenance.Text = $"Under Maintenance: {reader["UnderMaintenanceBerths"]}";
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error loading dashboard summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("SQL Error: " + ex.Message); // For debugging
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred loading dashboard summary: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("General Error: " + ex.Message); // For debugging
            }
        }


        // Logout button click event
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before logging out
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); // Hide the dashboard
                LoginForm loginForm = new LoginForm();
                loginForm.Show(); // Show the login form again
                this.Close(); // Close the app
            }
        }

        // Event handler for Cargo Management button
        private void btnCargoManagement_Click(object sender, EventArgs e)
        {
            // Open the CargoManagementForm
            CargoManagementForm cargoForm = new CargoManagementForm();
            cargoForm.Show();
        }

        // Event handler for Ship Management button
        private void btnShipManagement_Click(object sender, EventArgs e)
        {
            // Open the ShipManagementForm
            ShipManagementForm shipForm = new ShipManagementForm();
            shipForm.Show();
        }

        // Event handler for Reports/Invoicing button
        private void btnReports_Click(object sender, EventArgs e)
        {
            // Open the ReportForm
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        // Event handler for Berth Management button
        private void btnBerthManagement_Click(object sender, EventArgs e)
        {
            // Open the BerthManagementForm
            BerthManagementForm berthForm = new BerthManagementForm();
            berthForm.Show();
        }
    }
}
