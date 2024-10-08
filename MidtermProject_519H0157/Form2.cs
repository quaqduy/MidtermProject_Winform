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
        private string connectionString = @"Data Source=QUAQDUY;Initial Catalog=PiStoreDB;Integrated Security=True";
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

            // Create connections and execute queries
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); 

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Delete old items in ListView
                            employeeList.Items.Clear();

                            // Read data from SqlDataReader and pour it into ListView
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
                                // Add items to ListView
                                employeeList.Items.Add(item);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message);
                }
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

        // Method to delete multiple employees
        private void DeleteEmployees(List<string> ids)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=QUAQDUY;Initial Catalog=PiStoreDB;Integrated Security=True"))
            {
                conn.Open();

                // Create a delete query with multiple IDs
                string query = "DELETE FROM Employee WHERE Id IN (" + string.Join(",", ids.Select(id => $"'{id}'")) + ")";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery(); // Execute the delete command
                }
            }
        }

    }
}
