using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace class_week_2
{
    class validation
    {

        //Gets string to test if it has been filled in or not
        public static bool isFilledIn(string temp)
        {
            bool result = false;
            if (temp.Length > 0)
            {
                result = true;
            }
            return result;
        }


        //Gets string to test if it meets the minimum length requirements
        public static bool isFilledIn(string temp, int minlen)
        {
            bool result = false;
            if (temp.Length > minlen)
            {
                result = true;
            }
            return result;
        }

        //Gets string to test if it meets the exact length requirements
        public static bool isExactFilledIn(string temp, int exactlen)
        {
            bool result = false;
            if (temp.Length == exactlen)
            {
                result = true;
            }
            return result;
        }

        //Tests to see if email is valid
        public static bool validEmail(string temp)
        {
            bool result = true;

            //Finds location of @
            int atLocation = temp.IndexOf("@");
            int nextAtLocation = temp.IndexOf("@", atLocation + 1);

            //Finds location of the last period
            int periodLocation = temp.LastIndexOf(".");

            //Checks to see if email meets the length requirements
            if (temp.Length < 8)
            {
                result = false;
            }

            //Checks to see if the @ sign exists
            //Checks if what is before the @ sign is atleast two characters
            else if (atLocation < 2)
            { 
                result = false;
            }

            //Checks to see if only one @ sign exists
            else if (nextAtLocation > -1)
            {
                result = false;
            }
            
            //Checks to see if period exists
            //Checks if what is after the period is atleast two characters
            else if (periodLocation + 2 >= (temp.Length))
            {
                result = false;
            }

            //Checks to see if there are two spaces between the @ symbol and last period
            else if(atLocation + 2 >= periodLocation)
            {
                result = false;
            }

            return result;
        }

    }
}
