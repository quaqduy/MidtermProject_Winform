using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MidtermProject_519H0157
{
    public class placeOrderHandler
    {
        public ListView productList_view;
        public ListView productList_order;
        private ImageList imageList = new ImageList();
        public int count = 0; // Counter for image index
        public int maxCurrentIDPro = 0 ;
        public placeOrderHandler(ListView productList_view, ListView productList_order, TextBox totalPrice_textbox)
        {
            this.productList_view = productList_view;
            this.productList_order = productList_order;
            this.totalPrice_textbox = totalPrice_textbox;
            this.imageList.ImageSize = new Size(128, 128);
            productList_order.DoubleClick += productList_order_item_DoubleClick;
        }

        public void listProduct_view_Custom()
        {
            // Configure the ListView to use Tile view
            productList_view.View = View.LargeIcon;
            productList_view.LargeImageList = this.imageList; // Set the image list for large icons

            //For order list
            // Set ListView to Details mode
            productList_order.View = View.Details;
            productList_order.FullRowSelect = true;
            productList_order.GridLines = true;

            // Add columns to ListView
            productList_order.Columns.Add("ID", 50);
            productList_order.Columns.Add("Name", 100);
            productList_order.Columns.Add("Price", 100);
            productList_order.Columns.Add("Quantity", 100);
        }

        public void LoadProductToListView()
        {
            // SQL query to get data from product table
            string query = "SELECT ID, Name, Description, Price, Quantity FROM Product";

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection

            try
            {
                using (SqlDataReader reader = db.ExecuteReader(query)) // Gọi hàm ExecuteReader
                {
                    // Clear old items in ListView
                    productList_view.Items.Clear();

                    // Read data from SqlDataReader and add it to ListView
                    while (reader.Read()) // Read each row synchronously
                    {
                        // Create item information string from data
                        string itemInf = reader["ID"].ToString() + ": " + reader["Name"].ToString();
                        maxCurrentIDPro = Convert.ToInt32(reader["ID"].ToString()) + 1;
                        createImg(reader["ID"].ToString(), itemInf);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("File access error: " + ioEx.Message);
            }
            finally
            {
                db.CloseConnection(); // Ensure the connection is closed
            }
        }

        public void createImg(string idProd, string itemInf){
            // Get base directory and project root
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.Combine(baseDirectory, "..\\..\\");
            // Add a default image to ImageList (for items without specific images)
            string defaultImagePath = Path.Combine(projectRoot, "imgs", "productImgs", "productItem.jpg");
            ListViewItem item;

            // Check for existing image file with various extensions
            string fileNameWithoutExtension = idProd; // Get the file name base
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" }; // Supported image extensions

            bool isFileFound = false;
            foreach (string extension in imageExtensions)
            {

                string imagePath = Path.Combine(projectRoot, "imgs", "productImgs", fileNameWithoutExtension + extension); // Combine path for each extension
                if (File.Exists(imagePath)) // Check if the file exists
                {

                    using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (Image img = Image.FromStream(stream))
                        {
                            this.imageList.Images.Add((Image)img.Clone()); // Clone the image to add to ImageList

                        }
                    }

                    item = new ListViewItem(itemInf, count); // Use count as the index for the image
                    productList_view.Items.Add(item);
                    isFileFound = true;
                    break; // Exit loop if a file is found
                }
            }

            // If no image is found, use the default image
            if (!isFileFound)
            {
                using (FileStream stream = new FileStream(defaultImagePath, FileMode.Open, FileAccess.Read))
                {
                    using (Image img = Image.FromStream(stream))
                    {
                        this.imageList.Images.Add((Image)img.Clone());
                    }
                }
                item = new ListViewItem(itemInf, count); // Use count as the index for the image
                productList_view.Items.Add(item);
            }

            count++; // Increment counter for the next item
        }


        private Label productId_selected;
        private Label productName_selected;
        private TextBox quantity_order;
        public Label ProductId_selected { get => productId_selected; set => productId_selected = value; }
        public Label ProductName_selected { get => productName_selected; set => productName_selected = value; }
        public TextBox Quantity_order { get => quantity_order; set => quantity_order = value; }

        // Event handler for when an item in the ListView is selected
        public void productList_DoubleClick(object sender, EventArgs e)
        {
            if (productList_view.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = productList_view.SelectedItems[0];
                string itemText = selectedItem.Text;

                string id = "";
                string name = "";
                string[] parts = itemText.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    id = parts[0].Trim();
                    name = parts[1].Trim();
                }
                productId_selected.Text = id;
                productName_selected.Text = name;
                quantity_order.Text = "0"; // Khởi tạo số lượng về 0
            }
        }

        public List<string> quantityForModifyDB = new List<string>(); 
        public void addProductToOrder(object sender, EventArgs e)
        {
            var productID = productId_selected.Text;
            // SQL query to get data from Product table where ID matches the selected productID
            string query = "SELECT ID, Name, Description, Price, Quantity FROM Product WHERE ID = " + productID;

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection
            if (!string.IsNullOrWhiteSpace(productID))
            {
                try
                {
                    // Execute the query and get the SqlDataReader using DBconnection's ExecuteReader method
                    using (SqlDataReader reader = db.ExecuteReader(query))
                    {
                        while (reader.Read())
                        {
                            // Retrieve data from the reader
                            string name = reader["Name"].ToString();
                            string description = reader["Description"].ToString();
                            string price = reader["Price"].ToString();
                            string quantity = reader["Quantity"].ToString();
                            int orderedQuantity = int.Parse(quantity_order.Text);
                            quantityForModifyDB.Add(quantity);
                            // Check if ordered quantity is valid
                            if (orderedQuantity > int.Parse(quantity))
                            {
                                MessageBox.Show("The number of products remaining in stock is not enough!");
                                return;
                            }
                            else if (orderedQuantity == 0)
                            {
                                MessageBox.Show("Please select product quantity.");
                                return;
                            }

                            // Check if the product is already in the ListView
                            bool productExists = false;
                            int quantityOrdered = 0;
                            foreach (ListViewItem item in productList_order.Items)
                            {
                                if (item.Text == productID) // Check by product ID
                                {
                                    // Update the quantity of the existing item
                                    int currentQuantity = int.Parse(item.SubItems[3].Text);
                                    quantityOrdered = currentQuantity;
                                    if (quantityOrdered + orderedQuantity > int.Parse(quantity))
                                    {
                                        MessageBox.Show("If you add more the number of products remaining in stock is not enough!\nOnly " + (int.Parse(quantity) - currentQuantity) + " items left");
                                        productExists = true;
                                    }
                                    else
                                    {
                                        item.SubItems[3].Text = (currentQuantity + orderedQuantity).ToString(); // Update quantity
                                        productExists = true;
                                    }
                                    break;
                                }
                            }

                            // If product does not exist, add a new item to the ListView
                            if (!productExists)
                            {
                                ListViewItem item = new ListViewItem(productID);
                                item.SubItems.Add(name);
                                item.SubItems.Add(price);
                                item.SubItems.Add(orderedQuantity.ToString());

                                productList_order.Items.Add(item);
                            }
                            // Update the total price after adding/updating
                            updateTotalPrice();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); // Show error message
                }
            }
            else
            {
                MessageBox.Show("Please choose product.");
            }
        }


        private void productList_order_item_DoubleClick(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (productList_order.SelectedItems.Count > 0)
            {
                // Show confirmation dialog
                var confirmResult = MessageBox.Show("Are you sure you want to delete this item?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                // If the user confirmed, proceed with the deletion
                if (confirmResult == DialogResult.Yes)
                {
                    // Get the selected item
                    ListViewItem selectedItem = productList_order.SelectedItems[0];
                    // Perform deletion (you might want to remove it from the ListView and the database)
                    productList_order.Items.Remove(selectedItem);

                    updateTotalPrice();
                }
            }
        }
        
        private TextBox totalPrice_textbox;

        private void updateTotalPrice()
        {
            // Initialize total price
            decimal totalPrice = 0;

            // Iterate through each item in the ListView
            foreach (ListViewItem item in productList_order.Items)
            {
                // Get price and quantity from the item's subitems
                // Assuming the price is in the third subitem (index 2)
                // and the quantity is in the fourth subitem (index 3)
                if (decimal.TryParse(item.SubItems[2].Text, out decimal price) &&
                    int.TryParse(item.SubItems[3].Text, out int quantity))
                {
                    // Calculate the total for this item and add it to the total price
                    totalPrice += price * quantity;
                }
            }

            // Format the total price to include thousand separators and append " VND"
            string formattedTotalPrice = string.Format("{0:N0} VND", totalPrice).Replace(",", ".").Trim();

            // Set the total price textbox to the calculated total
            totalPrice_textbox.Text = formattedTotalPrice; // Display formatted price
        }

    }
}
