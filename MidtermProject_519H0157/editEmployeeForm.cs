using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MidtermProject_519H0157
{
    public partial class editEmployeeForm : Form
    {
        public editEmployeeForm()
        {
            InitializeComponent();
        }

        public void Show(ListViewItem selectedItem)
        {
            idEmployee.Text = selectedItem.SubItems[0].Text;
            nameEmployee.Text = selectedItem.SubItems[1].Text;
            emailEmployee.Text = selectedItem.SubItems[2].Text;
            phoneEmployee.Text = selectedItem.SubItems[3].Text;
            addressEmployee.Text = selectedItem.SubItems[4].Text;
            salaryEmployee.Text = selectedItem.SubItems[5].Text;
            hireDateEmployee.Text = selectedItem.SubItems[6].Text; 

            this.ShowDialog();
        }

        private void editEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void saveEmployeeBtn_Click(object sender, EventArgs e)
        {
            // Displays the confirmation dialog
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to update the employee information?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Check the results from the dialog box
            if (dialogResult == DialogResult.Yes)
            {
                // If the user selects Yes, perform the update
                UpdateEmployee(
                    idEmployee.Text,
                    nameEmployee.Text,
                    emailEmployee.Text,
                    phoneEmployee.Text,
                    addressEmployee.Text,
                    salaryEmployee.Text,
                    hireDateEmployee.Text
                );

                // Can notify the user that the update was successful
                // Tải lại dữ liệu vào ListView trong Form chính (DashBoard)
                DashBoard dashBoard = (DashBoard)Application.OpenForms["DashBoard"]; // Lấy instance của DashBoard
                if (dashBoard != null)
                {
                    dashBoard.LoadDataToListView(); // Gọi phương thức để tải lại dữ liệu
                }

                // Đóng form chỉnh sửa sau khi cập nhật
                this.Close();
            }
            else
            {
                // If the user selects No, do nothing and may notify
                MessageBox.Show("Update canceled.");
            }
        }
        private void UpdateEmployee(string id, string name, string email, string phone, string address, string salary, string hireDate)
        {
            // Connect to the database and perform updates
            using (SqlConnection conn = new SqlConnection(@"Data Source=QUAQDUY;Initial Catalog=PiStoreDB;Integrated Security=True"))
            {
                string query = "UPDATE Employee SET " +
                    "Name = @Name, " +
                    "Email = @Email, " +
                    "Phone = @Phone, " +
                    "Address = @Address, " +
                    "Salary = @Salary, " +
                    "HireDate = @HireDate " +
                    "WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@HireDate", hireDate);

                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
