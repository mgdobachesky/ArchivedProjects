namespace Week4
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMaidenName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblJedi = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtBadWords = new System.Windows.Forms.TextBox();
            this.txtCleaned = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(185, 149);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Text = "Michael";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(185, 175);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Text = "Dobachesky";
            // 
            // txtMaidenName
            // 
            this.txtMaidenName.Location = new System.Drawing.Point(186, 201);
            this.txtMaidenName.Name = "txtMaidenName";
            this.txtMaidenName.Size = new System.Drawing.Size(100, 20);
            this.txtMaidenName.TabIndex = 2;
            this.txtMaidenName.Text = "Charlotte";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(186, 227);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 3;
            this.txtCity.Text = "Milford";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "City Where You Were Born:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mother\'s Maiden Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "First Name:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate My Jedi Name!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblJedi
            // 
            this.lblJedi.AutoSize = true;
            this.lblJedi.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJedi.Location = new System.Drawing.Point(43, 50);
            this.lblJedi.Name = "lblJedi";
            this.lblJedi.Size = new System.Drawing.Size(0, 55);
            this.lblJedi.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Clean Up Bad Words";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBadWords
            // 
            this.txtBadWords.Location = new System.Drawing.Point(457, 50);
            this.txtBadWords.Multiline = true;
            this.txtBadWords.Name = "txtBadWords";
            this.txtBadWords.Size = new System.Drawing.Size(375, 46);
            this.txtBadWords.TabIndex = 17;
            this.txtBadWords.Text = "                                                                    ";
            // 
            // txtCleaned
            // 
            this.txtCleaned.Location = new System.Drawing.Point(457, 171);
            this.txtCleaned.Multiline = true;
            this.txtCleaned.Name = "txtCleaned";
            this.txtCleaned.Size = new System.Drawing.Size(375, 160);
            this.txtCleaned.TabIndex = 18;
            this.txtCleaned.Text = "                                                                    ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 394);
            this.Controls.Add(this.txtCleaned);
            this.Controls.Add(this.txtBadWords);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblJedi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtMaidenName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Name = "Form1";
            this.Text = "Jedi Name Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMaidenName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblJedi;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBadWords;
        private System.Windows.Forms.TextBox txtCleaned;
    }
}

