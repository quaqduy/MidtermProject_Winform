using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace MidtermProject_519H0157
{
    public class billHandler
    {
        private ListView ListBill;

        public billHandler(ListView ListBill)
        {
            this.ListBill = ListBill;
            // Set the view to Details
            ListBill.View = View.Details;

            // Clear existing columns if any
            ListBill.Columns.Clear();
            this.ListBill.FullRowSelect = true; // Selects the entire row

            // Add columns with appropriate headers and widths
            ListBill.Columns.Add("Order ID", 100);
            ListBill.Columns.Add("Client ID", 100);
            ListBill.Columns.Add("Employee ID", 100);
            ListBill.Columns.Add("Bill Date", 300);
            ListBill.Columns.Add("Total Price", 300);
        }

        public void loadDataToListBill()
        {
            // Clear existing items in the ListView
            ListBill.Items.Clear();

            // Use the DBconnection class to manage the connection
            DBconnection db = new DBconnection();

            // SQL query to select all bills
            string query = "SELECT OrderID, ClientID, EmployeeID, BillDate, TotalPrice FROM Bill";

            try
            {
                using (SqlCommand command = new SqlCommand(query, db.OpenConnection()))
                {
                    // Execute the command and read data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read each row from the SqlDataReader
                        while (reader.Read())
                        {
                            // Create a new ListViewItem for each bill
                            ListViewItem item = new ListViewItem(reader["OrderID"].ToString())
                            {
                                // Optional: Set the item color based on conditions (e.g., high total price)
                                ForeColor = decimal.Parse(reader["TotalPrice"].ToString()) > 1000 ? Color.Red : Color.Black
                            };

                            // Add sub-items
                            item.SubItems.Add(reader["ClientID"].ToString());
                            item.SubItems.Add(reader["EmployeeID"].ToString());
                            item.SubItems.Add(Convert.ToDateTime(reader["BillDate"]).ToString("yyyy-MM-dd HH:mm:ss")); // Format date

                            // Format TotalPrice as VND
                            var vndCulture = new CultureInfo("vi-VN"); // Set culture to Vietnamese
                            item.SubItems.Add(decimal.Parse(reader["TotalPrice"].ToString()).ToString("C0", vndCulture)); // Format price as VND

                            // Add the item to the ListView
                            ListBill.Items.Add(item);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading bill data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection(); // Ensure the connection is closed
            }
        }
    }

}
