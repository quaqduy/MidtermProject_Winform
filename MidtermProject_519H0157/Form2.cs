using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidtermProject_519H0157
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            listViewCustom();
            LoadDataToListView();
            employeeList.DoubleClick += new EventHandler(employeeList_DoubleClick);
        }

        private void listViewCustom()
        {
            // Set ListView to Details mode
            employeeList.View = View.Details;
            employeeList.FullRowSelect = true;
            employeeList.GridLines = true;

            // Add columns to ListView
            employeeList.Columns.Add("ID", 50);
            employeeList.Columns.Add("Name", 200);
            employeeList.Columns.Add("Email", 250);
            employeeList.Columns.Add("Phone", 150);
            employeeList.Columns.Add("Address", 300);
            employeeList.Columns.Add("Salary", 150);
            employeeList.Columns.Add("HireDate", 300);
        }

        public void LoadDataToListView()
        {
            // SQL query to get data from Employee table
            string query = "SELECT ID, Name, Email, Phone, Address, Salary, HireDate FROM Employee";

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection

            try
            {
                // Execute the query and get the SqlDataReader using DBconnection's ExecuteReader method
                using (SqlDataReader reader = db.ExecuteReader(query))
                {
                    // Clear old items in ListView
                    employeeList.Items.Clear();

                    // Read data from SqlDataReader and add it to ListView
                    while (reader.Read())
                    {
                        // Create a ListViewItem with data from the row in the SqlDataReader
                        ListViewItem item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["Salary"].ToString());
                        item.SubItems.Add(reader["HireDate"].ToString());

                        // Add the item to ListView
                        employeeList.Items.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
            finally
            {
                db.CloseConnection(); // Ensure the connection is closed
            }
        }

        //Double click on listviewItem
        private void employeeList_DoubleClick(object sender, EventArgs e)
        {
            // Check to see if any item is selected
            if (employeeList.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = employeeList.SelectedItems[0];
                // Get employee Name
                string employeeName = selectedItem.SubItems[1].Text;

                // Display MessageBox with options
                DialogResult dialogResult = MessageBox.Show(
                    "Do you want to edit information of the employee: " + employeeName + "?",
                    "Choose an action",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Handle results from MessageBox
                if (dialogResult == DialogResult.Yes)
                {
                    EditEmployee(selectedItem);
                }
            }
        }

        private void EditEmployee(ListViewItem selectedItem)
        {
            editEmployeeForm editEmployeeForm = new editEmployeeForm();
            editEmployeeForm.Show(selectedItem);
        }

        private void delEmployeeBtn_Click(object sender, EventArgs e)
        {
            // Check to see if any items are selected
            if (employeeList.SelectedItems.Count > 0)
            {
                // Displays the confirmation dialog
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete the selected employees?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    List<string> employeeIdsToDelete = new List<string>();

                    // Browse selected items and save each employee's ID
                    foreach (ListViewItem selectedItem in employeeList.SelectedItems)
                    {
                        string employeeId = selectedItem.SubItems[0].Text; // Giả sử ID là ở cột đầu tiên
                        employeeIdsToDelete.Add(employeeId); // Thêm ID vào danh sách
                    }

                    // Delete the employees from the database
                    DeleteEmployees(employeeIdsToDelete);

                    // Remove items from ListView
                    foreach (ListViewItem selectedItem in employeeList.SelectedItems)
                    {
                        employeeList.Items.Remove(selectedItem);
                    }

                    MessageBox.Show("Selected employees have been deleted.");
                }
            }
            else
            {
                MessageBox.Show("Please select at least one employee to delete.");
            }
        }

        // Method to delete multiple employees using the existing ExecuteQuery method
        private void DeleteEmployees(List<string> ids)
        {
            // Ensure there are IDs to delete
            if (ids == null || ids.Count == 0)
            {
                MessageBox.Show("No employee IDs provided for deletion.");
                return;
            }

            // Create a delete query with parameters
            string query = "DELETE FROM Employee WHERE Id IN (" + string.Join(",", ids.Select((id, index) => $"@Id{index}")) + ")";

            // Initialize DB connection
            DBconnection db = new DBconnection(); // Create a new instance of DBconnection

            // Prepare the query parameters
            for (int i = 0; i < ids.Count; i++)
            {
                query = query.Replace($"@Id{i}", $"'{ids[i]}'");
            }

            try
            {
                // Execute the delete command using ExecuteQuery
                db.ExecuteQuery(query); // Use your existing ExecuteQuery method
            }
            catch (SqlException ex)
            {
                // Handle any SQL exceptions
                Console.WriteLine("Error while deleting employees: " + ex.Message);
                MessageBox.Show("Error while deleting employees: " + ex.Message);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            openAddForm();
        }

        //Use
        private void openAddForm()
        {
            editEmployeeForm editEmployeeForm = new editEmployeeForm();
            editEmployeeForm.Show(true);
        }
    }
}
