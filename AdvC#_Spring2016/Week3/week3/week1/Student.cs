using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationLibrary;

namespace week1
{
    //Create the student class
    public class Student: Person
    {
        private double gpa;

        public double GPA
        {
            get { return gpa; }
            set
            {
                if (Validation.isWithinRange(value, 0, 4))
                {
                    gpa = value;
                }
                else
                {
                    feedback += "ERROR: Please fill in a valid GPA. \n";
                }
            }
        }

        //Default Constructor
        public Student():base()
        {
        }

        //Overload Constructor
        public Student(string fName, string mName, string lName, string street1, string street2, string city, string state, string zip, string phone, string email, double gpa):base()
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
            this.GPA = gpa;
        }
    }
}
