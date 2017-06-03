using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace appointmentManager
{
    public partial class personStuff : Form
    {
        public personStuff()
        {
            InitializeComponent();
            fillStatesCmb();

            //disable update and delete buttons when adding
            btnDeletePersonStuff.Visible = false;
            btnDeletePersonStuff.Enabled = false;
            btnUpdatePersonStuff.Visible = false;
            btnUpdatePersonStuff.Enabled = false;
            btnYesPersonStuff.Visible = false;
            btnYesPersonStuff.Enabled = false;
            btnNoPersonStuff.Visible = false;
            btnNoPersonStuff.Enabled = false;
        }

        public personStuff(Int32 intId)
        {
            //overloaded constructor, used in editor view
            InitializeComponent();
            fillStatesCmb();

            //disable update and delete buttons when adding
            btnSubmitPersonStuff.Visible = false;
            btnSubmitPersonStuff.Enabled = false;
            btnYesPersonStuff.Visible = false;
            btnYesPersonStuff.Enabled = false;
            btnNoPersonStuff.Visible = false;
            btnNoPersonStuff.Enabled = false;

            //get info for this person and store in a datareader
            Person temp = new Person();
            SqlDataReader dr = temp.PersonInformation(intId);

            //fill out the form with that information
            while (dr.Read())
            {
                //loop through the records one at a time (only one in this case)
                lblId.Text = dr["PersonId"].ToString();
                txtFirstNamePersonStuff.Text = dr["FName"].ToString();
                txtLastNamePersonStuff.Text = dr["LName"].ToString();
                txtStreet1PersonStuff.Text = dr["Street1"].ToString();
                txtStreet2PersonStuff.Text = dr["Street2"].ToString();
                txtCityPersonStuff.Text = dr["City"].ToString();
                cmbStatePersonStuff.SelectedItem = dr["State"].ToString();
                txtZipPersonStuff.Text = dr["Zip"].ToString();
                txtEmailPersonStuff.Text = dr["Email"].ToString();
                txtPhonePersonStuff.Text = dr["Phone"].ToString();
            }
        }

        private void btnUpdatePersonStuff_Click(object sender, EventArgs e)
        {
            //create a student to get access to it's methods
            Person temp = new Person();

            //fill data in the form
            temp.personId = Convert.ToInt32(lblId.Text);
            temp.FName = txtFirstNamePersonStuff.Text;
            temp.LName = txtLastNamePersonStuff.Text;
            temp.Street1 = txtStreet1PersonStuff.Text;
            temp.Street2 = txtStreet2PersonStuff.Text;
            temp.City = txtCityPersonStuff.Text;
            temp.State = cmbStatePersonStuff.SelectedItem.ToString();
            temp.Zip = txtZipPersonStuff.Text;
            temp.Email = txtEmailPersonStuff.Text;
            temp.Phone = txtPhonePersonStuff.Text;


            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedbackPersonStuff.Text = temp.Feedback;
            }
            else
            {
                Int32 numRecords = temp.updatePerson();
                lblFeedbackPersonStuff.Text = numRecords.ToString() + " Person(s) Updated";
            }
        }

        private void btnDeletePersonStuff_Click(object sender, EventArgs e)
        {
            btnYesPersonStuff.Visible = true;
            btnYesPersonStuff.Enabled = true;
            btnNoPersonStuff.Visible = true;
            btnNoPersonStuff.Enabled = true;

            //create a person to get access to it's methods
            Person temp = new Person();

            //make the id usable as an int
            Int32 personId = Convert.ToInt32(lblId.Text);

            Int32[] howMany = temp.peopleSelected(personId);
            lblPrompt.Text = "Delete " + howMany[0] + " person(s) and " + howMany[1] + " appointment(s)?";
        }

        private void btnYesPersonStuff_Click(object sender, EventArgs e)
        {
            //create a person to get access to it's methods
            Person temp = new Person();

            //make the id usable as an int
            Int32 personId = Convert.ToInt32(lblId.Text);

            //delete records and store how many were deleted
            Int32[] howMany = temp.DeletePerson(personId);

            //display feedback
            lblFeedbackPersonStuff.Text = "Deleted " + howMany[1] + " person(s) and " + howMany[0] + " appointment(s)";

            //clear the "are you sure" prompt for deleting
            lblPrompt.Text = "";
            btnYesPersonStuff.Visible = false;
            btnYesPersonStuff.Enabled = false;
            btnNoPersonStuff.Visible = false;
            btnNoPersonStuff.Enabled = false;
        }

        private void btnNoPersonStuff_Click(object sender, EventArgs e)
        {
            //clear the "are you sure" prompt for deleting
            lblPrompt.Text = "";
            btnYesPersonStuff.Visible = false;
            btnYesPersonStuff.Enabled = false;
            btnNoPersonStuff.Visible = false;
            btnNoPersonStuff.Enabled = false;
        }

        private void btnSubmitPersonStuff_Click(object sender, EventArgs e)
        {
            //create a new person object using the person class
            Person temp = new Person();

            //set the public variables to the values in the text boxes
            temp.FName = txtFirstNamePersonStuff.Text;
            temp.LName = txtLastNamePersonStuff.Text;
            temp.Street1 = txtStreet1PersonStuff.Text;
            temp.Street2 = txtStreet2PersonStuff.Text;
            temp.City = txtCityPersonStuff.Text;
            temp.State = cmbStatePersonStuff.SelectedItem.ToString();
            temp.Zip = txtZipPersonStuff.Text;
            temp.Email = txtEmailPersonStuff.Text;
            temp.Phone = txtPhonePersonStuff.Text;

            //run a function that fills a label if there are no errors
            if(!temp.Feedback.Contains("ERROR:"))
            {
                fillLabel(temp);
                temp.addRecord();
            }
            else
            {
                lblFeedbackPersonStuff.Text = temp.Feedback;
            }
        }

        private void fillLabel(Person temp)
        {
            lblFeedbackPersonStuff.Text = "Successfully Added Person:" + "\n";
            lblFeedbackPersonStuff.Text += temp.FName + "\n";
            lblFeedbackPersonStuff.Text += temp.LName + "\n";
            lblFeedbackPersonStuff.Text += temp.Street1 + "\n";
            if (temp.Street2 != "")
            {
                lblFeedbackPersonStuff.Text += temp.Street2 + "\n";
            }
            lblFeedbackPersonStuff.Text += temp.City + "\n";
            lblFeedbackPersonStuff.Text += temp.State + "\n";
            lblFeedbackPersonStuff.Text += temp.Zip + "\n";
            lblFeedbackPersonStuff.Text += temp.Email + "\n";
            lblFeedbackPersonStuff.Text += temp.Phone + "\n";
        }

        private void fillStatesCmb()
        {
            //get the list of states in the datareader
            SqlDataReader dr = MyTools.fillStates();

            //loop through each state
            while (dr.Read())
            {
                cmbStatePersonStuff.Items.Add(dr["State"].ToString());
            }

            cmbStatePersonStuff.Items.Insert(0, "Please Choose One...");
            cmbStatePersonStuff.SelectedIndex = 0;
            dr.Close();
        }

    }
}
