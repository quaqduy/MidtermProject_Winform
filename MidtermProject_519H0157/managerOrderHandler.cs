using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace MidtermProject_519H0157
{
    public class managerOrderHandler
    {
        private ListView orderList_manager;
        private ListView detailOrder;
        private ListView LO_product_list;
        private billHandler billHandler;
        public managerOrderHandler(ListView orderList_manager, ListView detailOrder, ListView LO_product_list, billHandler billHandler)
        {
            this.orderList_manager = orderList_manager;
            this.detailOrder = detailOrder;
            this.LO_product_list = LO_product_list;
            this.billHandler = billHandler;
        }

        public void listViewOrderCustom()
        {
            // Set ListView to Details mode
            orderList_manager.View = View.Details;
            orderList_manager.FullRowSelect = true;
            orderList_manager.GridLines = true;

            // Add columns to ListView
            orderList_manager.Columns.Add("ID", 50);
            orderList_manager.Columns.Add("ClientID", 200);
            orderList_manager.Columns.Add("EmployeeID", 200);
            orderList_manager.Columns.Add("OrderDate", 200);
            orderList_manager.Columns.Add("TotalPrice", 350);

            // Set ListView to Details mode
            detailOrder.View = View.Details;
            detailOrder.FullRowSelect = true;
            detailOrder.GridLines = true;

            // Add columns to ListView
            detailOrder.Columns.Add("ProductID", 150);
            detailOrder.Columns.Add("ProductName", 200);
            detailOrder.Columns.Add("Quantity", 200);

            // Set ListView to Details mode
            LO_product_list.View = View.Details;
            LO_product_list.FullRowSelect = true;
            LO_product_list.GridLines = true;

            // Add columns to ListView
            LO_product_list.Columns.Add("ProductID", 150);
            LO_product_list.Columns.Add("ProductName", 200);
            LO_product_list.Columns.Add("Quantity", 200);
        }

        public void loadData(Label LO_idLable, Label LO_clientIDLable, Label LO_employeeIDLable, 
            Label LO_orderDateLable, Label LO_totalPriceLable)
        {
            loadData_to_OrderList();
            LastOrderDeltail(LO_idLable, LO_clientIDLable, LO_employeeIDLable, LO_orderDateLable, LO_totalPriceLable, false);
            orderList_manager.Click += eventClick_Item_in_OrderList;
        }

        private void loadData_to_OrderList()
        {
            // SQL query to get data from product table
            string query = "SELECT ID, ClientID, EmployeeID, OrderDate, TotalPrice FROM [Order]";

            // Using the DBconnection class to manage the connection
            DBconnection db = new DBconnection(); // Initialize connection through DBconnection

            try
            {
                using (SqlDataReader reader = db.ExecuteReader(query)) // Gọi hàm ExecuteReader
                {
                    // Clear old items in ListView
                    orderList_manager.Items.Clear();

                    // Read data from SqlDataReader and add it to ListView
                    while (reader.Read()) // Read each row synchronously
                    {
                        // Create a ListViewItem with data from the row in the SqlDataReader
                        ListViewItem item = new ListViewItem(reader["ID"].ToString());
                        item.SubItems.Add(reader["ClientID"].ToString());
                        item.SubItems.Add(reader["EmployeeID"].ToString());
                        item.SubItems.Add(reader["OrderDate"].ToString());
                        item.SubItems.Add(reader["TotalPrice"].ToString());

                        LO_idLable_text = reader["ID"].ToString();
                        LO_clientIDLable_text = reader["ClientID"].ToString();
                        LO_employeeIDLable_text = reader["EmployeeID"].ToString();
                        LO_orderDateLable_text = reader["OrderDate"].ToString();
                        LO_totalPriceLable_text = reader["TotalPrice"].ToString();

                        // Add the item to ListView
                        orderList_manager.Items.Add(item);
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

        private string LO_idLable_text = "";
        private string LO_clientIDLable_text = "";
        private string LO_employeeIDLable_text = "";
        private string LO_orderDateLable_text = "";
        private string LO_totalPriceLable_text = "";

        private void LastOrderDeltail(Label LO_idLable, Label LO_clientIDLable,
            Label LO_employeeIDLable, Label LO_orderDateLable, Label LO_totalPriceLable, bool isClick)
        {
            LO_idLable.Text = LO_idLable_text;
            LO_clientIDLable.Text = LO_clientIDLable_text;
            LO_employeeIDLable.Text = LO_employeeIDLable_text;
            LO_orderDateLable.Text = LO_orderDateLable_text;
            LO_totalPriceLable.Text = LO_totalPriceLable_text;

            // SQL query to fetch products from OrderItem table based on OrderID
            string queryOrderItem = "SELECT ProductID, Quantity FROM OrderItem WHERE OrderID = @OrderID";
            // SQL query to get product details from Product table based on ProductID
            string queryProduct = "SELECT Name FROM Product WHERE ID = @ProductID";
            // Using DBconnection to manage the connection
            DBconnection db = new DBconnection();

            try
            {
                db.OpenConnection();

                List<Tuple<string, string>> productData = new List<Tuple<string, string>>();

                // Fetch product details from OrderItem based on OrderID
                using (SqlCommand commandOrderItem = new SqlCommand(queryOrderItem, db.OpenConnection()))
                {
                    commandOrderItem.Parameters.AddWithValue("@OrderID", int.Parse(LO_idLable.Text));

                    using (SqlDataReader readerOrderItem = commandOrderItem.ExecuteReader())
                    {
                        while (readerOrderItem.Read())
                        {
                            string productId = readerOrderItem["ProductID"].ToString();
                            string quantity = readerOrderItem["Quantity"].ToString();

                            // Store the productId and quantity to use after closing the reader
                            productData.Add(new Tuple<string, string>(productId, quantity));
                        }
                    }
                }

                // Clear old items in the detailOrder ListView before adding new ones
                LO_product_list.Items.Clear();

                // Fetch product name from the Product table based on each ProductID
                foreach (var product in productData)
                {
                    using (SqlCommand commandProduct = new SqlCommand(queryProduct, db.OpenConnection()))
                    {
                        commandProduct.Parameters.AddWithValue("@ProductID", product.Item1);

                        using (SqlDataReader readerProduct = commandProduct.ExecuteReader())
                        {
                            if (readerProduct.Read()) // Ensure the product exists
                            {
                                string productName = readerProduct["Name"].ToString();
                                string quantity = product.Item2;

                                // Create a new ListViewItem with data from both queries
                                ListViewItem item = new ListViewItem(product.Item1);
                                item.SubItems.Add(productName);
                                item.SubItems.Add(quantity);

                                // Add the item to the detailOrder ListView
                                LO_product_list.Items.Add(item);
                            }
                        }
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

        private void eventClick_Item_in_OrderList(object sender, EventArgs e)
        {
            if (orderList_manager.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = orderList_manager.SelectedItems[0];
                string orderId = selectedItem.SubItems[0].Text;

                // SQL query to fetch products from OrderItem table based on OrderID
                string queryOrderItem = "SELECT ProductID, Quantity FROM OrderItem WHERE OrderID = @OrderID";
                // SQL query to get product details from Product table based on ProductID
                string queryProduct = "SELECT Name FROM Product WHERE ID = @ProductID";

                // Using DBconnection to manage the connection
                DBconnection db = new DBconnection();

                try
                {
                    db.OpenConnection();

                    List<Tuple<string, string>> productData = new List<Tuple<string, string>>();

                    // Fetch product details from OrderItem based on OrderID
                    using (SqlCommand commandOrderItem = new SqlCommand(queryOrderItem, db.OpenConnection()))
                    {
                        commandOrderItem.Parameters.AddWithValue("@OrderID", orderId);

                        using (SqlDataReader readerOrderItem = commandOrderItem.ExecuteReader())
                        {
                            while (readerOrderItem.Read())
                            {
                                string productId = readerOrderItem["ProductID"].ToString();
                                string quantity = readerOrderItem["Quantity"].ToString();

                                // Store the productId and quantity to use after closing the reader
                                productData.Add(new Tuple<string, string>(productId, quantity));
                            }
                        }
                    }

                    // Clear old items in the detailOrder ListView before adding new ones
                    detailOrder.Items.Clear();

                    // Fetch product name from the Product table based on each ProductID
                    foreach (var product in productData)
                    {
                        using (SqlCommand commandProduct = new SqlCommand(queryProduct, db.OpenConnection()))
                        {
                            commandProduct.Parameters.AddWithValue("@ProductID", product.Item1);

                            using (SqlDataReader readerProduct = commandProduct.ExecuteReader())
                            {
                                if (readerProduct.Read()) // Ensure the product exists
                                {
                                    string productName = readerProduct["Name"].ToString();
                                    string quantity = product.Item2;

                                    // Create a new ListViewItem with data from both queries
                                    ListViewItem item = new ListViewItem(product.Item1);
                                    item.SubItems.Add(productName);
                                    item.SubItems.Add(quantity);

                                    // Add the item to the detailOrder ListView
                                    detailOrder.Items.Add(item);
                                }
                            }
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




        public void generateBill(object sender, EventArgs e)
        {
            createBill();
            billHandler.loadDataToListBill();
            GeneratePdf(LO_idLable_text, LO_clientIDLable_text, LO_employeeIDLable_text, DateTime.Now, LO_totalPriceLable_text);
        }

        private void createBill()
        {
            string OrderID = LO_idLable_text;
            string ClientID = LO_clientIDLable_text;
            string EmployeeID = LO_employeeIDLable_text;
            DateTime BillDate = DateTime.Now;
            string TotalPrice = LO_totalPriceLable_text;

            DBconnection db = new DBconnection();

            try
            {
                // Kiểm tra xem có hóa đơn với OrderID đã tồn tại hay không
                string checkQuery = "SELECT COUNT(*) FROM Bill WHERE OrderID = @OrderID";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, db.OpenConnection()))
                {
                    checkCommand.Parameters.AddWithValue("@OrderID", OrderID);
                    int count = (int)checkCommand.ExecuteScalar(); // Sử dụng ExecuteScalar để lấy giá trị đầu tiên

                    if (count > 0)
                    {
                        // Nếu đã tồn tại, thực hiện cập nhật hóa đơn
                        string updateQuery = "UPDATE Bill SET ClientID = @ClientID, EmployeeID = @EmployeeID, " +
                                             "BillDate = @BillDate, TotalPrice = @TotalPrice WHERE OrderID = @OrderID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, db.OpenConnection()))
                        {
                            updateCommand.Parameters.AddWithValue("@ClientID", ClientID);
                            updateCommand.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                            updateCommand.Parameters.AddWithValue("@BillDate", BillDate);
                            updateCommand.Parameters.AddWithValue("@TotalPrice", decimal.Parse(TotalPrice));
                            updateCommand.Parameters.AddWithValue("@OrderID", OrderID);

                            updateCommand.ExecuteNonQuery();
                            MessageBox.Show("Bill updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Nếu chưa tồn tại, thực hiện thêm hóa đơn mới
                        string insertQuery = "INSERT INTO Bill (OrderID, ClientID, EmployeeID, BillDate, TotalPrice) " +
                                             "VALUES (@OrderID, @ClientID, @EmployeeID, @BillDate, @TotalPrice)";

                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, db.OpenConnection()))
                        {
                            insertCommand.Parameters.AddWithValue("@OrderID", OrderID);
                            insertCommand.Parameters.AddWithValue("@ClientID", ClientID);
                            insertCommand.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                            insertCommand.Parameters.AddWithValue("@BillDate", BillDate);
                            insertCommand.Parameters.AddWithValue("@TotalPrice", decimal.Parse(TotalPrice));

                            insertCommand.ExecuteNonQuery();
                            MessageBox.Show("Bill created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while creating/updating the bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection(); // Đảm bảo kết nối được đóng sau khi thực hiện
            }
        }

        public string GeneratePdf(string orderId, string clientId, string employeeId, DateTime billDate, string totalPrice)
        {
            string fileName = $"Bill_{orderId}.pdf"; // PDF file name
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Use PdfSharp PdfDocument
            using (PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument())
            {
                var page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Set fonts
                XFont headerFont = new XFont("Arial Bold", 18); // Specify a bold font directly
                XFont regularFont = new XFont("Arial", 12);

                // Add title
                gfx.DrawString("Bill Information", headerFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopCenter);

                // Add spacing
                gfx.DrawString($"Order ID: {orderId}", regularFont, XBrushes.Black, new XRect(40, 50, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Client ID: {clientId}", regularFont, XBrushes.Black, new XRect(40, 70, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Employee ID: {employeeId}", regularFont, XBrushes.Black, new XRect(40, 90, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Bill Date: {billDate.ToShortDateString()}", regularFont, XBrushes.Black, new XRect(40, 110, page.Width, page.Height), XStringFormats.TopLeft);

                // Add a line to separate sections
                gfx.DrawLine(XPens.Black, 40, 130, page.Width - 40, 130);

                // Add product header
                gfx.DrawString("Products:", regularFont, XBrushes.Black, new XRect(40, 140, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawLine(XPens.Black, 40, 160, page.Width - 40, 160); // Line under the header

                // Draw table headers
                int yOffset = 180; // Start drawing headers
                gfx.DrawString("Product ID", regularFont, XBrushes.Black, new XRect(40, yOffset, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Name", regularFont, XBrushes.Black, new XRect(150, yOffset, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Price", regularFont, XBrushes.Black, new XRect(300, yOffset, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Quantity", regularFont, XBrushes.Black, new XRect(400, yOffset, 100, 20), XStringFormats.TopCenter); // Centered header

                // Add a line under the header
                yOffset += 20; // Move down for product details
                gfx.DrawLine(XPens.Black, 40, yOffset, page.Width - 40, yOffset); // Line under the headers
                yOffset += 20; // Increment yOffset to start product rows

                // Fetch products for the order
                string productQuery = @"
                SELECT oi.ProductID, p.Name AS ProductName, p.Price, oi.Quantity 
                FROM OrderItem oi
                JOIN Product p ON oi.ProductID = p.ID
                WHERE oi.OrderID = @OrderID";

                DBconnection db = new DBconnection();
                using (SqlCommand command = new SqlCommand(productQuery, db.OpenConnection()))
                {
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productId = reader["ProductID"].ToString();
                            string productName = reader["ProductName"].ToString();
                            string price = reader["Price"].ToString();
                            string quantity = reader["Quantity"].ToString();

                            // Draw product details in the table
                            gfx.DrawString(productId, regularFont, XBrushes.Black, new XRect(40, yOffset, page.Width, page.Height), XStringFormats.TopLeft);
                            gfx.DrawString(productName, regularFont, XBrushes.Black, new XRect(150, yOffset, page.Width, page.Height), XStringFormats.TopLeft);
                            gfx.DrawString($"{price} VND", regularFont, XBrushes.Black, new XRect(300, yOffset, page.Width, page.Height), XStringFormats.TopLeft);

                            // Center the Quantity in its cell
                            gfx.DrawString(quantity, regularFont, XBrushes.Black, new XRect(400, yOffset, 100, 20), XStringFormats.Center); // Centered quantity

                            yOffset += 20; // Increment the Y position for the next product
                        }

                        // Add line after product list
                        gfx.DrawLine(XPens.Black, 40, yOffset, page.Width - 40, yOffset); // Line under the product list
                    }
                }

                // Draw the total price
                gfx.DrawString($"Total Price: {totalPrice} VND", regularFont, XBrushes.Black, new XRect(40, yOffset + 20, page.Width, page.Height), XStringFormats.TopLeft);

                // Save the document
                document.Save(filePath);
            }
            // Open the generated PDF file
            OpenPdf(filePath);

            return filePath;
        }

        private void OpenPdf(string filePath)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true // Open with the default application
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions if the PDF cannot be opened
                Console.WriteLine("An error occurred while opening the PDF: " + ex.Message);
            }
        }
    }
}
