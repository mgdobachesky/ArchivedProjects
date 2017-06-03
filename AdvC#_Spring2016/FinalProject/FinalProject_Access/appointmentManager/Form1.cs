using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace appointmentManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillStatesCmb();
            fillPeopleCmb();

            //disable update and delete buttons when adding
            btnDelete.Visible = false;
            btnDelete.Enabled = false;
            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;
            btnYes.Visible = false;
            btnYes.Enabled = false;
            btnNo.Visible = false;
            btnNo.Enabled = false;

            //format the date time pickers
            dtpStart.ShowUpDown = true;
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "MMM d, yyyy  -  h:mm tt";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "MMM d, yyyy  -  h:mm tt";
        }

        //overloaded constructor, used for updating
        public Form1(Int32 intId)
        {
            InitializeComponent();
            fillStatesCmb();
            fillPeopleCmb();

            //disable update and delete buttons when adding
            button1.Visible = false;
            button1.Enabled = false;
            btnYes.Visible = false;
            btnYes.Enabled = false;
            btnNo.Visible = false;
            btnNo.Enabled = false;

            //format the date time pickers
            dtpStart.ShowUpDown = true;
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "MMM d, yyyy  -  h:mm tt";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "MMM d, yyyy  -  h:mm tt";

            //get info for this appointment and store it in a datareader
            Appointment temp = new Appointment();
            OleDbDataReader dr = temp.AppointmentInformation(intId);

            //use the information to fill out the form
            while(dr.Read())
            {
                //loop through the records one at a time (one in this case)
                lblAppointmentId.Text = dr["AppointmentId"].ToString();
                cmbPeople.SelectedValue = dr["PersonId"].ToString();
                txtStreet1.Text = dr["Street1"].ToString();
                txtStreet2.Text = dr["Street2"].ToString();
                txtCity.Text = dr["City"].ToString();
                cmbStates.SelectedItem = dr["State"].ToString();
                txtZip.Text = dr["Zip"].ToString();
                dtpStart.Value = Convert.ToDateTime(dr["StartDate"]);
                dtpEnd.Value = Convert.ToDateTime(dr["EndDate"]);
                txtComments.Text = dr["Comments"].ToString();
            }

            cmbPeople.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a new instance of the appointment class
            Appointment anAppointment = new Appointment();

            //set object variables to the values in the text boxes
            string personField = cmbPeople.SelectedItem.ToString();
            string slicedWord = personField.Substring(1);
            string[] parsedField = slicedWord.Split(',');
            if (parsedField[0] != "Please Choose One...") 
            {
                anAppointment.PersonId = Convert.ToInt32(parsedField[0]);
            }
            else
            {
                anAppointment.PersonId = -1;
            }
            anAppointment.Street1 = txtStreet1.Text;
            anAppointment.Street2 = txtStreet2.Text;
            anAppointment.City = txtCity.Text;
            anAppointment.State = cmbStates.SelectedItem.ToString();
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

        private void fillStatesCmb()
        {
            //get the list of states in the datareader
            OleDbDataReader dr = MyTools.fillStates();

            //loop through each state
            while (dr.Read())
            {
                cmbStates.Items.Add(dr["State"].ToString());
            }

            cmbStates.Items.Insert(0, "Please Choose One...");
            cmbStates.SelectedIndex = 0;
            dr.Close();
        }

        private void fillPeopleCmb()
        {
            //get the list of states in the datareader
            OleDbDataReader dr = MyTools.fillPeople();

            var peopleList = new BindingList<KeyValuePair<string, string>>();
            //loop through each state
            peopleList.Add(new KeyValuePair<string, string>("0", "Please Choose One..."));
            while (dr.Read())
            {
                peopleList.Add(new KeyValuePair<string, string>(dr["PersonId"].ToString(), dr["PersonId"].ToString() + ": " + dr["FName"].ToString() + " " + dr["LName"].ToString()));
            }
            cmbPeople.DataSource = peopleList;
            cmbPeople.ValueMember = "Key";
            cmbPeople.DisplayMember = "Value";

            dr.Close();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            //create new appointment object to use it's methods
            Appointment temp = new Appointment();

            //fill out the form data
            temp.appointmentId = Convert.ToInt32(lblAppointmentId.Text);
            temp.Street1 = txtStreet1.Text;
            temp.Street2 = txtStreet2.Text;
            temp.City = txtCity.Text;
            temp.State = cmbStates.SelectedItem.ToString();
            temp.Zip = txtZip.Text;
            temp.startVal = dtpStart.Value;
            temp.endVal = dtpEnd.Value;
            temp.Start = dtpStart.Value;
            temp.End = dtpEnd.Value;
            temp.Comments = txtComments.Text;

            if(temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                Int32 numRecords = temp.updateAppointment();
                lblFeedback.Text = numRecords.ToString() + " Appointment(s) Updated";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnYes.Visible = true;
            btnYes.Enabled = true;
            btnNo.Visible = true;
            btnNo.Enabled = true;

            //create an appointment object to use it's methods
            Appointment temp = new Appointment();

            //make the id usable as an int
            Int32 appointmentId = Convert.ToInt32(lblAppointmentId.Text);

            //get the number of records to be deleted
            Int32 howMany = temp.recordsSelected(appointmentId);
            lblPrompt.Text = "Delete " + howMany.ToString() + " appointment(s)?";
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            //create an appointment object to access it's methods
            Appointment temp = new Appointment();

            //make the id usable as an int
            Int32 appointmentId = Convert.ToInt32(lblAppointmentId.Text);

            //delete record(s) and store how many were deleted
            Int32 numRecords = temp.DeleteAppointment(appointmentId);

            //display feedback
            lblFeedback.Text = numRecords.ToString() + " Appointment(s) Deleted";

            //clear the "are you sure" prompt for deleting
            lblPrompt.Text = "";
            btnYes.Visible = false;
            btnYes.Enabled = false;
            btnNo.Visible = false;
            btnNo.Enabled = false;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //clear the "are you sure" prompt for deleting
            lblPrompt.Text = "";
            btnYes.Visible = false;
            btnYes.Enabled = false;
            btnNo.Visible = false;
            btnNo.Enabled = false;
        }

    }
}
