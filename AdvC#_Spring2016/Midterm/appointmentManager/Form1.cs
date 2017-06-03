using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace appointmentManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //format the date time pickers
            dtpStart.ShowUpDown = true;
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "MMM d, yyyy  -  h:mm tt";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "MMM d, yyyy  -  h:mm tt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a new instance of the appointment class
            Appointment anAppointment = new Appointment();

            //set object variables to the values in the text boxes
            anAppointment.FName = txtFirstName.Text;
            anAppointment.LName = txtLastName.Text;
            anAppointment.Street1 = txtStreet1.Text;
            anAppointment.Street2 = txtStreet2.Text;
            anAppointment.City = txtCity.Text;
            anAppointment.State = txtState.Text;
            anAppointment.Zip = txtZip.Text;
            anAppointment.startVal = dtpStart.Value;
            anAppointment.endVal = dtpEnd.Value;
            anAppointment.Start = dtpStart.Value;
            anAppointment.End = dtpEnd.Value;
            anAppointment.Comments = txtComments.Text;

            //run a function that gives feedback on records added
            if(!anAppointment.Feedback.Contains("ERROR:"))
            {
                string results = anAppointment.addRecord();
                lblFeedback.Text = results + "\n";
                lblFeedback.Text += anAppointment.Data;
            }
            else 
            {
                lblFeedback.Text = anAppointment.Feedback;
            }
        }
    }
}
