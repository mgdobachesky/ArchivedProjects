namespace appointmentManager
{
    partial class appointmentSearch
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
            this.dgvAppointmentSearch = new System.Windows.Forms.DataGridView();
            this.cmbAppointmentSearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAppointmentSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAppointmentSearchFeedback = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointmentSearch
            // 
            this.dgvAppointmentSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentSearch.Location = new System.Drawing.Point(12, 117);
            this.dgvAppointmentSearch.Name = "dgvAppointmentSearch";
            this.dgvAppointmentSearch.Size = new System.Drawing.Size(525, 187);
            this.dgvAppointmentSearch.TabIndex = 0;
            this.dgvAppointmentSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointmentSearch_CellContentClick);
            // 
            // cmbAppointmentSearch
            // 
            this.cmbAppointmentSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppointmentSearch.FormattingEnabled = true;
            this.cmbAppointmentSearch.Location = new System.Drawing.Point(66, 80);
            this.cmbAppointmentSearch.Name = "cmbAppointmentSearch";
            this.cmbAppointmentSearch.Size = new System.Drawing.Size(121, 21);
            this.cmbAppointmentSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search for Appointments";
            // 
            // btnAppointmentSearch
            // 
            this.btnAppointmentSearch.Location = new System.Drawing.Point(416, 78);
            this.btnAppointmentSearch.Name = "btnAppointmentSearch";
            this.btnAppointmentSearch.Size = new System.Drawing.Size(121, 23);
            this.btnAppointmentSearch.TabIndex = 2;
            this.btnAppointmentSearch.Text = "Search";
            this.btnAppointmentSearch.UseVisualStyleBackColor = true;
            this.btnAppointmentSearch.Click += new System.EventHandler(this.btnAppointmentSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name: ";
            // 
            // lblAppointmentSearchFeedback
            // 
            this.lblAppointmentSearchFeedback.AutoSize = true;
            this.lblAppointmentSearchFeedback.Location = new System.Drawing.Point(413, 57);
            this.lblAppointmentSearchFeedback.Name = "lblAppointmentSearchFeedback";
            this.lblAppointmentSearchFeedback.Size = new System.Drawing.Size(0, 13);
            this.lblAppointmentSearchFeedback.TabIndex = 4;
            // 
            // appointmentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 318);
            this.Controls.Add(this.lblAppointmentSearchFeedback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAppointmentSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAppointmentSearch);
            this.Controls.Add(this.dgvAppointmentSearch);
            this.Name = "appointmentSearch";
            this.Text = "appointmentSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppointmentSearch;
        private System.Windows.Forms.ComboBox cmbAppointmentSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAppointmentSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAppointmentSearchFeedback;
    }
}