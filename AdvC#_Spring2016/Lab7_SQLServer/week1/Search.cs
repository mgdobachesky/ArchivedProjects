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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //get data that has been "drilled down"
            Student temp = new Student();
            DataSet ds = temp.searchFunction(txtSearchFirst.Text, txtSearchLast.Text);

            //display the data
            gvResults.DataSource = ds; //point to data grid
            gvResults.DataMember = ds.Tables["Persons"].ToString(); //point to table in data grid
        }

        private void gvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //collect information
            string strId = gvResults.Rows[e.RowIndex].Cells[0].Value.ToString();
            
            //test with pop-up
            //MessageBox.Show(strId);

            //convert string to integer
            int intId = Convert.ToInt32(strId);

            //create an instance of the editor form with this id
            //this is done using the overloaded constructor
            Form1 editor = new Form1(intId);
            editor.ShowDialog();

            //after the editing/deleting has been performed, rerun the search to refresh the page
            btnSearch.PerformClick();
        }
    }
}
