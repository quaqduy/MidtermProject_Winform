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
            placeOrderHandler = new placeOrderHandler(productList_view);
            placeOrderHandler.listProduct_view_Custom();
            placeOrderHandler.LoadProductToListView();
            productList_view.DoubleClick += placeOrderHandler.productList_DoubleClick;

            placeOrderHandler.ProductId_selected = productId_selected;
            placeOrderHandler.ProductName_selected = productName_selected;
            placeOrderHandler.Quantity_order = quantity_order;

            orderInfHandler = new orderInfHandler(comboBox_employeeId, comboBox_clientId);
            orderInfHandler.dropDataToEmployeeIDComboBox();
            orderInfHandler.dropDataToClientIDComboBox();
            comboBox_employeeId.TextChanged += orderInfHandler.comboBox_employeeId_TextChanged;
            comboBox_clientId.TextChanged += orderInfHandler.comboBox_clientId_TextChanged;
            orderInfHandler.generalCurrentDate(orderDate);
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
        /*------------------vvv------------------*/
    }
}
