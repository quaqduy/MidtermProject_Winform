namespace MidtermProject_519H0157
{
    partial class editForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editForm));
            this.titleForm = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.phone_label = new System.Windows.Forms.Label();
            this.address_label = new System.Windows.Forms.Label();
            this.salary_label = new System.Windows.Forms.Label();
            this.hireDate_label = new System.Windows.Forms.Label();
            this.nameEmployee = new System.Windows.Forms.TextBox();
            this.emailEmployee = new System.Windows.Forms.TextBox();
            this.phoneEmployee = new System.Windows.Forms.TextBox();
            this.addressEmployee = new System.Windows.Forms.TextBox();
            this.salaryEmployee = new System.Windows.Forms.TextBox();
            this.hireDateEmployee = new System.Windows.Forms.TextBox();
            this.saveEmployeeBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.idEmployee = new System.Windows.Forms.Label();
            this.dateFomart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleForm
            // 
            this.titleForm.AutoSize = true;
            this.titleForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleForm.Location = new System.Drawing.Point(46, 9);
            this.titleForm.Name = "titleForm";
            this.titleForm.Size = new System.Drawing.Size(315, 46);
            this.titleForm.TabIndex = 0;
            this.titleForm.Text = "Edit Information";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(51, 89);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(35, 13);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "Name";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Location = new System.Drawing.Point(51, 124);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(32, 13);
            this.email_label.TabIndex = 3;
            this.email_label.Text = "Email";
            // 
            // phone_label
            // 
            this.phone_label.AutoSize = true;
            this.phone_label.Location = new System.Drawing.Point(51, 160);
            this.phone_label.Name = "phone_label";
            this.phone_label.Size = new System.Drawing.Size(38, 13);
            this.phone_label.TabIndex = 4;
            this.phone_label.Text = "Phone";
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.Location = new System.Drawing.Point(51, 194);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(45, 13);
            this.address_label.TabIndex = 5;
            this.address_label.Text = "Address";
            // 
            // salary_label
            // 
            this.salary_label.AutoSize = true;
            this.salary_label.Location = new System.Drawing.Point(51, 228);
            this.salary_label.Name = "salary_label";
            this.salary_label.Size = new System.Drawing.Size(36, 13);
            this.salary_label.TabIndex = 6;
            this.salary_label.Text = "Salary";
            // 
            // hireDate_label
            // 
            this.hireDate_label.AutoSize = true;
            this.hireDate_label.Location = new System.Drawing.Point(51, 260);
            this.hireDate_label.Name = "hireDate_label";
            this.hireDate_label.Size = new System.Drawing.Size(49, 13);
            this.hireDate_label.TabIndex = 7;
            this.hireDate_label.Text = "HireDate";
            // 
            // nameEmployee
            // 
            this.nameEmployee.Location = new System.Drawing.Point(118, 86);
            this.nameEmployee.Name = "nameEmployee";
            this.nameEmployee.Size = new System.Drawing.Size(401, 20);
            this.nameEmployee.TabIndex = 9;
            // 
            // emailEmployee
            // 
            this.emailEmployee.Location = new System.Drawing.Point(118, 121);
            this.emailEmployee.Name = "emailEmployee";
            this.emailEmployee.Size = new System.Drawing.Size(401, 20);
            this.emailEmployee.TabIndex = 10;
            // 
            // phoneEmployee
            // 
            this.phoneEmployee.Location = new System.Drawing.Point(118, 157);
            this.phoneEmployee.Name = "phoneEmployee";
            this.phoneEmployee.Size = new System.Drawing.Size(401, 20);
            this.phoneEmployee.TabIndex = 11;
            // 
            // addressEmployee
            // 
            this.addressEmployee.Location = new System.Drawing.Point(118, 191);
            this.addressEmployee.Name = "addressEmployee";
            this.addressEmployee.Size = new System.Drawing.Size(401, 20);
            this.addressEmployee.TabIndex = 12;
            // 
            // salaryEmployee
            // 
            this.salaryEmployee.Location = new System.Drawing.Point(118, 225);
            this.salaryEmployee.Name = "salaryEmployee";
            this.salaryEmployee.Size = new System.Drawing.Size(401, 20);
            this.salaryEmployee.TabIndex = 13;
            // 
            // hireDateEmployee
            // 
            this.hireDateEmployee.Location = new System.Drawing.Point(118, 257);
            this.hireDateEmployee.Name = "hireDateEmployee";
            this.hireDateEmployee.Size = new System.Drawing.Size(334, 20);
            this.hireDateEmployee.TabIndex = 14;
            // 
            // saveEmployeeBtn
            // 
            this.saveEmployeeBtn.Location = new System.Drawing.Point(419, 300);
            this.saveEmployeeBtn.Name = "saveEmployeeBtn";
            this.saveEmployeeBtn.Size = new System.Drawing.Size(100, 23);
            this.saveEmployeeBtn.TabIndex = 15;
            this.saveEmployeeBtn.Text = "Save change";
            this.saveEmployeeBtn.UseVisualStyleBackColor = true;
            this.saveEmployeeBtn.Click += new System.EventHandler(this.saveEmployeeBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(419, 300);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(100, 23);
            this.addBtn.TabIndex = 18;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Visible = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // idEmployee
            // 
            this.idEmployee.AutoSize = true;
            this.idEmployee.Location = new System.Drawing.Point(115, 305);
            this.idEmployee.Name = "idEmployee";
            this.idEmployee.Size = new System.Drawing.Size(18, 13);
            this.idEmployee.TabIndex = 16;
            this.idEmployee.Text = "ID";
            // 
            // dateFomart
            // 
            this.dateFomart.AutoSize = true;
            this.dateFomart.Location = new System.Drawing.Point(458, 260);
            this.dateFomart.Name = "dateFomart";
            this.dateFomart.Size = new System.Drawing.Size(61, 13);
            this.dateFomart.TabIndex = 19;
            this.dateFomart.Text = "yyyy-mm-dd";
            // 
            // editForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 372);
            this.Controls.Add(this.dateFomart);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.idEmployee);
            this.Controls.Add(this.saveEmployeeBtn);
            this.Controls.Add(this.hireDateEmployee);
            this.Controls.Add(this.salaryEmployee);
            this.Controls.Add(this.addressEmployee);
            this.Controls.Add(this.phoneEmployee);
            this.Controls.Add(this.emailEmployee);
            this.Controls.Add(this.nameEmployee);
            this.Controls.Add(this.hireDate_label);
            this.Controls.Add(this.salary_label);
            this.Controls.Add(this.address_label);
            this.Controls.Add(this.phone_label);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "editForm";
            this.Text = "Edit Employee Form";
            this.Load += new System.EventHandler(this.editEmployeeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleForm;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label phone_label;
        private System.Windows.Forms.Label address_label;
        private System.Windows.Forms.Label salary_label;
        private System.Windows.Forms.Label hireDate_label;
        private System.Windows.Forms.TextBox nameEmployee;
        private System.Windows.Forms.TextBox emailEmployee;
        private System.Windows.Forms.TextBox phoneEmployee;
        private System.Windows.Forms.TextBox addressEmployee;
        private System.Windows.Forms.TextBox salaryEmployee;
        private System.Windows.Forms.TextBox hireDateEmployee;
        private System.Windows.Forms.Button saveEmployeeBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label idEmployee;
        private System.Windows.Forms.Label dateFomart;
    }
}