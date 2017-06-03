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
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
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
    }
}
