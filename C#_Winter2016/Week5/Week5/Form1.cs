using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Week5
{
    public partial class Form1 : Form
    {
        //Variables
        decimal totalPrice;
        string toppings;
        string pizzaSize;
        int oneTopping;
        string ridFirstComma;
        int insertAnd;
        int counter;
        int radioOn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Run the function that fills the combo boxes with items
            comboBoxItems();

            //Set the default index for both combo boxes to zero
            cmbCity.SelectedIndex = 0;
            cmbState.SelectedIndex = 0;

            //Set counter equal to zero (used to monitor how many times a user can press delete)
            counter = 0;
        }

        public void comboBoxItems()
        {
            //Items to add to the City combo box
            cmbCity.Items.Add("Providence");
            cmbCity.Items.Add("Woonsocket");
            cmbCity.Items.Add("Attleboro");

            //Items to add to the State combo box
            cmbState.Items.Add("RI");
            cmbState.Items.Add("MA");
        }

        public void totalCost()
        {
            //Set vaiables to be blank for a fresh run of the function
            toppings = "";
            oneTopping = 0;
            radioOn = 0;

            //Evaluate what size pizza to charge for
            if (rdoSmall.Checked == true)
            {
                totalPrice = 7;
                pizzaSize = "small";
                radioOn = 1;
            }
            else if (rdoMedium.Checked == true)
            {
                totalPrice = 10;
                pizzaSize = "medium";
                radioOn = 1;
            }
            else if (rdoLarge.Checked == true)
            {
                totalPrice = 12;
                pizzaSize = "large";
                radioOn = 1;
            }

            //Evaluate what toppings to charge for
            if (chkPepperoni.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", pepperoni";
                oneTopping += 1;
            }

            if (chkSausage.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", sausage";
                oneTopping += 1;
            }

            if (chkMeatball.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", meatball";
                oneTopping += 1;
            }

            if (chkHam.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", ham";
                oneTopping += 1;
            }

            if (chkPeppers.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", peppers";
                oneTopping += 1;
            }

            if (chkOnions.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", onions";
                oneTopping += 1;
            }

            if (chkOlives.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", olives";
                oneTopping += 1;
            }

            if (chkSpinach.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", spinach";
                oneTopping += 1;
            }

            if (chkPineapple.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", pineapple";
                oneTopping += 1;
            }

            if (chkBbqSauce.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", bbq sauce";
                oneTopping += 1;
            }

            if (chkExtraCheese.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", extra cheese";
                oneTopping += 1;
            }

            if (chkAnchovies.Checked == true)
            {
                totalPrice = totalPrice + .5M;
                toppings += ", anchovies";
                oneTopping += 1;
            }

            //Set up money to appear with two decimal places
            totalPrice = totalPrice * 1.00M;
            totalPrice = decimal.Round(totalPrice, 2, MidpointRounding.AwayFromZero);

        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            //Clear the feedback label
            lblFeedback.Text = "";

            //Set isValid to true so that output can be shown if there are no problems
            bool isValid = true;

            //Run function that determines the total cost of the pizza
            totalCost();

            //Get the current date and time
            DateTime now = DateTime.Today;
            DateTime date = dtpPickup.Value;

            //Validate that a pizza size has been chosen
            if (!validation.isChecked(radioOn))
            {
                isValid = false; 
                lblFeedback.Text += "Please choose a pizza size \n";
            }

            //Validate that the chosen date and time have not already passed
            if (!validation.afterNow(date, now))
            {
                isValid = false;
                lblFeedback.Text += "Please choose a date that hasn't already passed. \n";
            }

            //Validate that first name has been filled in
            if (!validation.isFilledIn(txtFirstName.Text))
            {
                isValid = false;
                lblFeedback.Text += "Please fill in your first name. \n";
            }

            //Validate that last name has been filled in
            if (!validation.isFilledIn(txtLastName.Text))
            {
                isValid = false;
                lblFeedback.Text += "Please fill in your last name. \n";
            }

            //Check if email is valid
            if (!validation.validEmail(txtEmail.Text))
            {
                isValid = false;
                lblFeedback.Text += "Please fill in a valid email. \n";
            }

            //If a phone number is entered, check to see if it is atleast seven characters long
            if (validation.isFilledIn(txtPhone.Text))
            {
                if (!validation.isFilledIn(txtPhone.Text, 6))
                {
                    isValid = false;
                    lblFeedback.Text += "Please fill in a valid phone number. \n";
                }
            }


            //Format the text to look good in the string that lists toppings
            if (oneTopping == 0)
            {
                //If there are no toppings, set them to a blank string
                toppings = " no toppings";
            }

            else if (oneTopping == 1)
            {
                //Get rid of the redundant comma at the beginning of the string
                ridFirstComma = toppings.Substring(1);
                toppings = ridFirstComma;
            }

            else
            {
                //Get rid of the redundant comma and also add "and" after the last comma
                ridFirstComma = toppings.Substring(1);
                insertAnd = ridFirstComma.LastIndexOf(",");
                toppings = ridFirstComma.Insert(insertAnd + 1, " and");
            }


            //Output to the main list box
            if (isValid)
            {
                //Accumulates a number to use while deleting oldest orders
                counter = counter + 1;

                //Add total price to main list box
                lstOrder.Items.Add(
                    "Total: $" + totalPrice
                    );

                //Add pizza description to main list box
                lstOrder.Items.Add(
                    "You ordered a " + pizzaSize + " pizza with" + toppings + "."
                    );

                //Add customer information to main list box
                    lstOrder.Items.Add(
                        "It will be delivered to " + txtStreet1.Text + " in " + cmbCity.SelectedItem + ", " + cmbState.SelectedItem + " at your requested time of " + dtpPickup.Value
                        );

                //Blank space
                lstOrder.Items.Add(
                    ""
                    );

                //looping to clear form items
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Clear();

                    else if (c is ComboBox)
                        ((ComboBox)c).SelectedIndex = 0;

                    else if (c is DateTimePicker)
                        ((DateTimePicker)c).Value = DateTime.Now;

                    else if (c is GroupBox)
                   {
                       foreach (Control k in c.Controls)
                       {
                           if (k is CheckBox)
                               ((CheckBox)k).Checked = false;

                           if (k is RadioButton)
                               ((RadioButton)k).Checked = false;
                       }
                   }

                }
            }
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            //Reverses count that was accumulated by adding orders
            //Count is used to keep the program from crashing when a user hits delete while there is nothing to get rid of
            counter = counter - 1;

            //Fixes issue caused by pressing the delete button too many times
            if (counter < 0)
            {
                counter = 0;
                for (int i = 0; i < 4; i++)
                lstOrder.Items.Add("");
            }

            //Deletes oldest order in main list box
            if (counter >= 0)
            {
                for (int i = 0; i < 4; i++)
                    lstOrder.Items.RemoveAt(0);
            }
        }  
    }
}
