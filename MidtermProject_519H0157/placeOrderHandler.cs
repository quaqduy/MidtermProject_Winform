using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MidtermProject_519H0157
{
    public class placeOrderHandler
    {
        public ListView productList_view;
        private ImageList imageList = new ImageList();
        public int count = 0; // Counter for image index
        public int maxCurrentIDPro = 0 ;
        public placeOrderHandler(ListView productList_view)
        {
            this.productList_view = productList_view;

            this.imageList.ImageSize = new Size(128, 128);
        }

        public void listProduct_view_Custom()
        {
            // Configure the ListView to use Tile view
            productList_view.View = View.LargeIcon;
            productList_view.LargeImageList = this.imageList; // Set the image list for large icons
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
    }
}
