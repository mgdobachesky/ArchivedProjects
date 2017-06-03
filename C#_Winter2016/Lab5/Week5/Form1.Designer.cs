namespace Week5
{
    partial class Form1
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
            this.grpPizzaSize = new System.Windows.Forms.GroupBox();
            this.rdoLarge = new System.Windows.Forms.RadioButton();
            this.rdoMedium = new System.Windows.Forms.RadioButton();
            this.rdoSmall = new System.Windows.Forms.RadioButton();
            this.grpPizzaToppings = new System.Windows.Forms.GroupBox();
            this.chkOlives = new System.Windows.Forms.CheckBox();
            this.chkPeppers = new System.Windows.Forms.CheckBox();
            this.chkHam = new System.Windows.Forms.CheckBox();
            this.chkBbqSauce = new System.Windows.Forms.CheckBox();
            this.chkExtraCheese = new System.Windows.Forms.CheckBox();
            this.chkAnchovies = new System.Windows.Forms.CheckBox();
            this.chkPineapple = new System.Windows.Forms.CheckBox();
            this.chkSpinach = new System.Windows.Forms.CheckBox();
            this.chkOnions = new System.Windows.Forms.CheckBox();
            this.chkMeatball = new System.Windows.Forms.CheckBox();
            this.chkSausage = new System.Windows.Forms.CheckBox();
            this.chkPepperoni = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtStreet2 = new System.Windows.Forms.TextBox();
            this.txtStreet1 = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblStreet2 = new System.Windows.Forms.Label();
            this.lblStreet1 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.lstOrder = new System.Windows.Forms.ListBox();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.txtDelete = new System.Windows.Forms.Button();
            this.dtpPickup = new System.Windows.Forms.DateTimePicker();
            this.lblPickup = new System.Windows.Forms.Label();
            this.grpPizzaSize.SuspendLayout();
            this.grpPizzaToppings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPizzaSize
            // 
            this.grpPizzaSize.Controls.Add(this.rdoLarge);
            this.grpPizzaSize.Controls.Add(this.rdoMedium);
            this.grpPizzaSize.Controls.Add(this.rdoSmall);
            this.grpPizzaSize.Location = new System.Drawing.Point(28, 35);
            this.grpPizzaSize.Name = "grpPizzaSize";
            this.grpPizzaSize.Size = new System.Drawing.Size(200, 104);
            this.grpPizzaSize.TabIndex = 100;
            this.grpPizzaSize.TabStop = false;
            this.grpPizzaSize.Text = "Pizza Size";
            // 
            // rdoLarge
            // 
            this.rdoLarge.AutoSize = true;
            this.rdoLarge.Location = new System.Drawing.Point(6, 66);
            this.rdoLarge.Name = "rdoLarge";
            this.rdoLarge.Size = new System.Drawing.Size(79, 17);
            this.rdoLarge.TabIndex = 2;
            this.rdoLarge.TabStop = true;
            this.rdoLarge.Text = "Large ($12)";
            this.rdoLarge.UseVisualStyleBackColor = true;
            // 
            // rdoMedium
            // 
            this.rdoMedium.AutoSize = true;
            this.rdoMedium.Location = new System.Drawing.Point(6, 43);
            this.rdoMedium.Name = "rdoMedium";
            this.rdoMedium.Size = new System.Drawing.Size(89, 17);
            this.rdoMedium.TabIndex = 1;
            this.rdoMedium.TabStop = true;
            this.rdoMedium.Text = "Medium ($10)";
            this.rdoMedium.UseVisualStyleBackColor = true;
            // 
            // rdoSmall
            // 
            this.rdoSmall.AutoSize = true;
            this.rdoSmall.Location = new System.Drawing.Point(6, 20);
            this.rdoSmall.Name = "rdoSmall";
            this.rdoSmall.Size = new System.Drawing.Size(71, 17);
            this.rdoSmall.TabIndex = 0;
            this.rdoSmall.TabStop = true;
            this.rdoSmall.Text = "Small ($7)";
            this.rdoSmall.UseVisualStyleBackColor = true;
            // 
            // grpPizzaToppings
            // 
            this.grpPizzaToppings.Controls.Add(this.chkOlives);
            this.grpPizzaToppings.Controls.Add(this.chkPeppers);
            this.grpPizzaToppings.Controls.Add(this.chkHam);
            this.grpPizzaToppings.Controls.Add(this.chkBbqSauce);
            this.grpPizzaToppings.Controls.Add(this.chkExtraCheese);
            this.grpPizzaToppings.Controls.Add(this.chkAnchovies);
            this.grpPizzaToppings.Controls.Add(this.chkPineapple);
            this.grpPizzaToppings.Controls.Add(this.chkSpinach);
            this.grpPizzaToppings.Controls.Add(this.chkOnions);
            this.grpPizzaToppings.Controls.Add(this.chkMeatball);
            this.grpPizzaToppings.Controls.Add(this.chkSausage);
            this.grpPizzaToppings.Controls.Add(this.chkPepperoni);
            this.grpPizzaToppings.Location = new System.Drawing.Point(28, 158);
            this.grpPizzaToppings.Name = "grpPizzaToppings";
            this.grpPizzaToppings.Size = new System.Drawing.Size(286, 118);
            this.grpPizzaToppings.TabIndex = 101;
            this.grpPizzaToppings.TabStop = false;
            this.grpPizzaToppings.Text = "Pizza Toppings (50 Cents Per)";
            // 
            // chkOlives
            // 
            this.chkOlives.AutoSize = true;
            this.chkOlives.Location = new System.Drawing.Point(107, 65);
            this.chkOlives.Name = "chkOlives";
            this.chkOlives.Size = new System.Drawing.Size(55, 17);
            this.chkOlives.TabIndex = 9;
            this.chkOlives.Text = "Olives";
            this.chkOlives.UseVisualStyleBackColor = true;
            // 
            // chkPeppers
            // 
            this.chkPeppers.AutoSize = true;
            this.chkPeppers.Location = new System.Drawing.Point(107, 19);
            this.chkPeppers.Name = "chkPeppers";
            this.chkPeppers.Size = new System.Drawing.Size(65, 17);
            this.chkPeppers.TabIndex = 7;
            this.chkPeppers.Text = "Peppers";
            this.chkPeppers.UseVisualStyleBackColor = true;
            // 
            // chkHam
            // 
            this.chkHam.AutoSize = true;
            this.chkHam.Location = new System.Drawing.Point(15, 88);
            this.chkHam.Name = "chkHam";
            this.chkHam.Size = new System.Drawing.Size(48, 17);
            this.chkHam.TabIndex = 6;
            this.chkHam.Text = "Ham";
            this.chkHam.UseVisualStyleBackColor = true;
            // 
            // chkBbqSauce
            // 
            this.chkBbqSauce.AutoSize = true;
            this.chkBbqSauce.Location = new System.Drawing.Point(193, 42);
            this.chkBbqSauce.Name = "chkBbqSauce";
            this.chkBbqSauce.Size = new System.Drawing.Size(82, 17);
            this.chkBbqSauce.TabIndex = 12;
            this.chkBbqSauce.Text = "BBQ Sauce";
            this.chkBbqSauce.UseVisualStyleBackColor = true;
            // 
            // chkExtraCheese
            // 
            this.chkExtraCheese.AutoSize = true;
            this.chkExtraCheese.Location = new System.Drawing.Point(193, 65);
            this.chkExtraCheese.Name = "chkExtraCheese";
            this.chkExtraCheese.Size = new System.Drawing.Size(89, 17);
            this.chkExtraCheese.TabIndex = 13;
            this.chkExtraCheese.Text = "Extra Cheese";
            this.chkExtraCheese.UseVisualStyleBackColor = true;
            // 
            // chkAnchovies
            // 
            this.chkAnchovies.AutoSize = true;
            this.chkAnchovies.Location = new System.Drawing.Point(193, 88);
            this.chkAnchovies.Name = "chkAnchovies";
            this.chkAnchovies.Size = new System.Drawing.Size(76, 17);
            this.chkAnchovies.TabIndex = 14;
            this.chkAnchovies.Text = "Anchovies";
            this.chkAnchovies.UseVisualStyleBackColor = true;
            // 
            // chkPineapple
            // 
            this.chkPineapple.AutoSize = true;
            this.chkPineapple.Location = new System.Drawing.Point(193, 19);
            this.chkPineapple.Name = "chkPineapple";
            this.chkPineapple.Size = new System.Drawing.Size(73, 17);
            this.chkPineapple.TabIndex = 11;
            this.chkPineapple.Text = "Pineapple";
            this.chkPineapple.UseVisualStyleBackColor = true;
            // 
            // chkSpinach
            // 
            this.chkSpinach.AutoSize = true;
            this.chkSpinach.Location = new System.Drawing.Point(107, 88);
            this.chkSpinach.Name = "chkSpinach";
            this.chkSpinach.Size = new System.Drawing.Size(65, 17);
            this.chkSpinach.TabIndex = 10;
            this.chkSpinach.Text = "Spinach";
            this.chkSpinach.UseVisualStyleBackColor = true;
            // 
            // chkOnions
            // 
            this.chkOnions.AutoSize = true;
            this.chkOnions.Location = new System.Drawing.Point(107, 42);
            this.chkOnions.Name = "chkOnions";
            this.chkOnions.Size = new System.Drawing.Size(59, 17);
            this.chkOnions.TabIndex = 8;
            this.chkOnions.Text = "Onions";
            this.chkOnions.UseVisualStyleBackColor = true;
            // 
            // chkMeatball
            // 
            this.chkMeatball.AutoSize = true;
            this.chkMeatball.Location = new System.Drawing.Point(15, 65);
            this.chkMeatball.Name = "chkMeatball";
            this.chkMeatball.Size = new System.Drawing.Size(66, 17);
            this.chkMeatball.TabIndex = 5;
            this.chkMeatball.Text = "Meatball";
            this.chkMeatball.UseVisualStyleBackColor = true;
            // 
            // chkSausage
            // 
            this.chkSausage.AutoSize = true;
            this.chkSausage.Location = new System.Drawing.Point(15, 42);
            this.chkSausage.Name = "chkSausage";
            this.chkSausage.Size = new System.Drawing.Size(68, 17);
            this.chkSausage.TabIndex = 4;
            this.chkSausage.Text = "Sausage";
            this.chkSausage.UseVisualStyleBackColor = true;
            // 
            // chkPepperoni
            // 
            this.chkPepperoni.AutoSize = true;
            this.chkPepperoni.Location = new System.Drawing.Point(15, 19);
            this.chkPepperoni.Name = "chkPepperoni";
            this.chkPepperoni.Size = new System.Drawing.Size(74, 17);
            this.chkPepperoni.TabIndex = 3;
            this.chkPepperoni.Text = "Pepperoni";
            this.chkPepperoni.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(411, 176);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 18;
            this.txtEmail.Text = "email@email.com";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(411, 150);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 17;
            this.txtPhone.Text = "2165245";
            // 
            // txtStreet2
            // 
            this.txtStreet2.Location = new System.Drawing.Point(600, 125);
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size(100, 20);
            this.txtStreet2.TabIndex = 20;
            this.txtStreet2.Text = "2 Street St.";
            // 
            // txtStreet1
            // 
            this.txtStreet1.Location = new System.Drawing.Point(600, 98);
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.Size = new System.Drawing.Size(100, 20);
            this.txtStreet1.TabIndex = 19;
            this.txtStreet1.Text = "1 Street St.";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(411, 124);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 16;
            this.txtLastName.Text = "Dobachesky";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(411, 98);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 15;
            this.txtFirstName.Text = "Michael";
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(600, 176);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(100, 21);
            this.cmbState.TabIndex = 22;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(559, 179);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 109;
            this.lblState.Text = "State:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(567, 152);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 108;
            this.lblCity.Text = "City:";
            // 
            // lblStreet2
            // 
            this.lblStreet2.AutoSize = true;
            this.lblStreet2.Location = new System.Drawing.Point(547, 128);
            this.lblStreet2.Name = "lblStreet2";
            this.lblStreet2.Size = new System.Drawing.Size(47, 13);
            this.lblStreet2.TabIndex = 107;
            this.lblStreet2.Text = "Street 2:";
            // 
            // lblStreet1
            // 
            this.lblStreet1.AutoSize = true;
            this.lblStreet1.Location = new System.Drawing.Point(547, 101);
            this.lblStreet1.Name = "lblStreet1";
            this.lblStreet1.Size = new System.Drawing.Size(47, 13);
            this.lblStreet1.TabIndex = 106;
            this.lblStreet1.Text = "Street 1:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(370, 179);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 105;
            this.lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(364, 153);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 104;
            this.lblPhone.Text = "Phone:";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(348, 127);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(61, 13);
            this.lblLast.TabIndex = 103;
            this.lblLast.Text = "Last Name:";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Location = new System.Drawing.Point(349, 101);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(60, 13);
            this.lblFirst.TabIndex = 102;
            this.lblFirst.Text = "First Name:";
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(600, 149);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(100, 21);
            this.cmbCity.TabIndex = 21;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(443, 246);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(192, 23);
            this.btnPlaceOrder.TabIndex = 24;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // lstOrder
            // 
            this.lstOrder.FormattingEnabled = true;
            this.lstOrder.Location = new System.Drawing.Point(28, 308);
            this.lstOrder.Name = "lstOrder";
            this.lstOrder.Size = new System.Drawing.Size(672, 186);
            this.lstOrder.TabIndex = 110;
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(408, 16);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(0, 13);
            this.lblFeedback.TabIndex = 111;
            // 
            // txtDelete
            // 
            this.txtDelete.Location = new System.Drawing.Point(262, 513);
            this.txtDelete.Name = "txtDelete";
            this.txtDelete.Size = new System.Drawing.Size(192, 23);
            this.txtDelete.TabIndex = 25;
            this.txtDelete.Text = "Delete Oldest Order";
            this.txtDelete.UseVisualStyleBackColor = true;
            this.txtDelete.Click += new System.EventHandler(this.txtDelete_Click);
            // 
            // dtpPickup
            // 
            this.dtpPickup.Location = new System.Drawing.Point(600, 203);
            this.dtpPickup.Name = "dtpPickup";
            this.dtpPickup.Size = new System.Drawing.Size(100, 20);
            this.dtpPickup.TabIndex = 23;
            // 
            // lblPickup
            // 
            this.lblPickup.AutoSize = true;
            this.lblPickup.Location = new System.Drawing.Point(548, 205);
            this.lblPickup.Name = "lblPickup";
            this.lblPickup.Size = new System.Drawing.Size(46, 13);
            this.lblPickup.TabIndex = 114;
            this.lblPickup.Text = "Pick-up:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 558);
            this.Controls.Add(this.lblPickup);
            this.Controls.Add(this.dtpPickup);
            this.Controls.Add(this.txtDelete);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lstOrder);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblStreet1);
            this.Controls.Add(this.lblStreet2);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtStreet1);
            this.Controls.Add(this.txtStreet2);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.grpPizzaToppings);
            this.Controls.Add(this.grpPizzaSize);
            this.Name = "Form1";
            this.Text = "Pizza Order Form";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.grpPizzaSize.ResumeLayout(false);
            this.grpPizzaSize.PerformLayout();
            this.grpPizzaToppings.ResumeLayout(false);
            this.grpPizzaToppings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPizzaSize;
        private System.Windows.Forms.RadioButton rdoLarge;
        private System.Windows.Forms.RadioButton rdoMedium;
        private System.Windows.Forms.RadioButton rdoSmall;
        private System.Windows.Forms.GroupBox grpPizzaToppings;
        private System.Windows.Forms.CheckBox chkOlives;
        private System.Windows.Forms.CheckBox chkPeppers;
        private System.Windows.Forms.CheckBox chkHam;
        private System.Windows.Forms.CheckBox chkBbqSauce;
        private System.Windows.Forms.CheckBox chkExtraCheese;
        private System.Windows.Forms.CheckBox chkAnchovies;
        private System.Windows.Forms.CheckBox chkPineapple;
        private System.Windows.Forms.CheckBox chkSpinach;
        private System.Windows.Forms.CheckBox chkOnions;
        private System.Windows.Forms.CheckBox chkMeatball;
        private System.Windows.Forms.CheckBox chkSausage;
        private System.Windows.Forms.CheckBox chkPepperoni;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtStreet2;
        private System.Windows.Forms.TextBox txtStreet1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblStreet2;
        private System.Windows.Forms.Label lblStreet1;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.ListBox lstOrder;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Button txtDelete;
        private System.Windows.Forms.DateTimePicker dtpPickup;
        private System.Windows.Forms.Label lblPickup;

    }
}

