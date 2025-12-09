using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CargoShipManagementSystem
{
    public partial class LoginForm : Form
    {
        // Connection string loaded from App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["CargoShipDB"].ConnectionString;

        public LoginForm()
        {
            InitializeComponent();
        }

        // Event handler for the Login button click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim(); // In real app, this would be hashed

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both username and password.";
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserID, Username, Role, PasswordHash FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash"; // Simplified for demo
                    // In a real application, you would:
                    // 1. Retrieve the stored hashed password for @Username
                    // 2. Hash the provided 'password' input
                    // 3. Compare the two hashes

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PasswordHash", password); // Simplified, replace with proper hashing in real app

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Login successful
                                lblMessage.Text = "Login Successful!";
                                this.Hide(); // Hide the login form

                                // Pass user role or ID to the Dashboard (if needed for permissions)
                                string userRole = reader["Role"].ToString();
                                int userId = Convert.ToInt32(reader["UserID"]);

                                DashboardForm dashboard = new DashboardForm(userId, userRole);
                                dashboard.FormClosed += (s, args) => this.Close(); // When Dashboard closes, close the app
                                dashboard.Show();
                            }
                            else
                            {
                                // Login failed
                                lblMessage.Text = "Invalid Username or Password.";
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                lblMessage.Text = "Database Error: " + ex.Message;
                // Log the exception for debugging purposes
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An unexpected error occurred: " + ex.Message;
                // Log the exception
                Console.WriteLine("General Error: " + ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization needed when the form loads
            lblMessage.Text = ""; // Clear any message on load
        }

        // Event handler for Register button click
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog(); // Show as modal dialog
        }
    }
}
