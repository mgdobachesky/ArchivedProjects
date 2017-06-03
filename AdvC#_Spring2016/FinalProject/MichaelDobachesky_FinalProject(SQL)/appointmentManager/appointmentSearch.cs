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
    public partial class appointmentSearch : Form
    {
        public appointmentSearch()
        {
            InitializeComponent();
            fillPeopleCmb();
        }

        private void btnAppointmentSearch_Click(object sender, EventArgs e)
        {
            //get data that has been "drilled down"
            Appointment temp = new Appointment();
            Int32 personId = 0;
            string personField = cmbAppointmentSearch.SelectedItem.ToString();
            string[] parsedField = personField.Split(':');
            if (parsedField[0] != "Please Choose One...")
            {
                lblAppointmentSearchFeedback.Text = "";
                personId = Convert.ToInt32(parsedField[0]);

                DataSet ds = temp.searchAppointments(personId);

                //display the data
                dgvAppointmentSearch.DataSource = ds;
                dgvAppointmentSearch.DataMember = ds.Tables["Appointments"].ToString();
            }
            else
            {
                lblAppointmentSearchFeedback.Text = "Please choose a person";
            }
        }

        private void dgvAppointmentSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //collect information
            string strId = dgvAppointmentSearch.Rows[e.RowIndex].Cells[0].Value.ToString();

            //test with pop up
            //MessageBox.Show(strId);

            //convert string to integer
            int intId = Convert.ToInt32(strId);

            //create an istance of the editor with an overloaded constructor
            Form1 editor = new Form1(intId);
            editor.ShowDialog();

            //after the editing/deleting has been performed, rerun the search to refresh the page
            btnAppointmentSearch.PerformClick();
        }

        private void fillPeopleCmb()
        {
            //get the list of states in the datareader
            SqlDataReader dr = MyTools.fillPeople();

            //loop through each state
            while (dr.Read())
            {
                cmbAppointmentSearch.Items.Add(dr["PersonId"].ToString() + ": " + dr["FName"].ToString() + " " + dr["LName"].ToString());
            }

            cmbAppointmentSearch.Items.Insert(0, "Please Choose One...");
            cmbAppointmentSearch.SelectedIndex = 0;
            dr.Close();
        }

    }
}
