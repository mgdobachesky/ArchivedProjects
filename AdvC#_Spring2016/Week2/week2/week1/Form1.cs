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
            aPerson.FName += "Poopy";

            //Run function that fills a label with the same information
            fillLabel(aPerson);

            
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
