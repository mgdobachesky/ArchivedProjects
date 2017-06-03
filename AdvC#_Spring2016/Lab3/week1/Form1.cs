using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace week1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            //Create an object containing my data
            Student mike = new Student("Michael", "Gary", "Dobachesky", "1 Street Drive", "2 Street Drive", "Plainville", "MA", "02762", "5085214255", "Mgdobachesky@email.neit.edu", 4);
            //Fill the label with data from my object
            fillLabel(mike);
            //Fill the form with data from my object
            txtFName.Text = mike.FName;
            txtMName.Text = mike.MName;
            txtLName.Text = mike.LName;
            txtStreet1.Text = mike.Street1;
            txtStreet2.Text = mike.Street2;
            txtCity.Text = mike.City;
            txtState.Text = mike.State;
            txtZip.Text = mike.Zip;
            txtPhone.Text = mike.Phone;
            txtEmail.Text = mike.Email;
            txtGpa.Text = mike.GPA.ToString();

            //Run function that fills a label if there are no errors
            if (!mike.Feedback.Contains("ERROR:"))
            {
                fillLabel(mike);
            }
            else
            {
                lblFeedback.Text = mike.Feedback;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Create new person object using person class
            Person aPerson = new Person();

            //Set the public variables to the values in the text boxes
            aPerson.FName = txtFName.Text;
            aPerson.MName = txtMName.Text;
            aPerson.LName = txtLName.Text;
            aPerson.Street1 = txtStreet1.Text;
            aPerson.Street2 = txtStreet2.Text;
            aPerson.City = txtCity.Text;
            aPerson.State = txtState.Text;
            aPerson.Zip = txtZip.Text;
            aPerson.Phone = txtPhone.Text;
            aPerson.Email = txtEmail.Text;

            //Run function that fills a label if there are no errors
            if (!aPerson.Feedback.Contains("ERROR:"))
            {
                fillLabel(aPerson);
            }
            else
            {
                lblFeedback.Text = aPerson.Feedback;
            }
   
        }

        //Function that fills a label with information from an object created from the Person class
        private void fillLabel(Person temp)
        {
            lblFeedback.Text = temp.FName + "\n";
            lblFeedback.Text += temp.MName + "\n";
            lblFeedback.Text += temp.LName + "\n";
            lblFeedback.Text += temp.Street1 + "\n";
            lblFeedback.Text += temp.Street2 + "\n";
            lblFeedback.Text += temp.City + "\n";
            lblFeedback.Text += temp.State + "\n";
            lblFeedback.Text += temp.Zip + "\n";
            lblFeedback.Text += temp.Phone + "\n";
            lblFeedback.Text += temp.Email + "\n";
        }

    }
}
