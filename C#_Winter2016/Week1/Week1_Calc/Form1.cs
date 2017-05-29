using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Week1_Calc
{
    public partial class Form1 : Form
    {
        double num1, num2, result;
        string operand, store;
        char first_run;

        public Form1()
        {
            InitializeComponent();
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

         private void Numbers_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            txtDisplay.Text += temp.Text;
        }

        private void Operators_Click(object sender, EventArgs e)
        {
            if (first_run != 'N')
            {
                num1 = Convert.ToDouble(txtDisplay.Text);
                first_run = 'N';

                Button temp = (Button)sender;
                operand = temp.Text;
            }

            else
            {
               mathOperations();

               Button temp = (Button)sender;
               operand = temp.Text;
            }

            txtDisplay.Text = "";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            mathOperations();
            first_run = 'Y';
        }

        private void mathOperations()
        {
            num2 = Convert.ToDouble(txtDisplay.Text);

            if (operand == "+")
            {
                result = num1 + num2;
                num1 = result;
            }

            else if (operand == "-")
            {
                result = num1 - num2;
                num1 = result;
            }

            else if (operand == "*")
            {
                result = num1 * num2;
                num1 = result;
            }

            else if (operand == "/")
            {
                result = num1 / num2;
                num1 = result;
            }

            else
            {
                result = num2;
            }

            txtDisplay.Text = Convert.ToString(result);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            num1 = 0;
            num2 = 0;
            result = 0;
            operand = "";
            first_run = 'Y';
        }

        private void btnMem_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += store;
        }

        private void btnSto_Click(object sender, EventArgs e)
        {
            store = txtDisplay.Text;
        }

        private void btnMemClear_Click(object sender, EventArgs e)
        {
            store = "";
        }
    }
}