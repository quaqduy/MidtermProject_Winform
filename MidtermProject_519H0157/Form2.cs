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

        /*----------------------------------------------------------------------------*/
        private void addClientBtn_Click(object sender, EventArgs e)
        {
            openAddForm("client");
        }
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
                default:
                    break;
            }
        }

        private void delClientBtn_Click(object sender, EventArgs e)
        {
            clientHandler.delclientEvent();
        }
        /*------------------ClientPage------------------*/
    }
}
