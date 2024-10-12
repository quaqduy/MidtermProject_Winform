using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MidtermProject_519H0157
{
    public partial class editEmployeeForm : Form
    {
        public editEmployeeForm()
        {
            InitializeComponent();
        }

        public void Show(ListViewItem selectedItem)
        {
            idEmployee.Text = selectedItem.SubItems[0].Text;
            nameEmployee.Text = selectedItem.SubItems[1].Text;
            emailEmployee.Text = selectedItem.SubItems[2].Text;
            phoneEmployee.Text = selectedItem.SubItems[3].Text;
            addressEmployee.Text = selectedItem.SubItems[4].Text;
            salaryEmployee.Text = selectedItem.SubItems[5].Text;
            hireDateEmployee.Text = selectedItem.SubItems[6].Text; 

            this.ShowDialog();
        }

        public void Show(Boolean forAdd) {
            if (forAdd) {
                //Ready for addForm
                titleForm.Text = "Add Form";
                saveEmployeeBtn.Visible = false;
                idEmployee.Visible = false;
                label2.Visible = false;
                addBtn.Visible = true;

                this.ShowDialog();
            }
        }

        private void editEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void saveEmployeeBtn_Click(object sender, EventArgs e)
        {
            // Displays the confirmation dialog
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to update the employee information?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Check the results from the dialog box
            if (dialogResult == DialogResult.Yes)
            {
                // If the user selects Yes, perform the update
                UpdateEmployee(
                    idEmployee.Text,
                    nameEmployee.Text,
                    emailEmployee.Text,
                    phoneEmployee.Text,
                    addressEmployee.Text,
                    salaryEmployee.Text,
                    hireDateEmployee.Text
                );

                // Notify the user that the update was successful
                // Reload the data into the ListView in the main Form (DashBoard)
                DashBoard dashBoard = (DashBoard)Application.OpenForms["DashBoard"]; // Get instance of DashBoard
                if (dashBoard != null)
                {
                    dashBoard.LoadDataToListView(); // Call the method to reload data
                }

                // Close the edit form after updating
                this.Close();
            }
            else
            {
                // If the user selects No, do nothing and may notify
                MessageBox.Show("Update canceled.");
            }
        }
        private void UpdateEmployee(string id, string name, string email, string phone, string address, string salary, string hireDate)
        {
            // Connect to the database and perform updates
            using (SqlConnection conn = new SqlConnection(@"Data Source=QUAQDUY;Initial Catalog=PiStoreDB;Integrated Security=True"))
            {
                string query = "UPDATE Employee SET " +
                    "Name = @Name, " +
                    "Email = @Email, " +
                    "Phone = @Phone, " +
                    "Address = @Address, " +
                    "Salary = @Salary, " +
                    "HireDate = @HireDate " +
                    "WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@HireDate", hireDate);

                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Get information from input fields
            string name = nameEmployee.Text;
            string email = emailEmployee.Text;
            string phone = phoneEmployee.Text;
            string address = addressEmployee.Text;
            string salary = salaryEmployee.Text;
            string hireDateString = hireDateEmployee.Text;

            // Check if all fields are filled
            if (!AreFieldsValid(name, email, phone, address, salary, hireDateString))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Convert hire date string to DateTime
            DateTime hireDate;
            if (!TryParseHireDate(hireDateString, out hireDate))
            {
                MessageBox.Show("Invalid hire date format. Please use a valid date format.");
                return;
            }

            // Create SQL command to add employee
            string query = "INSERT INTO Employee (Name, Email, Phone, Address, Salary, HireDate) " +
                           "VALUES (@Name, @Email, @Phone, @Address, @Salary, @HireDate)";

            // Use DBconnection class to execute the command
            DBconnection db = new DBconnection();
            try
            {
                db.OpenConnection();
                AddEmployeeToDatabase(db, query, name, email, phone, address, salary, hireDate);
                MessageBox.Show("Employee added successfully!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            // Clear fields after successful addition
            ClearFields();

            // Notify the user that the update was successful
            ReloadDashBoard();

            // Close the edit form after updating
            this.Close();
        }

        // Method to check if all fields are filled
        private bool AreFieldsValid(string name, string email, string phone, string address, string salary, string hireDateString)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                   !string.IsNullOrWhiteSpace(email) &&
                   !string.IsNullOrWhiteSpace(phone) &&
                   !string.IsNullOrWhiteSpace(address) &&
                   !string.IsNullOrWhiteSpace(salary) &&
                   !string.IsNullOrWhiteSpace(hireDateString);
        }

        // Method to try parsing the hire date
        private bool TryParseHireDate(string hireDateString, out DateTime hireDate)
        {
            return DateTime.TryParse(hireDateString, out hireDate);
        }

        // Method to add employee to the database
        private void AddEmployeeToDatabase(DBconnection db, string query, string name, string email, string phone, string address, string salary, DateTime hireDate)
        {
            using (SqlCommand command = new SqlCommand(query, db.OpenConnection()))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@HireDate", hireDate);
                command.ExecuteNonQuery();
            }
        }

        // Method to clear input fields
        private void ClearFields()
        {
            nameEmployee.Clear();
            emailEmployee.Clear();
            phoneEmployee.Clear();
            addressEmployee.Clear();
            salaryEmployee.Clear();
            hireDateEmployee.Clear();
        }

        // Method to reload the DashBoard
        private void ReloadDashBoard()
        {
            DashBoard dashBoard = (DashBoard)Application.OpenForms["DashBoard"]; // Get instance of DashBoard
            if (dashBoard != null)
            {
                dashBoard.LoadDataToListView(); // Call the method to reload data
            }
        }

    }
}
