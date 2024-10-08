using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MidtermProject_519H0157
{
    public partial class loginForm : Form
    {

        private Rectangle screenSize = Screen.PrimaryScreen.Bounds;                 // Get the dimensions of the primary screen
        SqlConnection conn = new SqlConnection(
            @"Data Source=QUAQDUY;Initial Catalog=PiStoreDB;Integrated Security=True"
        );


        public loginForm()
        {
            InitializeComponent();

            //View handle
            CenterLabel(lblTitle, 85); // Center title label
            CenterTextbox(txtEmail,280); // Center message label
            CenterTextbox(txtPassword, 310); // Center message label
            CenterLabel(lblMessage, 340); // Center message label
            CenterBtn(btnLogin, 360); // Center message label
            placeHolderTextBox(txtEmail, "Enter your email");
            placeHolderTextBox(txtPassword, "Enter your password");
            //hide msg
            lblMessage.Visible = false;
        }

        private void CenterLabel(Label label, int height)
        {
            // Calculate the center position
            int x = (screenSize.Width - label.Width) / 2 - 500; // Center X
            int y = height; // Center Y
            label.Location = new Point(x, y);
        }

        private void CenterTextbox(TextBox textBox, int height)
        {
            // Calculate the center position
            int x = (screenSize.Width - textBox.Width) / 2 - 500; // Center X
            int y = height; // Center Y
            textBox.Location = new Point(x, y);
        }
        private void CenterBtn(Button btn, int height)
        {
            // Calculate the center position
            int x = (screenSize.Width - btn.Width) / 2 - 500; // Center X
            int y = height; // Center Y
            btn.Location = new Point(x, y);
        }

        private void SetFontSizes()
        {
            // Set font size for controls
            lblTitle.Font = new Font("Ink Free", 50, FontStyle.Bold); // Title label
            txtEmail.Font = new Font("Arial", 30); // Username textbox
            txtPassword.Font = new Font("Arial", 30); // Password textbox
            btnLogin.Font = new Font("Arial", 30); // Login button
            lblMessage.Font = new Font("Arial", 20); // Message label
        }

        private void placeHolderTextBox(TextBox textBox, string text)
        {
            // Initialize the placeholder label
            textBox.Text = text;
            textBox.ForeColor = Color.Gray; // Set placeholder text color
            textBox.BringToFront(); // Ensure label is in front of textbox
            textBox.Visible = true; // Show placeholder initially
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter your email")
            {
                txtEmail.Text = ""; // Clear the placeholder when focused
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your password")
            {
                txtPassword.Text = ""; // Clear the placeholder when focused
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string msg = loginAuth(txtEmail, txtPassword);
            if (!string.IsNullOrEmpty(msg))
            {
                lblMessage.Visible = true;
                lblMessage.Text = msg;
            }

            MessageBox.Show("Sucess to login ");
        }

        public string loginAuth(TextBox txtEmail, TextBox txtPassword)
        {
            string patternPassword = @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{8,}$"; // Regex pattern
            string patternemail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; // Regex pattern
            
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string msg = "";
            if (string.IsNullOrEmpty(email))
            {
                msg = "Please enter email";
            }
            else if (string.IsNullOrEmpty(password))
            {
                msg = "Please enter password";
            }
            else if (!Regex.IsMatch(email, patternemail))
            {
                msg = "Invalid email format.";
            }
            else if (!Regex.IsMatch(password, patternPassword))
            {
                msg = "Invalid password format.";
            }
            else if(!checkedAccountDB(email, password))
            {
                msg = "Your email or password is incorrect !!";
            }

            return msg;
        }

        private Boolean checkedAccountDB(string email, string password)
        {
            // Hash the provided password
            string hashedPassword = HashPassword(password).ToUpper(); // Use the hashing method defined earlier

            // Prepare the SQL query
            string query = "SELECT COUNT(*) FROM Account WHERE Email = @Email AND Password = @Password"; // Ensure the table name and fields are correct

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", hashedPassword); // Use the hashed password for comparison

                try
                {
                    conn.Open(); // Open the connection

                    int count = (int)command.ExecuteScalar(); // Execute the query and get the result
                    return count > 0; // Return true if a matching record exists
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close(); // Ensure the connection is closed
                }
            }
        }

        //Hash
        private string HashPassword(string password)
        {
            // Use SHA256 hashing
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                // Convert the password string to a byte array and compute the hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert byte to hex string
                }

                return builder.ToString(); // Return the hashed password
            }
        }

    }
}
