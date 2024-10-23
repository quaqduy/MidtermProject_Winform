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
        public employeeHandler employeeHandler;
        public clientHandler clientHandler;
        public productHandler productHandler;
        public placeOrderHandler placeOrderHandler;
        public orderInfHandler orderInfHandler;

        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
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
            //Hadle data
            orderInfHandler.updateQuantityProduct(productList_order, placeOrderHandler.quantityForModifyDB);

            var EmployeeID = comboBox_employeeId.Text;
            var ClientID = comboBox_clientId.Text;
            var TotalPrice = totalPrice_textbox.Text;
            var OrderDate = orderDate.Text;
            orderInfHandler.createOrder(EmployeeID, ClientID, OrderDate, TotalPrice);

            //Clear Content
            clearContent();
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

        /*------------------vvv------------------*/
    }
}
