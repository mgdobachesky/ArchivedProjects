using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace week1
{
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();

            //make controls unavailable
            pnlControls.Enabled = false;
            pnlControls.Visible = false;
            //make login available
            pnlLogin.Enabled = true;
            pnlLogin.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //open up the add form titled Form1
            Form1 addForm = new Form1();
            //activate the form so that it can be seen
            addForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //open up the form titled search
            Search searchForm = new Search();
            //activate the form so that it can be seen
            searchForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //clear previous feedback
            lblFeedbackLogin.Text = "";

            //check to see if user/pw combo exists within db
            var adminNum = loggingIn(txtUsernameLogin.Text, txtPasswordLogin.Text);
            
            if (adminNum <= 5 && adminNum != 0)
            {
                //make controls available
                pnlControls.Enabled = true;
                pnlControls.Visible = true;
                //make login unavailable
                pnlLogin.Enabled = false;
                pnlLogin.Visible = false;
            }
            //hard coded login
            else if (txtUsernameLogin.Text == "username" && txtPasswordLogin.Text == "password")
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
                lblFeedbackLogin.Text = "Invalid Login";
            }
        }

        //function used to validate database login
        private int loggingIn(string usedName, string passedWord) 
        {
            //declare variable to hold admin level
            int adminLevel = 0;

            //create datareader to return filled
            OleDbDataReader dr;

            //create a command for our sql statement
            OleDbCommand comm = new OleDbCommand();

            //write a select statement to perform search
            String strSql = "Select MyLevel FROM MyLogin WHERE (UName = @UName AND PW = @PW)";
            //set parameters
            comm.Parameters.AddWithValue("@UName", usedName);
            comm.Parameters.AddWithValue("@PW", passedWord);

            //create db tools and configure
            OleDbConnection conn = new OleDbConnection();
            //create the who, what, and where of the database
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=contacts.accdb;Persist Security Info=False;";
            conn.ConnectionString = strConn;

            //fill in basic info to command object
            comm.Connection = conn;
            comm.CommandText = strSql;

            //get data
            conn.Open();
            dr = comm.ExecuteReader();

            while (dr.Read())
            {
                //change the admin level to what it is in the database
                adminLevel = Convert.ToInt16(dr["MyLevel"].ToString());
            }

            conn.Close();

            //return the person's admin level
            return adminLevel;
        }

    }
}
