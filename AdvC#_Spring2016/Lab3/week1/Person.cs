using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationLibrary;

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
        protected string feedback;
        protected DateTime doe;

        //Allow access to feedback for testing purposes
        public string Feedback
        {
            get { return feedback; }
        }

        //Declare the public variables
        //Set private variables to the value of their public version
        //Validate the values while they are being passed to private
        public string FName
        {
            get { return fName; }
            set {
                if (Validation.isFilledIn(value))
                {
                    fName = value;
                }
                else
                {
                    feedback += "ERROR: Please fill in a first name. \n";
                }
            }
        }

        public string MName
        {
            get { return mName; }
            set { mName = value; }
        }

        public string LName
        {
            get { return lName; }
            set {
                if (Validation.isFilledIn(value))
                {
                    lName = value;
                }
                else
                {
                    feedback += "ERROR: Please fill in a last name. \n";
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
            set {
                if (Validation.isValidLength(value, 2))
                {
                    state = value;
                }
                else
                {
                    feedback += "ERROR: Please fill in a two letter state abbreviation. \n";
                }
            }
        }

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public string Phone
        {
            get { return phone; }
            set {
                if (Validation.isWithinRange(value, 7, 10))
                {
                    phone = value;
                }
                else
                {
                    feedback += "ERROR: Please fill in a valid phone number. \n";
                }
            }
        }

        public string Email
        {
            get { return email; }
            set {
                if (Validation.isValidEmail(value))
                {
                    email = value;
                }
                else
                {
                    feedback += "ERROR: Please fill in a valid email. \n";
                }
                }
        }
 

        //Default constructor
        public Person()
        {
            //Set feedback to an empty string
            feedback = "";
            //Store the date and time of the creation of this object
            doe = DateTime.Now;
        }

        //Overloaded constructor
        public Person(string fName, string mName, string lName, string street1, string street2, string city, string state, string zip, string phone, string email)
        {
            //Set feedback to an empty string
            feedback = "";
            //Store the date an time of the creation of this object
            doe = DateTime.Now;

            //Fill this objects public variables
            this.FName = fName;
            this.MName = mName;
            this.LName = lName;
            this.Street1 = street1;
            this.Street2 = street2;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Phone = phone;
            this.Email = email;
        }
    };
}
