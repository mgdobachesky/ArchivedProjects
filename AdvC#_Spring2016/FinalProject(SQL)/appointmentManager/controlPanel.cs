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
    public partial class controlPanel : Form
    {
        public controlPanel()
        {
            InitializeComponent();

            //make controls unavailable
            pnlControls.Enabled = false;
            pnlControls.Visible = false;
            //make login available
            pnlLogin.Enabled = true;
            pnlLogin.Visible = true;

            //temporary display of log in credentials for testing purposes only
            MessageBox.Show("TESTING PURPOSES ONLY \n\n ~Login Credentials~ \n Username: username \n Password: password");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //clear previous feedback
            lblLoginFeedback.Text = "";

            //check to see if user exists in the database
            var adminNum = logginIn(txtLoginUsername.Text, txtLoginPassword.Text);

            //make controls available if user logs in with appropriate credit
            if(adminNum <= 5 && adminNum != 0) 
            {
                //make controls available
                pnlControls.Enabled = true;
                pnlControls.Visible = true;
                //make login unavailable
                pnlLogin.Enabled = false;
                pnlLogin.Visible = false;
            }
            //if invalid, display invalid login message and secure disabled controls
            else
            {
                //make controls unavailable
                pnlControls.Enabled = false;
                pnlControls.Visible = false;
                //make login available
                pnlLogin.Enabled = true;
                pnlLogin.Visible = true;
                //update feedback
                lblLoginFeedback.Text = "Invalid Login";
            }
        }

        private int logginIn(string usedName, string passedWord)
        {
            //declare variable to hold admin level
            int adminLevel = 0;

            //create datareader object to return later, after it had been filled
            SqlDataReader dr;

            //create a command object for sql statement
            SqlCommand comm = new SqlCommand();

            //write a select statement to perform the search on users
            String strSql = "SELECT AdminLevel FROM UsersFinal WHERE (Username = @Username AND Password = @Password)";
            //set parameters
            comm.Parameters.AddWithValue("@Username", usedName);
            comm.Parameters.AddWithValue("@Password", passedWord);

            //create db tools and configure
            SqlConnection conn = new SqlConnection();
            //create the who, what, and where of the database
            string strConn = MyTools.getConnected();
            conn.ConnectionString = strConn;

            //fill in basic information for the command object
            comm.Connection = conn;
            comm.CommandText = strSql;

            //get data
            conn.Open();
            dr = comm.ExecuteReader();

            while (dr.Read())
            {
                //change the admin level based on database information
                adminLevel = Convert.ToInt16(dr["AdminLevel"].ToString());
            }

            //close the connection
            conn.Close();

            //return the user's admin level
            return adminLevel;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            //open up the person form
            personStuff personThings = new personStuff();
            //activate the form so that it can be seen
            personThings.ShowDialog();
        }

        private void btnSearchPeople_Click(object sender, EventArgs e)
        {
            //open up the person form
            personSearch personLookup = new personSearch();
            //activate the form so that it can be seen
            personLookup.ShowDialog();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            //open up the add form titled Form1
            Form1 formThings = new Form1();
            //activate the form so that it can be seen
            formThings.ShowDialog();
        }

        private void btnSearchAppointments_Click(object sender, EventArgs e)
        {
            //open up the person form
            appointmentSearch appointmentLookup = new appointmentSearch();
            //activate the form so that it can be seen
            appointmentLookup.ShowDialog();
        }
    }
}
