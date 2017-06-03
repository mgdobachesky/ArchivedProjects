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
            Person aPerson = new Person();
            aPerson.fName = txtFName.Text;
            aPerson.mName = txtMName.Text;
            aPerson.lName = txtLName.Text;
            aPerson.street1 = txtStreet1.Text;
            aPerson.street2 = txtStreet2.Text;
            aPerson.city = txtCity.Text;
            aPerson.state = txtState.Text;
            aPerson.zip = txtZip.Text;
            aPerson.phone = txtPhone.Text;
            aPerson.email = txtEmail.Text;
            aPerson.fName += "Poopy";

            fillLabel(aPerson);

            
        }

        private void fillLabel(Person temp)
        {
            lblFeedback.Text = temp.fName + "\n";
            lblFeedback.Text += temp.mName + "\n";
            lblFeedback.Text += temp.lName + "\n";
            lblFeedback.Text += temp.street1 + "\n";
            lblFeedback.Text += temp.street2 + "\n";
            lblFeedback.Text += temp.city + "\n";
            lblFeedback.Text += temp.state + "\n";
            lblFeedback.Text += temp.zip + "\n";
            lblFeedback.Text += temp.phone + "\n";
            lblFeedback.Text += temp.email + "\n";
        }
       
    }
}
