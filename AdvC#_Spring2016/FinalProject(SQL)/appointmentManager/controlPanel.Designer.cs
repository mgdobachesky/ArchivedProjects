namespace appointmentManager
{
    partial class controlPanel
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
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnSearchPeople = new System.Windows.Forms.Button();
            this.btnSearchAppointments = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoginFeedback = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(78, 33);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(100, 20);
            this.txtLoginPassword.TabIndex = 6;
            this.txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.Location = new System.Drawing.Point(78, 7);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(100, 20);
            this.txtLoginUsername.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(17, 39);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(100, 23);
            this.btnAddPerson.TabIndex = 1;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Location = new System.Drawing.Point(148, 39);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(100, 23);
            this.btnAddAppointment.TabIndex = 3;
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // btnSearchPeople
            // 
            this.btnSearchPeople.Location = new System.Drawing.Point(17, 68);
            this.btnSearchPeople.Name = "btnSearchPeople";
            this.btnSearchPeople.Size = new System.Drawing.Size(100, 23);
            this.btnSearchPeople.TabIndex = 2;
            this.btnSearchPeople.Text = "Search People";
            this.btnSearchPeople.UseVisualStyleBackColor = true;
            this.btnSearchPeople.Click += new System.EventHandler(this.btnSearchPeople_Click);
            // 
            // btnSearchAppointments
            // 
            this.btnSearchAppointments.Location = new System.Drawing.Point(148, 68);
            this.btnSearchAppointments.Name = "btnSearchAppointments";
            this.btnSearchAppointments.Size = new System.Drawing.Size(100, 23);
            this.btnSearchAppointments.TabIndex = 4;
            this.btnSearchAppointments.Text = "Search Apts.";
            this.btnSearchAppointments.UseVisualStyleBackColor = true;
            this.btnSearchAppointments.Click += new System.EventHandler(this.btnSearchAppointments_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(78, 59);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.txtLoginPassword);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.txtLoginUsername);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Location = new System.Drawing.Point(62, 169);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(200, 100);
            this.pnlLogin.TabIndex = 9;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.btnAddPerson);
            this.pnlControls.Controls.Add(this.btnSearchAppointments);
            this.pnlControls.Controls.Add(this.btnAddAppointment);
            this.pnlControls.Controls.Add(this.btnSearchPeople);
            this.pnlControls.Location = new System.Drawing.Point(26, 50);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(268, 112);
            this.pnlControls.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "People";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(141, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Appointments";
            // 
            // lblLoginFeedback
            // 
            this.lblLoginFeedback.AutoSize = true;
            this.lblLoginFeedback.Location = new System.Drawing.Point(137, 272);
            this.lblLoginFeedback.Name = "lblLoginFeedback";
            this.lblLoginFeedback.Size = new System.Drawing.Size(0, 13);
            this.lblLoginFeedback.TabIndex = 10;
            // 
            // controlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 308);
            this.Controls.Add(this.lblLoginFeedback);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlLogin);
            this.Name = "controlPanel";
            this.Text = "controlPanel";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnSearchPeople;
        private System.Windows.Forms.Button btnSearchAppointments;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLoginFeedback;
    }
}