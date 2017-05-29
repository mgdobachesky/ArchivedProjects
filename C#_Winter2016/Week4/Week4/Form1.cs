using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Week4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Jedi Name Generator starts here
        private void button1_Click(object sender, EventArgs e)
        {
            lblJedi.Text = "";

            //Get the fields of data
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string maidenName = txtMaidenName.Text;
            string birthCity = txtCity.Text;

            //Get starting location for data where the last few letters are needed
            int fNameStart = fName.Length - 2;
            int birthCityStart = birthCity.Length - 3;

            //Gather required parts of the data
            string partOne = lName.Substring(0, 3);
            string partTwo = fName.Substring(fNameStart);
            string partThree = maidenName.Substring(0, 2);
            string partFour = birthCity.Substring(birthCityStart);

            //Test the collected parts of data
            //txtFirstName.Text = partOne;
            //txtLastName.Text = partTwo;
            //txtMaidenName.Text = partThree;
            //txtCity.Text = partFour;

            lblJedi.Text = partOne + partTwo + "-" + partThree + partFour;
        }
        //Jedi Name Generator ends here


        //Bad Word Cleaner Starts Here
        public string censor(string strNotes)
        {
            //Clear strResult variable so the function can run fresh
            string strResult = "";

            //Create an array of bad words
            string[] badwords = { "homework", "school", "test", "quiz", "pencil" };

            //Convert the badwords to lowercase so that the censor works reguardless of case
            string badwordsLower = txtBadWords.Text.ToLower();
            strNotes = badwordsLower;

            //Replace each instance of a bad word with string of stars of the words length
            foreach (string badword in badwords)
            {
                int badwordLength = badword.Length;

                string stars = asterisk(badwordLength);

                strNotes = strNotes.Replace(badword, stars); 
            }

            //Set a new variable equal to the cleaned words so the cleaned words can stack up
            strResult = strNotes;

            //Return the resulting string
            return strResult;

        }

        //This is a function that generates the string of stars that are equal to the length of the bad word
        public string asterisk(int badwordLength)
        {
            string starsWord = "";

            for (int i = 0; i < badwordLength; i++)
            {
                starsWord += "*";
            }

            return starsWord;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //Set the cleaned words text box to the result returned by the censor function
            txtCleaned.Text = censor(txtBadWords.Text);
        }
        //Bad Word Cleaner Ends Here

    }
}
