using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProject_519H0157
{
    public class placeOrderHandler
    {
        private ListView productList_view;
        private ImageList imageList = new ImageList();
        public placeOrderHandler(ListView productList_view)
        {
            this.productList_view = productList_view;

            this.imageList.ImageSize = new Size(128, 128);
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.Combine(baseDirectory, "..\\..\\");
            string imagePath = Path.Combine(projectRoot, "imgs", "productItem.png");
            this.imageList.Images.Add(Image.FromFile(imagePath));
        }

        public void listProduct_view_Custom()
        {
            // Configure the ListView to use Tile view
            productList_view.View = View.LargeIcon;
            productList_view.LargeImageList = this.imageList; // Set the image list for large icons
        }

        public async void LoadProductToListView()
        {
            // SQL query to get data from product table
            string query = "SELECT ID, Name, Description, Price, Quantity FROM Product";

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection

            try
            {
                // Execute the query and get the SqlDataReader using DBconnection's ExecuteReader method
                using (SqlDataReader reader = db.ExecuteReader(query))
                {
                    // Clear old items in ListView
                    productList_view.Items.Clear();

                    // Read data from SqlDataReader and add it to ListView
                    while (await reader.ReadAsync())
                    {
                        // Create a ListViewItem with data from the row in the SqlDataReader

                        // Add items with icons
                        string itemInf = reader["ID"].ToString() + ": " + reader["Name"].ToString();
                        ListViewItem item = new ListViewItem(itemInf, 0);

                        // Add the item to ListView
                        productList_view.Items.Add(item);
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
    }
}
