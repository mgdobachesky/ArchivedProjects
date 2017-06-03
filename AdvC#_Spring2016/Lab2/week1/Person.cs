using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week1
{
    //Create the Person class
    public class Person
    {
        //Declare the private variables to be used with public input
        private string fName;
        private string mName;
        private string lName;
        private string street1;
        private string street2;
        private string city;
        private string state;
        private string zip;
        private string phone;
        private string email;

        //Declare the public variables
        //Set private variables to the value of their public version
        //Validate the values while they are being passed to private
        public string FName
        {
            get { return fName; }
            set {
                if (value.Contains("Poopy"))
                {
                    fName = "INVALID";
                }
                else
                {
                    fName = value;
                }
            }
        }

        public string MName
        {
            get { return mName; }
            set {
                if (value.Contains("Poopy"))
                {
                    mName = "INVALID";
                }
                else
                {
                    mName = value;
                }
            }
        }

        public string LName
        {
            get { return lName; }
            set {
                if (value.Contains("Poopy"))
                {
                    lName = "INVALID";
                }
                else
                {
                    lName = value;
                }
            }
        }

        public string Street1
        {
            get { return street1; }
            set { street1 = value; }
        }

        public string Street2
        {
            get { return street2; }
            set { street2 = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
 
    };
}
