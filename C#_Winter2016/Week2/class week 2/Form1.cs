using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace class_week_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Run a function that adds items to the relationship combo box
            FillRelationshipList();

            //Set the default combo box options to "Please Choose one..."
            cmbState.SelectedIndex = 0;
            cmbRelationship.SelectedIndex = 0;
        }

        public void FillRelationshipList()
        {
            //Items to add to the "relationship" combo box
            cmbRelationship.Items.Add("Family");
            cmbRelationship.Items.Add("Friends");
            cmbRelationship.Items.Add("Co-Workers");
            cmbRelationship.Items.Add("Enimies");
            cmbRelationship.Items.Add("Family Pet");
            cmbRelationship.Items.Insert(0, "Please choose one...");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Items to clear when "clear" button is clicked
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = 0;
                else if (c is ListBox)
                    ((ListBox)c).Items.Clear();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Variable used to display salutation
            string salutation = "";

           //Loops that decide what salutation is equal to
            if (rdoMr.Checked == true)
                salutation = rdoMr.Text;
            else if (rdoMrs.Checked == true)
                salutation = rdoMrs.Text;
            else if (rdoMs.Checked == true)
                salutation = rdoMs.Text;

            //Output to lbContacts combobox
            lbContacts.Items.Add(
                salutation + 
                txtFirstName.Text + " "
                + txtLastName.Text + ", "
                + txtStreet1.Text + ", "
                + txtStreet2.Text + ", "
                + txtCity.Text + " "
                + cmbState.SelectedItem + ", "
                + txtZip.Text + ". "
                + txtEmail.Text + ". "
                + txtHomePhone.Text + ". "
                + txtWorkPhone.Text + ". "
                + txtCellPhone.Text + ". "
                + dtpBirthday.Value + ". "
                + dtpAnniversary.Value + ". "
                + cmbRelationship.SelectedItem + ". ");
        }
    }
}
