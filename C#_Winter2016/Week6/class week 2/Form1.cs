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
                feedbackMessage.Text = "";

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Clear feedback from previous messages
            feedbackMessage.Text = "";

            bool isValid = true;

            //Checks to see if first name is valid
            if (!validation.isFilledIn(txtFirstName.Text))
            {
                isValid = false;
                feedbackMessage.Text += "Please fill in your first name \n";
            }

            //Checks to see if last name is valid
            if (!validation.isFilledIn(txtLastName.Text))
            {
                isValid = false;
                feedbackMessage.Text += "Please fill in your last name \n";
            }

            //Checks to see if a state is selected
            if (validation.isFilledIn(cmbState.SelectedItem.ToString(), 2))
            {
                isValid = false;
                feedbackMessage.Text += "Please choose a state \n";
            }

            //Checks to see if a zip is valid
            if (!validation.isExactFilledIn(txtZip.Text, 5))
            {
                isValid = false;
                feedbackMessage.Text += "Please enter a valid zip code \n";
            }
           
            //Checks to see if email is valid
            if (validation.isFilledIn(txtEmail.Text))
            {
                if (validation.validEmail(txtEmail.Text) == false)
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid email address \n";
                }
            }

            //Checks to see if phone numbers are at least seven character long
            if (validation.isFilledIn(txtHomePhone.Text) || validation.isFilledIn(txtWorkPhone.Text) || validation.isFilledIn(txtCellPhone.Text))
            {
                if (!validation.isFilledIn(txtHomePhone.Text, 6) || !validation.isFilledIn(txtWorkPhone.Text, 6) || !validation.isFilledIn(txtCellPhone.Text, 6))
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid phone number \n";
                }
            }

            //If nothing is invalid, the information is saved in the list box
            if (isValid)
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
                    salutation + " " +
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

                //Store comma delimited data in a variable
                string dataRecord = DateTime.Now.ToShortDateString() + ","
                    + salutation + "," 
                    + txtFirstName.Text + ","
                    + txtLastName.Text + ","
                    + txtStreet1.Text + ","
                    + txtStreet2.Text + ","
                    + txtCity.Text + ","
                    + cmbState.SelectedItem + ","
                    + txtZip.Text + ","
                    + txtEmail.Text + ","
                    + txtHomePhone.Text + ","
                    + txtWorkPhone.Text + ","
                    + txtCellPhone.Text + ","
                    + dtpBirthday.Value + ","
                    + dtpAnniversary.Value + ","
                    + cmbRelationship.SelectedItem;

                //Send the data to a file
                string result = fileIO.writeFile(@"payroll.csv", dataRecord);

                if (result != "OK")
                {
                    feedbackMessage.Text = result;
                }
            }
        }
    }
}
