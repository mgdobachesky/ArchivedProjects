namespace appointmentManager
{
    partial class personSearch
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
            this.dgvPersonSearch = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastNamePersonSearch = new System.Windows.Forms.TextBox();
            this.txtFirstNamePersonSearch = new System.Windows.Forms.TextBox();
            this.btnPersonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersonSearch
            // 
            this.dgvPersonSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonSearch.Location = new System.Drawing.Point(12, 121);
            this.dgvPersonSearch.Name = "dgvPersonSearch";
            this.dgvPersonSearch.Size = new System.Drawing.Size(573, 199);
            this.dgvPersonSearch.TabIndex = 0;
            this.dgvPersonSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonSearch_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search for People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name: ";
            // 
            // txtLastNamePersonSearch
            // 
            this.txtLastNamePersonSearch.Location = new System.Drawing.Point(85, 75);
            this.txtLastNamePersonSearch.Name = "txtLastNamePersonSearch";
            this.txtLastNamePersonSearch.Size = new System.Drawing.Size(100, 20);
            this.txtLastNamePersonSearch.TabIndex = 2;
            // 
            // txtFirstNamePersonSearch
            // 
            this.txtFirstNamePersonSearch.Location = new System.Drawing.Point(85, 46);
            this.txtFirstNamePersonSearch.Name = "txtFirstNamePersonSearch";
            this.txtFirstNamePersonSearch.Size = new System.Drawing.Size(100, 20);
            this.txtFirstNamePersonSearch.TabIndex = 1;
            // 
            // btnPersonSearch
            // 
            this.btnPersonSearch.Location = new System.Drawing.Point(482, 75);
            this.btnPersonSearch.Name = "btnPersonSearch";
            this.btnPersonSearch.Size = new System.Drawing.Size(103, 23);
            this.btnPersonSearch.TabIndex = 3;
            this.btnPersonSearch.Text = "Search";
            this.btnPersonSearch.UseVisualStyleBackColor = true;
            this.btnPersonSearch.Click += new System.EventHandler(this.btnPersonSearch_Click);
            // 
            // personSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 333);
            this.Controls.Add(this.btnPersonSearch);
            this.Controls.Add(this.txtFirstNamePersonSearch);
            this.Controls.Add(this.txtLastNamePersonSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPersonSearch);
            this.Name = "personSearch";
            this.Text = "personSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastNamePersonSearch;
        private System.Windows.Forms.TextBox txtFirstNamePersonSearch;
        private System.Windows.Forms.Button btnPersonSearch;
    }
}