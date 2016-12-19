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
    public partial class personSearch : Form
    {
        public personSearch()
        {
            InitializeComponent();
        }

        private void btnPersonSearch_Click(object sender, EventArgs e)
        {
            //get data that has been "drilled down"
            Person temp = new Person();
            DataSet ds = temp.searchPeople(txtFirstNamePersonSearch.Text, txtLastNamePersonSearch.Text);

            //display the data
            dgvPersonSearch.DataSource = ds;
            dgvPersonSearch.DataMember = ds.Tables["People"].ToString();
        }

        private void dgvPersonSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //collect information
            string strId = dgvPersonSearch.Rows[e.RowIndex].Cells[0].Value.ToString();

            //test this with pop up
            //MessageBox.Show(strId);

            //convert string to integer
            int intId = Convert.ToInt32(strId);

            //create an instance of the editor form with this id using the overloaded constructor
            personStuff editor = new personStuff(intId);
            editor.ShowDialog();

            //after the editing/deleting is done, rerun the search to refresh the data grid view
            btnPersonSearch.PerformClick();
        }
    }
}
