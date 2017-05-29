using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace class_week_2
{
    public partial class Form1 : Form
    {
        //Create dynamic arrays to hold each persons data, and an index to access them with
        int index;
        List<string> dateDynamic = new List<string>();
        List<string> salutationDynamic = new List<string>();
        List<string> fNameDynamic = new List<string>();
        List<string> lNameDynamic = new List<string>();
        List<string> street1Dynamic = new List<string>();
        List<string> street2Dynamic = new List<string>();
        List<string> cityDynamic = new List<string>();
        List<string> stateDynamic = new List<string>();
        List<string> zipDynamic = new List<string>();
        List<string> emailDynamic = new List<string>();
        List<string> homePhoneDynamic = new List<string>();
        List<string> workPhoneDynamic = new List<string>();
        List<string> cellPhoneDynamic = new List<string>();
        List<string> birthdayDynamic = new List<string>();
        List<string> anniversaryDynamic = new List<string>();
        List<string> relationshipDynamic = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //start off index at 0
            index = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //run a function that adds items to the relationship combo box
            FillRelationshipList();

            //set the default combo box options to "Please Choose one..."
            cmbState.SelectedIndex = 0;
            cmbRelationship.SelectedIndex = 0;
        }

        public void FillRelationshipList()
        {
            //items to add to the "relationship" combo box
            cmbRelationship.Items.Add("Family");
            cmbRelationship.Items.Add("Friends");
            cmbRelationship.Items.Add("Co-Workers");
            cmbRelationship.Items.Add("Enimies");
            cmbRelationship.Items.Add("Family Pet");
            cmbRelationship.Items.Insert(0, "Please choose one...");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //items to clear when "clear" button is clicked
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
            //clear feedback from previous messages
            feedbackMessage.Text = "";

            bool isValid = true;

            //checks to see if first name is valid
            if (!validation.isFilledIn(txtFirstName.Text))
            {
                isValid = false;
                feedbackMessage.Text += "Please fill in your first name. \n";
            }

            //checks to see if last name is valid
            if (!validation.isFilledIn(txtLastName.Text))
            {
                isValid = false;
                feedbackMessage.Text += "Please fill in your last name. \n";
            }

            //checks to see if a state is selected
            if (validation.isFilledIn(cmbState.SelectedItem.ToString(), 2))
            {
                isValid = false;
                feedbackMessage.Text += "Please choose a state. \n";
            }

            //checks to see if a zip is valid
            if (!validation.isExactFilledIn(txtZip.Text, 5))
            {
                isValid = false;
                feedbackMessage.Text += "Please enter a valid zip code. \n";
            }
           
            //checks to see if email is valid
            if (validation.isFilledIn(txtEmail.Text))
            {
                if (validation.validEmail(txtEmail.Text) == false)
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid email address. \n";
                }
            }

            //checks to see if home phone is at least seven character long
            if (validation.isFilledIn(txtHomePhone.Text))
            {
                if (!validation.isFilledIn(txtHomePhone.Text, 6))
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid phone number. \n";
                }
            }

            //checks to see if work phone is at least  character long
            if (validation.isFilledIn(txtWorkPhone.Text))
            {
                if (!validation.isFilledIn(txtWorkPhone.Text, 6))
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid phone number. \n";
                }
            }

            //checks to see if cell phone is at least seven character long
            if (validation.isFilledIn(txtCellPhone.Text))
            {
                if (!validation.isFilledIn(txtCellPhone.Text, 6))
                {
                    isValid = false;
                    feedbackMessage.Text += "Please enter a valid phone number. \n";
                }
            }

            //if nothing is invalid, the information is saved in the list box
            if (isValid)
            {
                //variable used to display salutation
                string salutation = "";

                //loops that decide what salutation is equal to
                if (rdoMr.Checked == true)
                    salutation = rdoMr.Text;
                else if (rdoMrs.Checked == true)
                    salutation = rdoMrs.Text;
                else if (rdoMs.Checked == true)
                    salutation = rdoMs.Text;

                //output verification that the contact was added
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

                //send the data to a file
                string result = fileIO.writeFile(@"contacts.csv", dataRecord);

                if (result != "OK")
                {
                    feedbackMessage.Text = result;
                }
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            //clear text box and feedback message
            lbContacts.Items.Clear();
            feedbackMessage.Text = "";

            //create string to hold data
            string dataString = "";

            //populate lists
            fillLists(@"contacts.csv", dateDynamic, salutationDynamic, fNameDynamic, lNameDynamic, street1Dynamic, street2Dynamic, cityDynamic, stateDynamic, zipDynamic,
                emailDynamic, homePhoneDynamic, workPhoneDynamic, cellPhoneDynamic, birthdayDynamic, anniversaryDynamic, relationshipDynamic);
            
            //display error messages if appropriate
            if (dataString.Contains("ERROR:"))
            {
                feedbackMessage.Text = dataString;
            }
                
            //if there are no errors then display data
            else
            {
                feedbackMessage.Text = dataString;
            }
        }

        public void fillLists(string fileName, List<string> dateDynamic, List<string> salutationDynameic, List<string> fNameDynamic,
            List<string> lNameDynamic, List<string> street1Dynamic, List<string> street2Dynamic, List<string> cityDynamic,
            List<string> stateDyamic, List<string> zipDynamic, List<string> emailDynamic, List<string> homePhoneDynamic,
            List<string> workPhoneDynamic, List<string> cellPhoneDynamic, List<string> birthdayDynamic, List<string> anniversaryDynamic,
            List<string> relationshipDynamic)
        {
            //clear existing data
            dateDynamic.Clear();
            salutationDynamic.Clear();
            fNameDynamic.Clear();
            lNameDynamic.Clear();
            street1Dynamic.Clear();
            street2Dynamic.Clear();
            cityDynamic.Clear();
            stateDynamic.Clear();
            zipDynamic.Clear();
            emailDynamic.Clear();
            homePhoneDynamic.Clear();
            workPhoneDynamic.Clear();
            cellPhoneDynamic.Clear();
            birthdayDynamic.Clear();
            anniversaryDynamic.Clear();
            relationshipDynamic.Clear();

            //create StreamReader object
            StreamReader sr;

            try
            {
                //open the file to input to
                sr = new StreamReader(File.Open(@fileName, FileMode.Open));

                try
                {
                    //while haven't reached end of file
                    while (sr.Peek() != -1)
                    {
                        //row contains a record from textfile
                        string row = sr.ReadLine();

                        //creates an array for the columns
                        string[] columns = row.Split(',');

                        //break data into pieces
                        dateDynamic.Add(columns[0]);
                        salutationDynamic.Add(columns[1]);
                        fNameDynamic.Add(columns[2]);
                        lNameDynamic.Add(columns[3]);
                        street1Dynamic.Add(columns[4]);
                        street2Dynamic.Add(columns[5]);
                        cityDynamic.Add(columns[6]);
                        stateDynamic.Add(columns[7]);
                        zipDynamic.Add(columns[8]);
                        emailDynamic.Add(columns[9]);
                        homePhoneDynamic.Add(columns[10]);
                        workPhoneDynamic.Add(columns[11]);
                        cellPhoneDynamic.Add(columns[12]);
                        birthdayDynamic.Add(columns[13]);
                        anniversaryDynamic.Add(columns[14]);
                        relationshipDynamic.Add(columns[15]);
                    }
                }

            finally
                {
                    //close file
                    sr.Close();
                }

            }

            catch(Exception exc)
                {
                    //store the error message
                    string x = exc.Message;
                }

            //populate the form
            fillForm(index);
        }

        //fill the form with current records data
        public void fillForm(int index)
        {
            if (salutation = "Mr.")
                    salutation = rdoMr.Text;
                else if (salutationDynamic = "Mrs.")
                    salutation = rdoMrs.Text;
                else if (salutation = "Ms.")
                    salutation = rdoMs.Text;

            salutation.item = salutationDynamic[index];
            txtFirstName.Text = fNameDynamic[index];
            txtLastName.Text = lNameDynamic[index];
            txtStreet1.Text = street1Dynamic[index];
            txtStreet2.Text = street2Dynamic[index];
            txtCity.Text = cityDynamic[index];
            cmbState.SelectedItem = stateDynamic[index];
            txtZip.Text = zipDynamic[index];
            txtEmail.Text = emailDynamic[index];
            txtHomePhone.Text = homePhoneDynamic[index];
            txtWorkPhone.Text = workPhoneDynamic[index];
            txtCellPhone.Text = cellPhoneDynamic[index];
            dtpBirthday.Value = Convert.ToDateTime(birthdayDynamic[index]);
            dtpAnniversary.Value = Convert.ToDateTime(anniversaryDynamic[index]);
            cmbRelationship.SelectedItem = relationshipDynamic[index];
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //move to the previous index
            index--;

            //fix the situation where the users goes too far to the left
            if (index < 0)
            {
                index = 0;
            }

            fillForm(index);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //move to the next index
            index++;

            //offset the situation where someone clicks next with no more records
            if (index >= dateDynamic.Count)
            {
                index = dateDynamic.Count - 1;
            }

            fillForm(index);
        }

    }
}