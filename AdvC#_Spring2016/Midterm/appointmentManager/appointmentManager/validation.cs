using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appointmentManager
{
    class Validation
    {

        //Gets string to test if a value has been filled in or not
        public static bool isFilledIn(string temp)
        {
            bool result = false;
            if (temp.Length > 0)
            {
                result = true;
            }
            return result;
        }

        //Gets string to test if a value is at least a minimum length
        public static bool isFilledIn(string temp, int minLen)
        {
            bool result = false;
            if (temp.Length >= minLen)
            {
                result = true;
            }
            return result;
        }

        //Gets string to test if it meets the exact length requirements
        public static bool isValidLength(string temp, int exactlen)
        {
            bool result = false;
            if (temp.Length == exactlen)
            {
                result = true;
            }
            return result;
        }

        //Test if string length is within a range of numbers
        public static bool isWithinRange(string temp, int minLen, int maxLen)
        {
            bool result = false;
            if (temp.Length >= minLen && temp.Length <= maxLen)
            {
                result = true;
            }
            return result;
        }

        //Gets number to test if it is within a specified range
        public static bool isWithinRange(int temp, int minLen, int maxLen)
        {
            bool result = false;
            if (temp >= minLen && temp <= maxLen)
            {
                result = true;
            }
            return result;
        }

        //Checks to make sure a date time value is after the current date time value
        public static bool isAfterNow(DateTime date, DateTime now)
        {
            bool result = false;
            if (now < date)
            {
                result = true;
            }
            return result;
        }

        //Tests to see if email is valid
        public static bool isValidEmail(string temp)
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
            else if (atLocation + 2 >= periodLocation)
            {
                result = false;
            }

            return result;
        }

        public static bool isDateAfterDate(DateTime beginDate, DateTime endDate) 
        {
            bool result = false;
            DateTime newDateTime = beginDate.Subtract(new TimeSpan(0,0,1));
            int compare = DateTime.Compare(newDateTime, endDate);
            if (compare <= 0) 
            {
                result = true;
            }
            return result;
        }

    }
}