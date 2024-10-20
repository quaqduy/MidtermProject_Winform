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
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(806, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImage = global::MidtermProject_519H0157.Properties.Resources.dashboardBg;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.employeeList);
            this.tabPage1.Location = new System.Drawing.Point(4, 45);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(40, 20, 40, 40);
            this.tabPage1.Size = new System.Drawing.Size(798, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addEmployeeBtn);
            this.flowLayoutPanel1.Controls.Add(this.delEmployeeBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(40, 322);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(716, 37);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // addEmployeeBtn
            // 
            this.addEmployeeBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEmployeeBtn.Location = new System.Drawing.Point(621, 3);
            this.addEmployeeBtn.Name = "addEmployeeBtn";
            this.addEmployeeBtn.Padding = new System.Windows.Forms.Padding(2);
            this.addEmployeeBtn.Size = new System.Drawing.Size(92, 30);
            this.addEmployeeBtn.TabIndex = 2;
            this.addEmployeeBtn.Text = "Add";
            this.addEmployeeBtn.UseVisualStyleBackColor = true;
            this.addEmployeeBtn.Click += new System.EventHandler(this.addEmployeeBtn_Click);
            // 
            // delEmployeeBtn
            // 
            this.delEmployeeBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delEmployeeBtn.Location = new System.Drawing.Point(523, 3);
            this.delEmployeeBtn.Name = "delEmployeeBtn";
            this.delEmployeeBtn.Padding = new System.Windows.Forms.Padding(2);
            this.delEmployeeBtn.Size = new System.Drawing.Size(92, 30);
            this.delEmployeeBtn.TabIndex = 1;
            this.delEmployeeBtn.Text = "Delete";
            this.delEmployeeBtn.UseVisualStyleBackColor = true;
            this.delEmployeeBtn.Click += new System.EventHandler(this.delEmployeeBtn_Click);
            // 
            // employeeList
            // 
            this.employeeList.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.employeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeList.HideSelection = false;
            this.employeeList.Location = new System.Drawing.Point(40, 20);
            this.employeeList.Margin = new System.Windows.Forms.Padding(500, 800, 500, 500);
            this.employeeList.Name = "employeeList";
            this.employeeList.Size = new System.Drawing.Size(716, 339);
            this.employeeList.TabIndex = 2;
            this.employeeList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.BackgroundImage = global::MidtermProject_519H0157.Properties.Resources.dashboardBg;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Controls.Add(this.clientsList);
            this.tabPage2.Location = new System.Drawing.Point(4, 45);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(40, 20, 40, 40);
            this.tabPage2.Size = new System.Drawing.Size(798, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Clients";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.addClientBtn);
            this.flowLayoutPanel2.Controls.Add(this.delClientBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(40, 324);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(718, 37);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // addClientBtn
            // 
            this.addClientBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClientBtn.Location = new System.Drawing.Point(623, 3);
            this.addClientBtn.Name = "addClientBtn";
            this.addClientBtn.Padding = new System.Windows.Forms.Padding(2);
            this.addClientBtn.Size = new System.Drawing.Size(92, 30);
            this.addClientBtn.TabIndex = 2;
            this.addClientBtn.Text = "Add";
            this.addClientBtn.UseVisualStyleBackColor = true;
            this.addClientBtn.Click += new System.EventHandler(this.addClientBtn_Click);
            // 
            // delClientBtn
            // 
            this.delClientBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delClientBtn.Location = new System.Drawing.Point(525, 3);
            this.delClientBtn.Name = "delClientBtn";
            this.delClientBtn.Padding = new System.Windows.Forms.Padding(2);
            this.delClientBtn.Size = new System.Drawing.Size(92, 30);
            this.delClientBtn.TabIndex = 1;
            this.delClientBtn.Text = "Delete";
            this.delClientBtn.UseVisualStyleBackColor = true;
            this.delClientBtn.Click += new System.EventHandler(this.delClientBtn_Click);
            // 
            // clientsList
            // 
            this.clientsList.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.clientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsList.HideSelection = false;
            this.clientsList.Location = new System.Drawing.Point(40, 20);
            this.clientsList.Margin = new System.Windows.Forms.Padding(500, 800, 500, 500);
            this.clientsList.Name = "clientsList";
            this.clientsList.Size = new System.Drawing.Size(718, 341);
            this.clientsList.TabIndex = 4;
            this.clientsList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::MidtermProject_519H0157.Properties.Resources.dashboardBg;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.flowLayoutPanel3);
            this.tabPage3.Controls.Add(this.productsList);
            this.tabPage3.Location = new System.Drawing.Point(4, 45);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(40, 20, 40, 40);
            this.tabPage3.Size = new System.Drawing.Size(798, 401);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Products";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.addProductBtn);
            this.flowLayoutPanel3.Controls.Add(this.delProductBtn);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(40, 324);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(718, 37);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // addProductBtn
            // 
            this.addProductBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProductBtn.Location = new System.Drawing.Point(623, 3);
            this.addProductBtn.Name = "addProductBtn";
            this.addProductBtn.Padding = new System.Windows.Forms.Padding(2);
            this.addProductBtn.Size = new System.Drawing.Size(92, 30);
            this.addProductBtn.TabIndex = 2;
            this.addProductBtn.Text = "Add";
            this.addProductBtn.UseVisualStyleBackColor = true;
            this.addProductBtn.Click += new System.EventHandler(this.addProductBtn_Click);
            // 
            // delProductBtn
            // 
            this.delProductBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delProductBtn.Location = new System.Drawing.Point(525, 3);
            this.delProductBtn.Name = "delProductBtn";
            this.delProductBtn.Padding = new System.Windows.Forms.Padding(2);
            this.delProductBtn.Size = new System.Drawing.Size(92, 30);
            this.delProductBtn.TabIndex = 1;
            this.delProductBtn.Text = "Delete";
            this.delProductBtn.UseVisualStyleBackColor = true;
            this.delProductBtn.Click += new System.EventHandler(this.delProductBtn_Click);
            // 
            // productsList
            // 
            this.productsList.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.productsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsList.HideSelection = false;
            this.productsList.Location = new System.Drawing.Point(40, 20);
            this.productsList.Margin = new System.Windows.Forms.Padding(500, 800, 500, 500);
            this.productsList.Name = "productsList";
            this.productsList.Size = new System.Drawing.Size(718, 341);
            this.productsList.TabIndex = 6;
            this.productsList.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage5
            // 
            this.tabPage5.BackgroundImage = global::MidtermProject_519H0157.Properties.Resources.dashboardBg;
            this.tabPage5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage5.Location = new System.Drawing.Point(4, 45);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(798, 401);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Place Order";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.BackgroundImage = global::MidtermProject_519H0157.Properties.Resources.dashboardBg;
            this.tabPage6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage6.Location = new System.Drawing.Point(4, 45);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(798, 401);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Manage Orders";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.BackgroundImage = global::MidtermProject_519H0157.Properties.Resources.dashboardBg;
            this.tabPage7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage7.Location = new System.Drawing.Point(4, 45);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(798, 401);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Generate Bill";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(806, 450);
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
    }
}