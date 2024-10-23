namespace MidtermProject_519H0157
{
    partial class DashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addEmployeeBtn = new System.Windows.Forms.Button();
            this.delEmployeeBtn = new System.Windows.Forms.Button();
            this.employeeList = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.addClientBtn = new System.Windows.Forms.Button();
            this.delClientBtn = new System.Windows.Forms.Button();
            this.clientsList = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.addProductBtn = new System.Windows.Forms.Button();
            this.delProductBtn = new System.Windows.Forms.Button();
            this.productsList = new System.Windows.Forms.ListView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalPrice_textbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.payBtn = new System.Windows.Forms.Button();
            this.productList_order = new System.Windows.Forms.ListView();
            this.comboBox_employeeId = new System.Windows.Forms.ComboBox();
            this.comboBox_clientId = new System.Windows.Forms.ComboBox();
            this.orderDate = new System.Windows.Forms.Label();
            this.productList_view = new System.Windows.Forms.ListView();
            this.addProduct_To_Order = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dd = new System.Windows.Forms.Label();
            this.productId_selected = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.productName_selected = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.quantity_order = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("MV Boli", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1073, 623);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.employeeList);
            this.tabPage1.Location = new System.Drawing.Point(4, 45);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(40);
            this.tabPage1.Size = new System.Drawing.Size(1065, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addEmployeeBtn);
            this.flowLayoutPanel1.Controls.Add(this.delEmployeeBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(40, 495);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(983, 37);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // addEmployeeBtn
            // 
            this.addEmployeeBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.addEmployeeBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEmployeeBtn.ForeColor = System.Drawing.Color.Black;
            this.addEmployeeBtn.Location = new System.Drawing.Point(888, 3);
            this.addEmployeeBtn.Name = "addEmployeeBtn";
            this.addEmployeeBtn.Padding = new System.Windows.Forms.Padding(2);
            this.addEmployeeBtn.Size = new System.Drawing.Size(92, 30);
            this.addEmployeeBtn.TabIndex = 2;
            this.addEmployeeBtn.Text = "Add";
            this.addEmployeeBtn.UseVisualStyleBackColor = false;
            this.addEmployeeBtn.Click += new System.EventHandler(this.addEmployeeBtn_Click);
            // 
            // delEmployeeBtn
            // 
            this.delEmployeeBtn.BackColor = System.Drawing.Color.Red;
            this.delEmployeeBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delEmployeeBtn.ForeColor = System.Drawing.Color.White;
            this.delEmployeeBtn.Location = new System.Drawing.Point(790, 3);
            this.delEmployeeBtn.Name = "delEmployeeBtn";
            this.delEmployeeBtn.Padding = new System.Windows.Forms.Padding(2);
            this.delEmployeeBtn.Size = new System.Drawing.Size(92, 30);
            this.delEmployeeBtn.TabIndex = 1;
            this.delEmployeeBtn.Text = "Delete";
            this.delEmployeeBtn.UseVisualStyleBackColor = false;
            this.delEmployeeBtn.Click += new System.EventHandler(this.delEmployeeBtn_Click);
            // 
            // employeeList
            // 
            this.employeeList.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.employeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeList.HideSelection = false;
            this.employeeList.Location = new System.Drawing.Point(40, 40);
            this.employeeList.Margin = new System.Windows.Forms.Padding(500, 800, 500, 500);
            this.employeeList.Name = "employeeList";
            this.employeeList.Size = new System.Drawing.Size(983, 492);
            this.employeeList.TabIndex = 2;
            this.employeeList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Controls.Add(this.clientsList);
            this.tabPage2.Location = new System.Drawing.Point(4, 45);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(40);
            this.tabPage2.Size = new System.Drawing.Size(1065, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Clients";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.addClientBtn);
            this.flowLayoutPanel2.Controls.Add(this.delClientBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(40, 497);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(985, 37);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // addClientBtn
            // 
            this.addClientBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.addClientBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClientBtn.Location = new System.Drawing.Point(890, 3);
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.Padding = new System.Windows.Forms.Padding(2);
            this.addClientBtn.Size = new System.Drawing.Size(92, 30);
            this.addClientBtn.TabIndex = 2;
            this.addClientBtn.Text = "Add";
            this.addClientBtn.UseVisualStyleBackColor = false;
            this.addClientBtn.Click += new System.EventHandler(this.addClientBtn_Click);
            // 
            // delClientBtn
            // 
            this.delClientBtn.BackColor = System.Drawing.Color.Red;
            this.delClientBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delClientBtn.ForeColor = System.Drawing.Color.White;
            this.delClientBtn.Location = new System.Drawing.Point(792, 3);
            this.delClientBtn.Name = "delClientBtn";
            this.delClientBtn.Padding = new System.Windows.Forms.Padding(2);
            this.delClientBtn.Size = new System.Drawing.Size(92, 30);
            this.delClientBtn.TabIndex = 1;
            this.delClientBtn.Text = "Delete";
            this.delClientBtn.UseVisualStyleBackColor = false;
            this.delClientBtn.Click += new System.EventHandler(this.delClientBtn_Click);
            // 
            // clientsList
            // 
            this.clientsList.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.clientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsList.HideSelection = false;
            this.clientsList.Location = new System.Drawing.Point(40, 40);
            this.clientsList.Margin = new System.Windows.Forms.Padding(500, 800, 500, 500);
            this.clientsList.Name = "clientsList";
            this.clientsList.Size = new System.Drawing.Size(985, 494);
            this.clientsList.TabIndex = 4;
            this.clientsList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.flowLayoutPanel3);
            this.tabPage3.Controls.Add(this.productsList);
            this.tabPage3.Location = new System.Drawing.Point(4, 45);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(40);
            this.tabPage3.Size = new System.Drawing.Size(1065, 574);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Products";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.addProductBtn);
            this.flowLayoutPanel3.Controls.Add(this.delProductBtn);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(40, 497);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(985, 37);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // addProductBtn
            // 
            this.addProductBtn.BackColor = System.Drawing.Color.GreenYellow;
            this.addProductBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProductBtn.Location = new System.Drawing.Point(890, 3);
            this.addProductBtn.Name = "addProductBtn";
            this.addProductBtn.Padding = new System.Windows.Forms.Padding(2);
            this.addProductBtn.Size = new System.Drawing.Size(92, 30);
            this.addProductBtn.TabIndex = 2;
            this.addProductBtn.Text = "Add";
            this.addProductBtn.UseVisualStyleBackColor = false;
            this.addProductBtn.Click += new System.EventHandler(this.addProductBtn_Click);
            // 
            // delProductBtn
            // 
            this.delProductBtn.BackColor = System.Drawing.Color.Red;
            this.delProductBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delProductBtn.ForeColor = System.Drawing.Color.White;
            this.delProductBtn.Location = new System.Drawing.Point(792, 3);
            this.delProductBtn.Name = "delProductBtn";
            this.delProductBtn.Padding = new System.Windows.Forms.Padding(2);
            this.delProductBtn.Size = new System.Drawing.Size(92, 30);
            this.delProductBtn.TabIndex = 1;
            this.delProductBtn.Text = "Delete";
            this.delProductBtn.UseVisualStyleBackColor = false;
            this.delProductBtn.Click += new System.EventHandler(this.delProductBtn_Click);
            // 
            // productsList
            // 
            this.productsList.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.productsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsList.HideSelection = false;
            this.productsList.Location = new System.Drawing.Point(40, 40);
            this.productsList.Margin = new System.Windows.Forms.Padding(500, 800, 500, 500);
            this.productsList.Name = "productsList";
            this.productsList.Size = new System.Drawing.Size(985, 494);
            this.productsList.TabIndex = 6;
            this.productsList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage5.Controls.Add(this.tableLayoutPanel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 45);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1065, 574);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Place Order";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.productList_view, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addProduct_To_Order, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1059, 568);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.totalPrice_textbox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.payBtn, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.productList_order, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_employeeId, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_clientId, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.orderDate, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(743, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(313, 456);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("MV Boli", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Place Order";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Client ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "Order Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 40);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Prire";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalPrice_textbox
            // 
            this.totalPrice_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPrice_textbox.Location = new System.Drawing.Point(207, 183);
            this.totalPrice_textbox.Name = "totalPrice_textbox";
            this.totalPrice_textbox.Size = new System.Drawing.Size(121, 35);
            this.totalPrice_textbox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Selected products: ";
            // 
            // payBtn
            // 
            this.payBtn.BackColor = System.Drawing.Color.YellowGreen;
            this.payBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payBtn.ForeColor = System.Drawing.Color.Black;
            this.payBtn.Location = new System.Drawing.Point(207, 473);
            this.payBtn.Name = "payBtn";
            this.payBtn.Size = new System.Drawing.Size(121, 34);
            this.payBtn.TabIndex = 11;
            this.payBtn.Text = "Pay";
            this.payBtn.UseVisualStyleBackColor = false;
            // 
            // productList_order
            // 
            this.productList_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productList_order.HideSelection = false;
            this.productList_order.Location = new System.Drawing.Point(207, 223);
            this.productList_order.Name = "productList_order";
            this.productList_order.Size = new System.Drawing.Size(121, 244);
            this.productList_order.TabIndex = 12;
            this.productList_order.UseCompatibleStateImageBehavior = false;
            // 
            // comboBox_employeeId
            // 
            this.comboBox_employeeId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_employeeId.FormattingEnabled = true;
            this.comboBox_employeeId.Location = new System.Drawing.Point(207, 63);
            this.comboBox_employeeId.Name = "comboBox_employeeId";
            this.comboBox_employeeId.Size = new System.Drawing.Size(121, 30);
            this.comboBox_employeeId.TabIndex = 13;
            // 
            // comboBox_clientId
            // 
            this.comboBox_clientId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_clientId.FormattingEnabled = true;
            this.comboBox_clientId.Location = new System.Drawing.Point(207, 103);
            this.comboBox_clientId.Name = "comboBox_clientId";
            this.comboBox_clientId.Size = new System.Drawing.Size(121, 30);
            this.comboBox_clientId.TabIndex = 14;
            // 
            // orderDate
            // 
            this.orderDate.AutoSize = true;
            this.orderDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderDate.Location = new System.Drawing.Point(207, 140);
            this.orderDate.Name = "orderDate";
            this.orderDate.Size = new System.Drawing.Size(121, 40);
            this.orderDate.TabIndex = 15;
            this.orderDate.Text = "label7";
            this.orderDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productList_view
            // 
            this.productList_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productList_view.HideSelection = false;
            this.productList_view.Location = new System.Drawing.Point(3, 3);
            this.productList_view.Name = "productList_view";
            this.productList_view.Size = new System.Drawing.Size(682, 456);
            this.productList_view.TabIndex = 0;
            this.productList_view.UseCompatibleStateImageBehavior = false;
            // 
            // addProduct_To_Order
            // 
            this.addProduct_To_Order.BackColor = System.Drawing.Color.GreenYellow;
            this.addProduct_To_Order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addProduct_To_Order.Location = new System.Drawing.Point(3, 511);
            this.addProduct_To_Order.Name = "addProduct_To_Order";
            this.addProduct_To_Order.Size = new System.Drawing.Size(682, 54);
            this.addProduct_To_Order.TabIndex = 2;
            this.addProduct_To_Order.Text = "Add";
            this.addProduct_To_Order.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Controls.Add(this.dd, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.productId_selected, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.productName_selected, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label11, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.quantity_order, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 465);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(682, 40);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // dd
            // 
            this.dd.AutoSize = true;
            this.dd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dd.Location = new System.Drawing.Point(3, 0);
            this.dd.Name = "dd";
            this.dd.Size = new System.Drawing.Size(107, 40);
            this.dd.TabIndex = 0;
            this.dd.Text = "ProductId Selected:";
            this.dd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productId_selected
            // 
            this.productId_selected.AutoSize = true;
            this.productId_selected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productId_selected.Location = new System.Drawing.Point(116, 0);
            this.productId_selected.Name = "productId_selected";
            this.productId_selected.Size = new System.Drawing.Size(107, 40);
            this.productId_selected.TabIndex = 1;
            this.productId_selected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(229, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 40);
            this.label9.TabIndex = 2;
            this.label9.Text = "Product Name:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productName_selected
            // 
            this.productName_selected.AutoSize = true;
            this.productName_selected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productName_selected.Location = new System.Drawing.Point(342, 0);
            this.productName_selected.Name = "productName_selected";
            this.productName_selected.Size = new System.Drawing.Size(107, 40);
            this.productName_selected.TabIndex = 3;
            this.productName_selected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(455, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 40);
            this.label11.TabIndex = 4;
            this.label11.Text = "Quantity:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quantity_order
            // 
            this.quantity_order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantity_order.Location = new System.Drawing.Point(568, 3);
            this.quantity_order.Name = "quantity_order";
            this.quantity_order.Size = new System.Drawing.Size(111, 35);
            this.quantity_order.TabIndex = 5;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage6.Controls.Add(this.flowLayoutPanel4);
            this.tabPage6.Controls.Add(this.listView1);
            this.tabPage6.Location = new System.Drawing.Point(4, 45);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(40);
            this.tabPage6.Size = new System.Drawing.Size(1065, 574);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Manage Orders";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabPage7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage7.Location = new System.Drawing.Point(4, 45);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1065, 574);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Generate Bill";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.button1);
            this.flowLayoutPanel4.Controls.Add(this.button2);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(40, 497);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(985, 37);
            this.flowLayoutPanel4.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.GreenYellow;
            this.button1.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(890, 3);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(2);
            this.button1.Size = new System.Drawing.Size(92, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(792, 3);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(2);
            this.button2.Size = new System.Drawing.Size(92, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(40, 40);
            this.listView1.Margin = new System.Windows.Forms.Padding(500, 800, 500, 500);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(985, 494);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1073, 623);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListView employeeList;
        private System.Windows.Forms.Button delEmployeeBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addEmployeeBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button addClientBtn;
        private System.Windows.Forms.Button delClientBtn;
        private System.Windows.Forms.ListView clientsList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button addProductBtn;
        private System.Windows.Forms.Button delProductBtn;
        private System.Windows.Forms.ListView productsList;
        public System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView productList_view;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox totalPrice_textbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button payBtn;
        private System.Windows.Forms.Button addProduct_To_Order;
        private System.Windows.Forms.ListView productList_order;
        private System.Windows.Forms.ComboBox comboBox_employeeId;
        private System.Windows.Forms.ComboBox comboBox_clientId;
        private System.Windows.Forms.Label orderDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label dd;
        private System.Windows.Forms.Label productId_selected;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label productName_selected;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox quantity_order;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
    }
}