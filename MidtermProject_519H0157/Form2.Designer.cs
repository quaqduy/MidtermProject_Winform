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
            this.delEmployeeBtn = new System.Windows.Forms.Button();
            this.employeeList = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 45);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(798, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Clients";
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::MidtermProject_519H0157.Properties.Resources.dashboardBg;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Location = new System.Drawing.Point(4, 45);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(798, 401);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Products";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackgroundImage = global::MidtermProject_519H0157.Properties.Resources.dashboardBg;
            this.tabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage4.Location = new System.Drawing.Point(4, 45);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(798, 401);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Products";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addBtn);
            this.flowLayoutPanel1.Controls.Add(this.delEmployeeBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(40, 322);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(716, 37);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(621, 3);
            this.addBtn.Name = "addBtn";
            this.addBtn.Padding = new System.Windows.Forms.Padding(2);
            this.addBtn.Size = new System.Drawing.Size(92, 30);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListView employeeList;
        private System.Windows.Forms.Button delEmployeeBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addBtn;
    }
}