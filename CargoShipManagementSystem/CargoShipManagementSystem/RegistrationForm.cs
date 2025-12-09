using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CargoShipManagementSystem
{
    public partial class RegistrationForm : Form
    {
        // Connection string loaded from App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["CargoShipDB"].ConnectionString;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            // Initialize role combo box
            cmbRole.Items.Add("Viewer");
            cmbRole.Items.Add("Operator");
            cmbRole.Items.Add("Manager");
            cmbRole.SelectedIndex = 0; // Default to Viewer
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "Viewer";

            // Validation
            if (string.IsNullOrEmpty(username))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Username is required.";
                return;
            }

            if (username.Length < 4)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Username must be at least 4 characters.";
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Password is required.";
                return;
            }

            if (password.Length < 6)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Password must be at least 6 characters.";
                return;
            }

            if (password != confirmPassword)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Full Name is required.";
                return;
            }

            // Email validation (basic)
            if (!string.IsNullOrEmpty(email) && !email.Contains("@"))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a valid email address.";
                return;
            }

            // Try to register the user
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if username already exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", username);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Username already exists. Please choose another.";
                            return;
                        }
                    }

                    // Insert new user
                    string insertQuery = @"INSERT INTO Users (Username, PasswordHash, Role, FullName, Email, IsActive, CreatedAt) 
                                          VALUES (@Username, @PasswordHash, @Role, @FullName, @Email, 1, GETDATE())";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Username", username);
                        insertCommand.Parameters.AddWithValue("@PasswordHash", password); // In production, hash this!
                        insertCommand.Parameters.AddWithValue("@Role", role);
                        insertCommand.Parameters.AddWithValue("@FullName", fullName);
                        insertCommand.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "Registration successful! You can now login.";

                            // Clear form after 2 seconds and close
                            System.Threading.Timer timer = null;
                            timer = new System.Threading.Timer((obj) =>
                            {
                                this.Invoke(new Action(() =>
                                {
                                    this.Close();
                                }));
                                timer?.Dispose();
                            }, null, 2000, System.Threading.Timeout.Infinite);
                        }
                        else
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Registration failed. Please try again.";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Database Error: " + ex.Message;
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            // Show password match indicator
            if (txtPassword.Text.Length > 0 && txtConfirmPassword.Text.Length > 0)
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    lblPasswordMatch.ForeColor = System.Drawing.Color.Green;
                    lblPasswordMatch.Text = "✓ Passwords match";
                }
                else
                {
                    lblPasswordMatch.ForeColor = System.Drawing.Color.Red;
                    lblPasswordMatch.Text = "✗ Passwords do not match";
                }
            }
            else
            {
                lblPasswordMatch.Text = "";
            }
        }
    }
}
