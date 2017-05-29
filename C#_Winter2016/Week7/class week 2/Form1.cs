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
                feedbackMessage.Text += "Please fill in your first name. \n";
            }

            //Checks to see if last name is valid
            if (!validation.isFilledIn(txtLastName.Text))
            {
                isValid = false;
                feedbackMessage.Text += "Please fill in your last name. \n";
            }

            //Checks to see if a state is selected
            if (validation.isFilledIn(cmbState.SelectedItem.ToString(), 2))
            {
                isValid = false;
                feedbackMessage.Text += "Please choose a state. \n";
            }

            //Checks to see if a zip is valid
            if (!validation.isExactFilledIn(txtZip.Text, 5))
            {
                isValid = false;
                feedbackMessage.Text += "Please enter a valid zip code. \n";
            }
           
            //Checks to see if email is valid
            if (validation.isFilledIn(txtEmail.Text))
            {
                if (validation.validEmail(txtEmail.Text) == false)
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid email address. \n";
                }
            }

            //Checks to see if home phone is at least seven character long
            if (validation.isFilledIn(txtHomePhone.Text))
            {
                if (!validation.isFilledIn(txtHomePhone.Text, 6))
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid phone number. \n";
                }
            }

            //Checks to see if work phone is at least  character long
            if (validation.isFilledIn(txtWorkPhone.Text))
            {
                if (!validation.isFilledIn(txtWorkPhone.Text, 6))
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid phone number. \n";
                }
            }

            //Checks to see if cell phone is at least seven character long
            if (validation.isFilledIn(txtCellPhone.Text))
            {
                if (!validation.isFilledIn(txtCellPhone.Text, 6))
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid phone number. \n";
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

                //Output verification that the contact was added
                feedbackMessage.Text += "Contact successfully added. \n";

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
                string result = fileIO.writeFile(@"contacts.csv", dataRecord);

                if (result != "OK")
                {
                    feedbackMessage.Text = result;
                }
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            //Clear text box and feedback message
            lbContacts.Items.Clear();
            feedbackMessage.Text = "";

            //Create string to hold data
            string[] dataString = new string[100];

            //Get data from the file
            dataString = fileIO.readFile(@"contacts.csv");
            
            //Display error messages if appropriate
            if (dataString[0].Contains("ERROR:"))
            {
                feedbackMessage.Text = dataString[0];
            }
                
            //If there are no errors then display data
            else
            {
                //Count number of non-null array elements and store in variable
                int result = dataString.Count(s => s != null);

                for (int loop = 0; loop < result; loop++)
                {
                    //Get comma location to use in string parsing
                    int commaLocation1 = dataString[loop].IndexOf(",");
                    int commaLocation2 = dataString[loop].IndexOf(",", commaLocation1 + 1);
                    int commaLocation3 = dataString[loop].IndexOf(",", commaLocation2 + 1);
                    int commaLocation4 = dataString[loop].IndexOf(",", commaLocation3 + 1);
                    int commaLocation5 = dataString[loop].IndexOf(",", commaLocation4 + 1);
                    int commaLocation6 = dataString[loop].IndexOf(",", commaLocation5 + 1);
                    int commaLocation7 = dataString[loop].IndexOf(",", commaLocation6 + 1);
                    int commaLocation8 = dataString[loop].IndexOf(",", commaLocation7 + 1);
                    int commaLocation9 = dataString[loop].IndexOf(",", commaLocation8 + 1);
                    int commaLocation10 = dataString[loop].IndexOf(",", commaLocation9 + 1);
                    int commaLocation11 = dataString[loop].IndexOf(",", commaLocation10 + 1);
                    int commaLocation12 = dataString[loop].IndexOf(",", commaLocation11 + 1);
                    int commaLocation13 = dataString[loop].IndexOf(",", commaLocation12 + 1);
                    int commaLocation14 = dataString[loop].IndexOf(",", commaLocation13 + 1);
                    int commaLocation15 = dataString[loop].IndexOf(",", commaLocation14 + 1);

                    //Get the length of each element to be used in string parsing
                    int dataRecordLength = commaLocation1;
                    int salutationLength = commaLocation2 - commaLocation1 - 1;
                    int firstLength = commaLocation3 - commaLocation2 - 1;
                    int lastLength = commaLocation4 - commaLocation3 - 1;
                    int street1Length = commaLocation5 - commaLocation4 - 1;
                    int street2Length = commaLocation6 - commaLocation5 - 1;
                    int cityLength = commaLocation7 - commaLocation6 - 1;
                    int stateLength = commaLocation8 - commaLocation7 - 1;
                    int zipLength = commaLocation9 - commaLocation8 - 1;
                    int emailLength = commaLocation10 - commaLocation9 - 1;
                    int homePhoneLength = commaLocation11 - commaLocation10 - 1;
                    int workPhoneLength = commaLocation12 - commaLocation11 - 1;
                    int cellPhoneLength = commaLocation13 - commaLocation12 - 1;
                    int birthdayLength = commaLocation14 - commaLocation13 - 1;
                    int anniversaryLength = commaLocation15 - commaLocation14 - 1;

                    //Parse each element out of the string
                    string parseDataRecord = dataString[loop].Substring(0, dataRecordLength);
                    string parseSalutation = dataString[loop].Substring(commaLocation1 + 1, salutationLength);
                    string parseFirst = dataString[loop].Substring(commaLocation2 + 1, firstLength);
                    string parseLast = dataString[loop].Substring(commaLocation3 + 1, lastLength);
                    string parseStreet1 = dataString[loop].Substring(commaLocation4 + 1, street1Length);
                    string parseStreet2 = dataString[loop].Substring(commaLocation5 + 1, street2Length);
                    string parseCity = dataString[loop].Substring(commaLocation6 + 1, cityLength);
                    string parseState = dataString[loop].Substring(commaLocation7 + 1, stateLength);
                    string parseZip = dataString[loop].Substring(commaLocation8 + 1, zipLength);
                    string parseEmail = dataString[loop].Substring(commaLocation9 + 1, emailLength);
                    string parseHomePhone = dataString[loop].Substring(commaLocation10 + 1, homePhoneLength);
                    string parseWorkPhone = dataString[loop].Substring(commaLocation11 + 1, workPhoneLength);
                    string parseCellPhone = dataString[loop].Substring(commaLocation12 + 1, cellPhoneLength);
                    string parseBithday = dataString[loop].Substring(commaLocation13 + 1, birthdayLength);
                    string parseAnniversary = dataString[loop].Substring(commaLocation14 + 1, anniversaryLength);
                    string parseRelationship = dataString[loop].Substring(commaLocation15 + 1);

                    //Display parsed elements
                    lbContacts.Items.Add("Name: " + parseFirst + " " + parseLast);
                    lbContacts.Items.Add("Email: " + parseEmail);
                    lbContacts.Items.Add("");
                }
            }
        }
    }
}