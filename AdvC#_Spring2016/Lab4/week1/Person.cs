using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationLibrary;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections;

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
            //Get default zip code from file and then set it as the value for the zip code
            StreamReader sr = new StreamReader(File.Open(@"defaultZip.txt", FileMode.Open));
            string defaultZip = sr.ReadLine();
            sr.Close();
            zip = defaultZip;

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

        public string AddRecord()
        {
            string results = "";

            //Write SQL command string
            string strSQL = "INSERT INTO Persons (FName, MName, LName, Street1, Street2, City, State, Zip, Phone, Email) VALUES(@FName, @MName, @LName, @Street1, @Street2, @City, @State, @Zip, @Phone, @Email)";
           
            //Create a connection to the database
            OleDbConnection conn = new OleDbConnection();

            //Determine the who, what, and where of the Database
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=contacts.accdb;Persist Security Info=False;";

            //Run the command
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;

            //Fill in the SQL statement
            comm.Parameters.AddWithValue("@FName", fName);
            comm.Parameters.AddWithValue("@MName", MName);
            comm.Parameters.AddWithValue("@LName", lName);
            comm.Parameters.AddWithValue("@Street1", street1);
            comm.Parameters.AddWithValue("@Street2", street2);
            comm.Parameters.AddWithValue("@City", city);
            comm.Parameters.AddWithValue("@State", state);
            comm.Parameters.AddWithValue("@Zip", zip);
            comm.Parameters.AddWithValue("@Phone", phone);
            comm.Parameters.AddWithValue("@Email", email);

            try
            {
                //Open a connection to the db
                conn.Open();

                //Here is where we will add a record
                results = comm.ExecuteNonQuery().ToString() + " Records Added";

                //Close the db
                conn.Close();
            }
            catch(Exception err)
            {
                results = "ERROR: " + err.Message;
            }

            return results;
        }

    }
}
