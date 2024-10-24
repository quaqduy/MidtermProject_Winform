using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using PdfSharp.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace MidtermProject_519H0157
{
    public partial class DashBoard : Form
    {
        public employeeHandler employeeHandler;
        public clientHandler clientHandler;
        public productHandler productHandler;
        public placeOrderHandler placeOrderHandler;
        public orderInfHandler orderInfHandler;
        public managerOrderHandler managerOrderHandler;
        public billHandler billHandler;

        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            loadFulldashBoard();
        }

        private void loadFulldashBoard()
        {
            //Employee view
            employeeHandler = new employeeHandler(employeeList);
            employeeHandler.listViewEmployeeCustom();
            employeeHandler.LoadDataToEmployeeListView();
            employeeList.DoubleClick += new EventHandler(employeeHandler.employeeList_DoubleClick);

            //Client view
            clientHandler = new clientHandler(clientsList);
            clientHandler.listViewClientCustom();
            clientHandler.LoadDataToClientListView();
            clientsList.DoubleClick += new EventHandler(clientHandler.clientList_DoubleClick);

            //Product view
            productHandler = new productHandler(productsList);
            productHandler.listViewProductCustom();
            productHandler.LoadDataToProductListView();
            productsList.DoubleClick += new EventHandler(productHandler.productList_DoubleClick);

            //PlaceOrder view
            placeOrderHandler = new placeOrderHandler(productList_view, productList_order, totalPrice_textbox);
            placeOrderHandler.listProduct_view_Custom();
            placeOrderHandler.LoadProductToListView();
            productList_view.DoubleClick += placeOrderHandler.productList_DoubleClick;

            placeOrderHandler.ProductId_selected = productId_selected;
            placeOrderHandler.ProductName_selected = productName_selected;
            placeOrderHandler.Quantity_order = quantity_order;
            addProduct_To_Order.Click += placeOrderHandler.addProductToOrder;

            orderInfHandler = new orderInfHandler(comboBox_employeeId, comboBox_clientId);
            orderInfHandler.dropDataToEmployeeIDComboBox();
            orderInfHandler.dropDataToClientIDComboBox();
            comboBox_employeeId.TextChanged += orderInfHandler.comboBox_employeeId_TextChanged;
            comboBox_clientId.TextChanged += orderInfHandler.comboBox_clientId_TextChanged;
            orderInfHandler.generalCurrentDate(orderDate);
            payBtn.Click += payHanlde;

            //Manager Bill
            billHandler = new billHandler(ListBill);
            billHandler.loadDataToListBill();
            ListBill.DoubleClick += generateBill_in_ListBillView;

            //Manager Order
            managerOrderHandler = new managerOrderHandler(orderList_manager, detailOrder, LO_product_list, billHandler);
            managerOrderHandler.listViewOrderCustom();
            managerOrderHandler.loadData(LO_idLable, LO_clientIDLable, LO_employeeIDLable, LO_orderDateLable, LO_totalPriceLable);
            generateBillBtn.Click += managerOrderHandler.generateBill;

            //Search
            searchHandle();

            //Analysis
            AnalysisCreateAndShow();
        }

        /*------------------EmployeePage------------------*/
        private void delEmployeeBtn_Click(object sender, EventArgs e)
        {
            employeeHandler.delEmployEvent();
        }

        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            openAddForm("emplyee");
        }

        /*------------------ClientPage------------------*/
        private void addClientBtn_Click(object sender, EventArgs e)
        {
            openAddForm("client");
        }

        private void delClientBtn_Click(object sender, EventArgs e)
        {
            clientHandler.delClientEvent();
        }

        /*------------------ProductPage------------------*/
        private void addProductBtn_Click(object sender, EventArgs e)
        {
            openAddForm("product");
        }

        private void delProductBtn_Click(object sender, EventArgs e)
        {
            productHandler.delProductEvent();

        }

        /*------------------vvv------------------*/
        private void openAddForm(string type)
        {
            editForm editForm = new editForm();

            switch (type)
            {
                case "emplyee":
                    editForm.Show(true, "employee");
                    break;
                case "client":
                    editForm.Show(true, "client");
                    break;
                case "product":
                    editForm.Show(true, "product");
                    break;
                default:
                    break;
            }
        }

        private void payHanlde(Object sender, EventArgs e)
        {

            // Display a confirmation dialog with Yes and No buttons
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed with the payment?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // User clicked Yes, proceed with payment logic
                //Hadle data
                orderInfHandler.updateQuantityProduct(productList_order, placeOrderHandler.quantityForModifyDB);

                var EmployeeID = comboBox_employeeId.Text;
                var ClientID = comboBox_clientId.Text;
                var TotalPrice = totalPrice_textbox.Text;
                var OrderDate = orderDate.Text;
                var orderId = orderInfHandler.createOrder(EmployeeID, ClientID, OrderDate, TotalPrice);
                orderInfHandler.createOrderItem(orderId, productList_order);
                MessageBox.Show("Success to payment.");
                //Clear Content
                clearContent();
                managerOrderHandler.loadData(LO_idLable, LO_clientIDLable, LO_employeeIDLable, LO_orderDateLable, LO_totalPriceLable);
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void clearContent()
        {
            // Unsubscribe from TextChanged events
            comboBox_employeeId.TextChanged -= orderInfHandler.comboBox_employeeId_TextChanged; // Replace with your actual event handler method
            comboBox_clientId.TextChanged -= orderInfHandler.comboBox_clientId_TextChanged; // Replace with your actual event handler method

            // Clear the fields
            productId_selected.Text = string.Empty;
            productName_selected.Text = string.Empty;
            quantity_order.Text = string.Empty;
            comboBox_employeeId.Text = string.Empty;
            comboBox_clientId.Text = string.Empty;
            totalPrice_textbox.Text = string.Empty;
            orderInfHandler.generalCurrentDate(orderDate);
            productList_order.Items.Clear();
            // Resubscribe to TextChanged events
            comboBox_employeeId.TextChanged += orderInfHandler.comboBox_employeeId_TextChanged; // Replace with your actual event handler method
            comboBox_clientId.TextChanged += orderInfHandler.comboBox_clientId_TextChanged; // Replace with your actual event handler method
        }
        /*-----------------ListBill--------------*/
        private void generateBill_in_ListBillView(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListView
            if (ListBill.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = ListBill.SelectedItems[0];

                // Retrieve the values from the selected item
                string orderId = selectedItem.SubItems[0].Text; // Assuming OrderID is in the first column
                string clientId = selectedItem.SubItems[1].Text; // Assuming ClientID is in the second column
                string employeeId = selectedItem.SubItems[2].Text; // Assuming EmployeeID is in the third column
                DateTime billDate = DateTime.Parse(selectedItem.SubItems[3].Text); // Assuming BillDate is in the fourth column
                string totalPrice = selectedItem.SubItems[4].Text; // Assuming TotalPrice is in the fifth column

                // Call the GeneratePdf method with the actual values
                string pdfPath = managerOrderHandler.GeneratePdf(orderId, clientId, employeeId, billDate, totalPrice);

                // Notify the user about the PDF generation
                MessageBox.Show($"Bill generated: {pdfPath}", "Bill Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Notify the user to select an item
                MessageBox.Show("Please select an order to generate the bill.", "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /*------------------vvv------------------*/
        private void searchHandle()
        {
            // Subscribe to the TextChanged event for all search fields
            employeeSearch.TextChanged += search;
            clientSearch.TextChanged += search;
            productSearch.TextChanged += search;
            orderSearch.TextChanged += search;
            billSearch.TextChanged += search;
        }

        private void search(object sender, EventArgs e)
        {
            // Get the sender TextBox that triggered the event
            System.Windows.Forms.TextBox searchBox = sender as System.Windows.Forms.TextBox; // Specify the full namespace
            string searchText = searchBox.Text.Trim(); // Get the trimmed search text

            if (searchBox == employeeSearch)
            {
                SearchEmployees(searchText); // Call your employee search method
            }
            else if (searchBox == clientSearch)
            {
                SearchClients(searchText); // Call your client search method
            }
            else if (searchBox == productSearch)
            {
                SearchProducts(searchText); // Call your product search method
            }
            else if (searchBox == orderSearch)
            {
                SearchOrders(searchText); // Call your product search method
            }
            else if (searchBox == billSearch)
            {
                SearchBills(searchText); // Call your product search method
            }
            else
            {
                loadFulldashBoard();
            }
        }

        private void SearchEmployees(string searchText)
        {
            // Clear the existing employee list
            employeeList.Items.Clear();

            // Construct the query with a parameter for searching by name or ID
            string query = "SELECT ID, Name, Email, Phone, Address, Salary, HireDate FROM Employee WHERE Name LIKE @searchText OR ID LIKE @searchText";

            DBconnection db = new DBconnection();
            using (SqlCommand command = new SqlCommand(query, db.OpenConnection()))
            {
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Assuming you have a method to add items to the ListView
                        employeeList.Items.Add(new ListViewItem(new[]
                        {
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    reader["Email"].ToString(),
                    reader["Phone"].ToString(),
                    reader["Address"].ToString(),
                    reader["Salary"].ToString(),
                    Convert.ToDateTime(reader["HireDate"]).ToString("yyyy-MM-dd")
                }));
                    }
                }
            }
        }


        private void SearchClients(string searchText)
        {
            clientsList.Items.Clear();

            string query = "SELECT ID, Name, Email, Phone, Address FROM Client WHERE Name LIKE @searchText OR ID LIKE @searchText";

            DBconnection db = new DBconnection();
            using (SqlCommand command = new SqlCommand(query, db.OpenConnection()))
            {
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientsList.Items.Add(new ListViewItem(new[]
                        {
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    reader["Email"].ToString(),
                    reader["Phone"].ToString(),
                    reader["Address"].ToString(),
                }));
                    }
                }
            }
        }


        private void SearchProducts(string searchText)
        {
            productsList.Items.Clear();

            string query = "SELECT ID, Name, Price, Quantity FROM Product WHERE Name LIKE @searchText OR ID LIKE @searchText";

            DBconnection db = new DBconnection();
            using (SqlCommand command = new SqlCommand(query, db.OpenConnection()))
            {
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productsList.Items.Add(new ListViewItem(new[]
                        {
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    reader["Price"].ToString(),
                    reader["Quantity"].ToString(),
                }));
                    }
                }
            }
        }

        private void SearchOrders(string searchText)
        {
            // Clear the existing order list
            orderList_manager.Items.Clear();

            // Update the query to retrieve ClientID and EmployeeID instead of their names
            string query = "SELECT o.ID, o.ClientID, o.EmployeeID, o.OrderDate, o.TotalPrice FROM [Order] o " +
                           "WHERE o.ClientID LIKE @searchText OR o.EmployeeID LIKE @searchText OR o.ID LIKE @searchText";

            DBconnection db = new DBconnection();
            using (SqlCommand command = new SqlCommand(query, db.OpenConnection()))
            {
                // Add the search parameter
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Read the data and add to the order list
                    while (reader.Read())
                    {
                        orderList_manager.Items.Add(new ListViewItem(new[]
                        {
                    reader["ID"].ToString(),
                    reader["ClientID"].ToString(),
                    reader["EmployeeID"].ToString(),
                    Convert.ToDateTime(reader["OrderDate"]).ToString("yyyy-MM-dd"),
                    reader["TotalPrice"].ToString(),
                }));
                    }
                }
            }
        }


        private void SearchBills(string searchText)
        {
            // Clear the ListBill view
            ListBill.Items.Clear();

            // Update the query to retrieve ClientID and EmployeeID instead of their names
            string query = "SELECT b.ID, o.ID AS OrderID, b.ClientID, b.EmployeeID, b.BillDate, b.TotalPrice " +
                           "FROM Bill b " +
                           "JOIN [Order] o ON b.OrderID = o.ID " +
                           "WHERE b.ClientID LIKE @searchText OR b.EmployeeID LIKE @searchText OR o.ID LIKE @searchText OR b.ID LIKE @searchText";

            DBconnection db = new DBconnection();
            using (SqlCommand command = new SqlCommand(query, db.OpenConnection()))
            {
                // Add the search parameter
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Read the data and add to the ListBill
                    while (reader.Read())
                    {
                        // Create a ListViewItem with the bill details
                        ListViewItem item = new ListViewItem(new[]
                        {
                            reader["ID"].ToString(),
                            reader["OrderID"].ToString(),
                            reader["ClientID"].ToString(),    // Display ClientID
                            reader["EmployeeID"].ToString(),  // Display EmployeeID
                            Convert.ToDateTime(reader["BillDate"]).ToString("yyyy-MM-dd"),
                            reader["TotalPrice"].ToString(),
                        });

                        // Parse the TotalPrice to decimal and set ForeColor based on the value
                        decimal totalPrice = decimal.Parse(reader["TotalPrice"].ToString());
                        item.ForeColor = totalPrice > 1000 ? Color.Red : Color.Black;

                        // Add the item to the ListBill
                        ListBill.Items.Add(item);
                    }
                }
            }
        }

        // Common method to export data to CSV
        private void ExportToCSV(string query, string[] headers, string fileName, string title)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                Title = title,
                FileName = fileName
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Write CSV header
                        sw.WriteLine(string.Join(",", headers));
                        DBconnection db = new DBconnection();
                        using (SqlCommand command = new SqlCommand(query, db.OpenConnection()))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Write each row to CSV
                                    string[] row = new string[headers.Length];
                                    for (int i = 0; i < headers.Length; i++)
                                    {
                                        // Escape values for CSV format
                                        string value = reader[headers[i]].ToString().Replace("\"", "\"\"");
                                        if (value.Contains(",") || value.Contains("\""))
                                        {
                                            value = "\"" + value + "\""; // Enclose in quotes
                                        }
                                        row[i] = value;
                                    }
                                    sw.WriteLine(string.Join(",", row));
                                }
                            }
                        }
                        MessageBox.Show($"{headers.Length} records have been exported successfully to {saveFileDialog.FileName}.", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Employee Export CSV button
        private void employeeExportCSVBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT ID, Name, Email, Phone, Address AS FullAddress, Salary, HireDate FROM Employee";
            string[] headers = { "ID", "Name", "Email", "Phone", "FullAddress", "Salary", "HireDate" };
            ExportToCSV(query, headers, "Employees.csv", "Export Employees to CSV");
        }


        // Client Export CSV button
        private void clientExportCSVBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT ID, Name, Email, Phone, Address FROM Client";
            string[] headers = { "ID", "Name", "Email", "Phone", "Address" };
            ExportToCSV(query, headers, "Clients.csv", "Export Clients to CSV");
        }

        // Product Export CSV button
        private void productExportCSVBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT ID, Name, Description, Price, Quantity FROM Product";
            string[] headers = { "ID", "Name", "Description", "Price", "Quantity" };
            ExportToCSV(query, headers, "Products.csv", "Export Products to CSV");
        }

        //ANALYSIS
        private void AnalysisCreateAndShow()
        {
            var plotModel = new PlotModel { Title = "Product Sales Quantity" };

            // Create a BarSeries to hold the product sales data
            var barSeries = new BarSeries { Title = "Quantity Sold" };

            // Create a CategoryAxis for the y-axis to display product names
            var categoryAxis = new CategoryAxis
            {
                Title = "Products",
                IsPanEnabled = false,
                IsZoomEnabled = false,
            };

            // Update the query to get the quantity sold for each product
            string query = @"
                SELECT p.Name, SUM(oi.Quantity) AS TotalQuantity
                FROM Product p
                JOIN OrderItem oi ON p.ID = oi.ProductID
                JOIN [Order] o ON oi.OrderID = o.ID
                GROUP BY p.Name
                ORDER BY p.Name;";

            DBconnection db = new DBconnection();
            SqlCommand command = new SqlCommand(query, db.OpenConnection());
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string productName = reader.GetString(0);
                    int totalQuantity = reader.IsDBNull(1) ? 0 : reader.GetInt32(1); // Read as int

                    // Add the product name to the category axis
                    categoryAxis.Labels.Add(productName);

                    // Add the data point directly to the bar series
                    barSeries.Items.Add(new BarItem { Value = totalQuantity });
                }
            }

            // Add the category axis for the Y-axis and the bar series to the plot model
            plotModel.Axes.Add(categoryAxis);
            plotModel.Series.Add(barSeries);

            // Reverse the Y-axis to show the product names at the top
            plotModel.Axes[0].Position = AxisPosition.Left;

            // Create a LinearAxis for the X-axis to display quantities
            var linearAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Quantity Sold",
                Minimum = 0
            };
            plotModel.Axes.Add(linearAxis);

            // Specify the LineStyle from OxyPlot
            plotModel.Axes[0].MajorGridlineStyle = OxyPlot.LineStyle.Solid;

            // Create a PlotView and add it to the tab page
            var plotView = new PlotView
            {
                Dock = DockStyle.Fill,
                Model = plotModel
            };

            this.analysis_tabPage.Controls.Clear();
            this.analysis_tabPage.Controls.Add(plotView);
        }

    }
}
