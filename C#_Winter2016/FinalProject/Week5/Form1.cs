using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Week5
{
    public partial class Form1 : Form
    {
        //Variables
        int index;
        int okayToUpdate = 0;
        decimal totalPrice;
        string toppings;
        string pizzaSize;
        int oneTopping;
        string ridFirstComma;
        int insertAnd;
        int counter;
        int radioOn;
        List<string>dateDynamic = new List<string>(); 
        List<string>fNameDynamic = new List<string>(); 
        List<string>lNameDynamic = new List<string>(); 
        List<string>emailDynamic = new List<string>(); 
        List<string>phoneDynamic = new List<string>(); 
        List<string>street1Dynamic = new List<string>();  
        List<string>street2Dynamic = new List<string>(); 
        List<string>cityDynamic = new List<string>(); 
        List<string>stateDynamic = new List<string>(); 
        List<string>orderDynamic = new List<string>(); 
        List<string>costDynamic = new List<string>(); 
        List<string>sizeDynamic = new List<string>(); 
        List<string>pepperoniDynamic = new List<string>(); 
        List<string>sausageDynamic = new List<string>(); 
        List<string>meatballDynamic = new List<string>(); 
        List<string>hamDynamic = new List<string>(); 
        List<string>peppersDynamic = new List<string>(); 
        List<string>onionsDynamic = new List<string>(); 
        List<string>olivesDynamic = new List<string>(); 
        List<string>spinachDynamic = new List<string>(); 
        List<string>pineappleDynamic = new List<string>(); 
        List<string>bbqDynamic = new List<string>(); 
        List<string>cheeseDynamic = new List<string>();
        List<string>anchoviesDynamic = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //start index at 0
            index = 0;
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
            DateTime now = DateTime.Now;
            DateTime nowMinusTen = now.Subtract(new TimeSpan(0,10,0));
            DateTime date = dtpPickup.Value;

            //Validate that a pizza size has been chosen
            if (!validation.isChecked(radioOn))
            {
                isValid = false; 
                lblFeedback.Text += "Please choose a pizza size \n";
            }

            //Validate that the chosen date and time have not already passed
            if (!validation.afterNow(date, nowMinusTen))
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

            string storePepperoni = "";
            string storeSausage = "";
            string storeMeatball = "";
            string storeHam = "";
            string storePeppers = "";
            string storeOnions = "";
            string storeOlives = "";
            string storeSpinach = "";
            string storePineapple = "";
            string storeBbq = "";
            string storeExtraCheese = "";
            string storeAnchovies = "";

            //Evaluate what toppings to store
            if (chkPepperoni.Checked == true)
            {
              storePepperoni = "pepperoni";  
            }

            if (chkSausage.Checked == true)
            {
                storeSausage = "sausage";
            }

            if (chkMeatball.Checked == true)
            {
                storeMeatball = "meatball";
            }

            if (chkHam.Checked == true)
            {
                storeHam = "ham";
            }

            if (chkPeppers.Checked == true)
            {
                storePeppers = "peppers";
            }

            if (chkOnions.Checked == true)
            {
                storeOnions = "onions";
            }

            if (chkOlives.Checked == true)
            {
                storeOlives = "olives";
            }

            if (chkSpinach.Checked == true)
            {
                storeSpinach = "spinach";
            }

            if (chkPineapple.Checked == true)
            {
                storePineapple = "pineapple";
            }

            if (chkBbqSauce.Checked == true)
            {
                storeBbq = "bbq";
            }

            if (chkExtraCheese.Checked == true)
            {
                storeExtraCheese = "cheese";
            }

            if (chkAnchovies.Checked == true)
            {
               storeAnchovies = "anchovies";
            }

                //Create comma delimited string for holding data
                string dataRecord = DateTime.Now.ToShortDateString() + ","
                    + txtFirstName.Text + ","
                    + txtLastName.Text + ","
                    + txtEmail.Text + ","
                    + txtPhone.Text + ","
                    + txtStreet1.Text + ","
                    + txtStreet2.Text + ","
                    + cmbCity.SelectedItem + ","
                    + cmbState.SelectedItem + ","
                    + date + ","
                    + totalPrice + ","
                    + pizzaSize + ","
                    + storePepperoni + ","
                    + storeSausage + ","
                    + storeMeatball + ","
                    + storeHam + ","
                    + storePeppers + ","
                    + storeOnions + ","
                    + storeOlives + ","
                    + storeSpinach + ","
                    + storePineapple + ","
                    + storeBbq + ","
                    + storeExtraCheese + ","
                    + storeAnchovies + "";

                //send the data to a file
                string result = fileIO.writeFile(@"orders.csv", dataRecord);
                    
                if (result != "OK")
                {
                    lblFeedback.Text = result;
                }

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

        private void brnPrev_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = "";

            try
            {
                //move to the previous index
                index--;

                //fix the situation where the user goes too far to the left
                if (index < 0)
                {
                    index = 0;
                }

                fillForm(index);
            }

            //catch the error where someone scrolls withour loading first
            catch (Exception)
            {
                lblFeedback.Text = "Please load orders before trying to scroll. \n";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //Clear feedback label
            lblFeedback.Text = "";

            //populate lists
            fillLists(@"orders.csv", dateDynamic, fNameDynamic, lNameDynamic, emailDynamic, phoneDynamic,
                street1Dynamic, street2Dynamic, cityDynamic, stateDynamic, orderDynamic, costDynamic,
                sizeDynamic, pepperoniDynamic, sausageDynamic, meatballDynamic, hamDynamic, peppersDynamic,
                onionsDynamic, olivesDynamic, spinachDynamic, pineappleDynamic, bbqDynamic, cheeseDynamic,
                anchoviesDynamic);

            //flip switch that allows updating so it is impossible to acedently erase the file
            okayToUpdate = 1;

        }

        public void fillLists(string fileName, List<string>dateDynamic, List<string>fNameDynamic, List<string>lNameDynamic, List<string>emailDynamic, List<string>phoneDynamic,
                List<string>street1Dynamic, List<string>street2Dynamic, List<string>cityDynamic, List<string>stateDynamic, List<string>orderDynamic, List<string>costDynamic,
                List<string>sizeDynamic, List<string>pepperoniDynamic, List<string>sausageDynamic, List<string>meatballDynamic, List<string>hamDynamic, List<string>peppersDynamic,
                List<string>onionsDynamic, List<string>olivesDynamic, List<string>spinachDynamic, List<string>pineappleDynamic, List<string>bbqDynamic, List<string>cheeseDynamic,
                List<string> anchoviesDynamic)
        {
            //clear existing data
            dateDynamic.Clear();
            fNameDynamic.Clear();
            lNameDynamic.Clear();
            emailDynamic.Clear();
            phoneDynamic.Clear();
            street1Dynamic.Clear();
            street2Dynamic.Clear();
            cityDynamic.Clear();
            stateDynamic.Clear();
            orderDynamic.Clear();
            costDynamic.Clear();
            sizeDynamic.Clear();
            pepperoniDynamic.Clear();
            sausageDynamic.Clear();
            meatballDynamic.Clear();
            hamDynamic.Clear();
            peppersDynamic.Clear();
            onionsDynamic.Clear();
            olivesDynamic.Clear();
            spinachDynamic.Clear();
            pineappleDynamic.Clear();
            bbqDynamic.Clear();
            cheeseDynamic.Clear();
            anchoviesDynamic.Clear();

            //create streamReader object
            StreamReader sr;

            try
            {
                //open the file to read from
                sr = new StreamReader(File.Open(@fileName, FileMode.Open));

                try
                {
                    //while not at the end of the file
                    while (sr.Peek() != -1)
                    {
                        //make a row from a record of the textfile
                        string row = sr.ReadLine();

                        //create an array for the columns
                        string[] columns = row.Split(',');

                        //break the data into pieces
                        dateDynamic.Add(columns[0]);
                        fNameDynamic.Add(columns[1]);
                        lNameDynamic.Add(columns[2]);
                        emailDynamic.Add(columns[3]);
                        phoneDynamic.Add(columns[4]);
                        street1Dynamic.Add(columns[5]);
                        street2Dynamic.Add(columns[6]);
                        cityDynamic.Add(columns[7]);
                        stateDynamic.Add(columns[8]);
                        orderDynamic.Add(columns[9]);
                        costDynamic.Add(columns[10]);
                        sizeDynamic.Add(columns[11]);
                        pepperoniDynamic.Add(columns[12]);
                        sausageDynamic.Add(columns[13]);
                        meatballDynamic.Add(columns[14]);
                        hamDynamic.Add(columns[15]);
                        peppersDynamic.Add(columns[16]);
                        onionsDynamic.Add(columns[17]);
                        olivesDynamic.Add(columns[18]);
                        spinachDynamic.Add(columns[19]);
                        pineappleDynamic.Add(columns[20]);
                        bbqDynamic.Add(columns[21]);
                        cheeseDynamic.Add(columns[22]);
                        anchoviesDynamic.Add(columns[23]);
                    }
                }

                finally
                {
                    //close file
                    sr.Close();
                }
            }

            catch (Exception exc)
            {
                //store the error message for testing purposes
                string err = exc.Message;
            }

            //populate the form
            fillForm(index);
        }

        public void fillForm(int index)
        {
            //clear the form to be filled
            chkPepperoni.Checked = false;
            chkSausage.Checked = false;
            chkMeatball.Checked = false;
            chkHam.Checked = false;
            chkPeppers.Checked = false;
            chkOnions.Checked = false;
            chkOlives.Checked = false;
            chkSpinach.Checked = false;
            chkPineapple.Checked = false;
            chkBbqSauce.Checked = false;
            chkExtraCheese.Checked = false;
            chkAnchovies.Checked = false;

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = 0;
                else if (c is ListBox)
                    ((ListBox)c).Items.Clear();
                lblFeedback.Text = "";
            }

            //fill in the correct information on the form
            if (pepperoniDynamic[index] == "pepperoni")
            {
                chkPepperoni.Checked = true;
            }

            if (sausageDynamic[index] == "sausage")
            {
                chkSausage.Checked = true;
            }

            if (meatballDynamic[index] == "meatball")
            {
                chkMeatball.Checked = true;
            }

            if (hamDynamic[index] == "ham")
            {
                chkHam.Checked = true;
            }

             if (peppersDynamic[index] == "peppers")
            {
                chkPeppers.Checked = true;
            }

             if (onionsDynamic[index] == "onions")
             {
                 chkOnions.Checked = true;
             }

             if (olivesDynamic[index] == "olives")
             {
                 chkOlives.Checked = true;
             }

             if (spinachDynamic[index] == "spinach")
             {
                 chkSpinach.Checked = true;
             }

             if (pineappleDynamic[index] == "pineapple")
             {
                 chkPineapple.Checked = true;
             }

             if (bbqDynamic[index] == "bbq")
             {
                 chkBbqSauce.Checked = true;
             }

             if (cheeseDynamic[index] == "cheese")
             {
                 chkExtraCheese.Checked = true;
             }

             if (anchoviesDynamic[index] == "anchovies")
             {
                 chkAnchovies.Checked = true;
             }

             if (sizeDynamic[index] == "small")
             {
                 rdoSmall.Checked = true;
             }
             else if (sizeDynamic[index] == "medium")
             {
                 rdoMedium.Checked = true;
             }
             else if (sizeDynamic[index] == "large")
             {
                 rdoLarge.Checked = true;
             }


                  txtFirstName.Text = fNameDynamic[index];
                  txtLastName.Text = lNameDynamic[index];
                  txtEmail.Text = emailDynamic[index];
                  txtPhone.Text = phoneDynamic[index];
                  txtStreet1.Text = street1Dynamic[index];
                  txtStreet2.Text = street2Dynamic[index];
                  cmbCity.SelectedItem = cityDynamic[index];
                  cmbState.SelectedItem = stateDynamic[index];
                  dtpPickup.Value = Convert.ToDateTime(orderDynamic[index]);
          
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = "";
            if (dateDynamic.Count > 0)
            {
                try
                {
                    //move to the next index
                    index++;

                    //offset the situation where someone clicks next with no more records
                    if (index >= dateDynamic.Count)
                    {
                        index = dateDynamic.Count - 1;
                    }

                    fillForm(index);
                }

                //catch the error where someone scrolls without loading
                catch (Exception)
                {
                    lblFeedback.Text = "Please load orders before trying to scroll. \n";
                }
            }

            //output error message without breaking the program in the situation where someone clicked next and then tried to load orders
            else
            {
                lblFeedback.Text = "Please load contacts before trying to scroll through. \n";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (okayToUpdate == 1)
            {
                //update lists and arrays with current data
                if (chkPepperoni.Checked == true)
                {
                    pepperoniDynamic[index] = "pepperoni";
                }

                if (chkSausage.Checked == true)
                {

                    sausageDynamic[index] = "sausage";
                }

                if (chkMeatball.Checked == true)
                {

                    meatballDynamic[index] = "meatball";
                }

                if (chkHam.Checked == true)
                {
                    hamDynamic[index] = "ham";
                }

                if (chkPeppers.Checked == true)
                {
                    peppersDynamic[index] = "peppers";
                }

                if (chkOnions.Checked == true)
                {

                    onionsDynamic[index] = "onions";
                }

                if (chkOlives.Checked == true)
                {
                    olivesDynamic[index] = "olives";
                }

                if (chkSpinach.Checked == true)
                {
                    spinachDynamic[index] = "spinach";
                }

                if (chkPineapple.Checked == true)
                {
                    pineappleDynamic[index] = "pineapple";
                }

                if (chkBbqSauce.Checked == true)
                {
                    bbqDynamic[index] = "bbq";
                }

                if (chkExtraCheese.Checked == true)
                {
                    cheeseDynamic[index] = "cheese";
                }

                if (chkAnchovies.Checked == true)
                {
                    anchoviesDynamic[index] = "anchovies";

                }

                if (rdoSmall.Checked == true)
                {
                    sizeDynamic[index] = "small";
                }
                else if (rdoMedium.Checked == true)
                {
                    sizeDynamic[index] = "medium";
                }
                else if (rdoLarge.Checked == true)
                {
                    sizeDynamic[index] = "large";
                }


                fNameDynamic[index] = txtFirstName.Text;
                lNameDynamic[index] = txtLastName.Text;
                emailDynamic[index] = txtEmail.Text;
                phoneDynamic[index] = txtPhone.Text;
                street1Dynamic[index] = txtStreet1.Text;
                street2Dynamic[index] = txtStreet2.Text;
                cityDynamic[index] = cmbCity.SelectedItem.ToString();
                stateDynamic[index] = cmbState.SelectedItem.ToString();
                orderDynamic[index] = dtpPickup.Value.ToString();

                //overwrite the original file with the current lists
                lblFeedback.Text = UpdateFile(@"orders.csv", dateDynamic, fNameDynamic, lNameDynamic, emailDynamic, phoneDynamic,
                street1Dynamic, street2Dynamic, cityDynamic, stateDynamic, orderDynamic, costDynamic,
                sizeDynamic, pepperoniDynamic, sausageDynamic, meatballDynamic, hamDynamic, peppersDynamic,
                onionsDynamic, olivesDynamic, spinachDynamic, pineappleDynamic, bbqDynamic, cheeseDynamic,
                anchoviesDynamic);
            }
            else
            {
                lblFeedback.Text = "Please load the file before trying to update it";
            }
        }

        //function that deletes the old file, recreates file, loops through the list index, and finally, closes the file
        public static string UpdateFile(string fileName, List<string> dateDynamic, List<string> fNameDynamic, List<string> lNameDynamic, List<string> emailDynamic, List<string> phoneDynamic,
                List<string> street1Dynamic, List<string> street2Dynamic, List<string> cityDynamic, List<string> stateDynamic, List<string> orderDynamic, List<string> costDynamic,
                List<string> sizeDynamic, List<string> pepperoniDynamic, List<string> sausageDynamic, List<string> meatballDynamic, List<string> hamDynamic, List<string> peppersDynamic,
                List<string> onionsDynamic, List<string> olivesDynamic, List<string> spinachDynamic, List<string> pineappleDynamic, List<string> bbqDynamic, List<string> cheeseDynamic,
                List<string> anchoviesDynamic)
        {
            //declare some variables
            int numOfRecords = dateDynamic.Count - 1;
            string myString = "";
            string strFeedback = "";
            StreamWriter sw;

            try
            {
                //delete original file
                File.Delete(@fileName);

                //set the initial feedback message
                strFeedback = "Record updated Successfully";

                //Create the streamwriter and set the filename
                sw = new StreamWriter(File.Open(@fileName, FileMode.OpenOrCreate));

                //loop through each record in the lists and append
                for (int Ctr = 0; Ctr <= numOfRecords; Ctr++)
                {
                    //place the cursor at the first column, on the row after the last record
                    sw.BaseStream.Seek(0, SeekOrigin.End);

                    //develop the comma-delimited string with currend record data
                    myString = DateTime.Now.ToShortDateString() + ","
            + fNameDynamic[Ctr] + ","
            + lNameDynamic[Ctr] + ","
            + emailDynamic[Ctr] + ","
            + phoneDynamic[Ctr] + ","
            + street1Dynamic[Ctr] + ","
            + street2Dynamic[Ctr] + ","
            + cityDynamic[Ctr] + ","
            + stateDynamic[Ctr] + ","
            + orderDynamic[Ctr] + ","
            + costDynamic[Ctr] + ","
            + sizeDynamic[Ctr] + ","
            + pepperoniDynamic[Ctr] + ","
            + sausageDynamic[Ctr] + ","
            + meatballDynamic[Ctr] + ","
            + hamDynamic[Ctr] + ","
            + peppersDynamic[Ctr] + ","
            + onionsDynamic[Ctr] + ","
            + olivesDynamic[Ctr] + ","
            + spinachDynamic[Ctr] + ","
            + pineappleDynamic[Ctr] + ","
            + bbqDynamic[Ctr] + ","
            + cheeseDynamic[Ctr] + ","
            + anchoviesDynamic[Ctr];

                    //write the string to the datafile
                    sw.WriteLine(myString);
                }

                //force the write, save the file, and clear the buffer
                sw.Flush();

                //close the file
                sw.Close();
            }

               catch (Exception err)
            {
                string x = err.Message;
                strFeedback = "ERROR: " + x;
            }


            //return feedback
            return strFeedback;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear the form
            chkPepperoni.Checked = false;
            chkSausage.Checked = false;
            chkMeatball.Checked = false;
            chkHam.Checked = false;
            chkPeppers.Checked = false;
            chkOnions.Checked = false;
            chkOlives.Checked = false;
            chkSpinach.Checked = false;
            chkPineapple.Checked = false;
            chkBbqSauce.Checked = false;
            chkExtraCheese.Checked = false;
            chkAnchovies.Checked = false;
            rdoLarge.Checked = false;
            rdoMedium.Checked = false;
            rdoSmall.Checked = false;
            dtpPickup.Value = DateTime.Now;

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = 0;
                else if (c is ListBox)
                    ((ListBox)c).Items.Clear();
                lblFeedback.Text = "";
            }
        }  



    }
}
