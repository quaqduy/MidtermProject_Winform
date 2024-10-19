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
    public partial class editForm : Form
    {
        private string typeForm = "";
        public editForm()
        {
            InitializeComponent();
        }

        public void Show(ListViewItem selectedItem, string type)
        {
            idEmployee.Text = selectedItem.SubItems[0].Text;
            nameEmployee.Text = selectedItem.SubItems[1].Text;
            emailEmployee.Text = selectedItem.SubItems[2].Text;
            phoneEmployee.Text = selectedItem.SubItems[3].Text;
            addressEmployee.Text = selectedItem.SubItems[4].Text;
            if(type == "employee")
            {
                typeForm = "employee";

                salaryEmployee.Text = selectedItem.SubItems[5].Text;
                hireDateEmployee.Text = selectedItem.SubItems[6].Text;
            }else if (type == "client")
            {
                typeForm = "client";

                ready_For_addClientForm();
                label2.Visible = true;
                idEmployee.Visible = true;
                saveEmployeeBtn.Visible = true;
                addBtn.Visible = false;
                saveEmployeeBtn.Location = new Point(saveEmployeeBtn.Location.X, saveEmployeeBtn.Location.Y - 70);
                idEmployee.Location = new Point(idEmployee.Location.X, idEmployee.Location.Y - 70);
                label2.Location = new Point(label2.Location.X, label2.Location.Y - 70);
            }

            this.ShowDialog();
        }

        private void ready_For_addEmployeeForm()
        {
            saveEmployeeBtn.Visible = false;
            idEmployee.Visible = false;
            label2.Visible = false;
            addBtn.Visible = true;
            typeForm = "employee";
        }

        private void ready_For_addClientForm()
        {
            salary_label.Visible = false;
            hireDate_label.Visible = false;
            hireDateEmployee.Visible = false;
            salaryEmployee.Visible = false;
            dateFomart.Visible = false;
            addBtn.Location = new Point(addBtn.Location.X, addBtn.Location.Y - 70);
            label2.Visible = false;
            idEmployee.Visible = false;
            saveEmployeeBtn.Visible = false;
            addBtn.Visible = true;
            typeForm = "client";
        }

        public void Show(Boolean forAdd, string type) {
            if (forAdd) {

                switch(type)
                {
                    case "employee":
                        //Ready for addEmployeeForm
                        titleForm.Text = "Add Form";
                        ready_For_addEmployeeForm();
                        this.ShowDialog();
                        break;
                    case "client":
                        //Ready for addClientForm
                        titleForm.Text = "Add Form";
                        ready_For_addClientForm();
                        this.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
        }

        private void editEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void saveEmployeeBtn_Click(object sender, EventArgs e)
        {
            // Displays the confirmation dialog
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to update the "+this.typeForm+" information?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Check the results from the dialog box
            if (dialogResult == DialogResult.Yes)
            {
                // If the user selects Yes, perform the update
                if(typeForm == "employee")
                {
                    UpdateEmployee(
                        idEmployee.Text,
                        nameEmployee.Text,
                        emailEmployee.Text,
                        phoneEmployee.Text,
                        addressEmployee.Text,
                        salaryEmployee.Text,
                        hireDateEmployee.Text
                    );
                }else if(typeForm == "client")
                {
                    UpdateClient(
                        idEmployee.Text,
                        nameEmployee.Text,
                        emailEmployee.Text,
                        phoneEmployee.Text,
                        addressEmployee.Text
                    );
                }
                

                // Notify the user that the update was successful
                // Reload the data into the ListView in the main Form (DashBoard)
                DashBoard dashBoard = (DashBoard)Application.OpenForms["DashBoard"]; // Get instance of DashBoard

                if (dashBoard != null)
                {
                    dashBoard.employeeHandler.LoadDataToEmployeeListView(); // Call the method to reload data
                    dashBoard.clientHandler.LoadDataToClientListView(); // Call the method to reload data
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

        private void UpdateClient(string id, string name, string email, string phone, string address)
        {
            // Connect to the database and perform updates
            using (SqlConnection conn = new SqlConnection(@"Data Source=QUAQDUY;Initial Catalog=PiStoreDB;Integrated Security=True"))
            {
                string query = "UPDATE Client SET " +
                    "Name = @Name, " +
                    "Email = @Email, " +
                    "Phone = @Phone, " +
                    "Address = @Address " +
                    "WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);

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

            // Create SQL command to add employee
            string query = "";
            DateTime hireDate = new DateTime();

            // Convert hire date string to DateTime
            if (typeForm == "employee")
            {
                if (!TryParseHireDate(hireDateString, out hireDate))
                {
                    MessageBox.Show("Invalid hire date format. Please use a valid date format.");
                    return;
                }

                query = "INSERT INTO Employee (Name, Email, Phone, Address, Salary, HireDate) " +
                           "VALUES (@Name, @Email, @Phone, @Address, @Salary, @HireDate)";
            }else if (typeForm == "client")
            {
                query = "INSERT INTO Client (Name, Email, Phone, Address) " +
                           "VALUES (@Name, @Email, @Phone, @Address)";
            }

            // Use DBconnection class to execute the command
            DBconnection db = new DBconnection();
            try
            {
                db.OpenConnection();
                if (typeForm == "employee")
                {
                    AddEmployeeToDatabase(db, query, name, email, phone, address, salary, hireDate);
                    MessageBox.Show("Employee added successfully!");
                }else if(typeForm == "client")
                {
                    AddEmployeeToDatabase(db, query, name, email, phone, address, salary, hireDate);
                    MessageBox.Show("Client added successfully!");
                }
                
            }
            catch (SqlException ex)
            {
                if (typeForm == "employee")
                {
                    MessageBox.Show("Error adding employee: " + ex.Message);
                }
                else if (typeForm == "client")
                {
                    MessageBox.Show("Error adding client: " + ex.Message);
                }
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
            if (typeForm == "employee")
            {
                return !string.IsNullOrWhiteSpace(name) &&
                       !string.IsNullOrWhiteSpace(email) &&
                       !string.IsNullOrWhiteSpace(phone) &&
                       !string.IsNullOrWhiteSpace(address) &&
                       !string.IsNullOrWhiteSpace(salary) &&
                       !string.IsNullOrWhiteSpace(hireDateString);
            }
            else if (typeForm == "client")
            {
                return !string.IsNullOrWhiteSpace(name) &&
                       !string.IsNullOrWhiteSpace(email) &&
                       !string.IsNullOrWhiteSpace(phone) &&
                       !string.IsNullOrWhiteSpace(address);
            }

            // Return false if typeForm is neither "employee" nor "client"
            return false;
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
                if (typeForm == "employee")
                {
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@HireDate", hireDate);
                }
                
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
                // Call the method to reload data
                dashBoard.employeeHandler.LoadDataToEmployeeListView(); 
                dashBoard.clientHandler.LoadDataToClientListView();
            }
        }

    }
}
