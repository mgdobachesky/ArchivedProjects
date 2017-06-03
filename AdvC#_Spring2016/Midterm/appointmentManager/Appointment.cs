using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections;

namespace appointmentManager
{
    //create appointment class
    public class Appointment
    {
        //declare the private variables
        private string fName;
        private string lName;
        private string street1;
        private string street2;
        private string city;
        private string state;
        private string zip;
        private DateTime start;
        private DateTime end;
        private string comments;
        private string feedback;
        private string data;
        private DateTime doe;

        //allow access to feedback
        public string Feedback
        {
            get { return feedback; }
        }

        //allow access to data
        public string Data
        {
            get { return data; }
        }

        //create gets and sets for accessing private variables
        public string FName
        {
            get { return fName; }
            set {
                if (Validation.isFilledIn(value))
                {
                    fName = value;
                    data += fName + "\n";
                }
                else
                {
                    feedback += "ERROR: Please fill in a first name. \n";
                }
            }
        }

        public string LName
        {
            get { return lName; }
            set
            {
                if (Validation.isFilledIn(value))
                {
                    lName = value;
                    data += lName + "\n";
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
            set
            {
                if (Validation.isFilledIn(value))
                {
                    street1 = value;
                    data += street1 + "\n";
                }
                else
                {
                    feedback += "ERROR: Please fill in a street. \n";
                }
            }
        }

        public string Street2
        {
            get { return street2; }
            set 
            {
                street2 = value;
                if (Validation.isFilledIn(value))
                {
                    data += street2 + "\n";
                }
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (Validation.isFilledIn(value))
                {
                    city = value;
                    data += city + "\n";
                }
                else
                {
                    feedback += "ERROR: Please fill in a city. \n";
                }
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                if (Validation.isFilledIn(value))
                {
                    state = value;
                    data += state + "\n";
                }
                else
                {
                    feedback += "ERROR: Please fill in a state. \n";
                }
            }
        }

        public string Zip
        {
            get { return zip; }
            set
            {
                if (Validation.isFilledIn(value))
                {
                    zip = value;
                    data += zip + "\n";
                }
                else
                {
                    feedback += "ERROR: Please fill in a zip code. \n";
                }
            }
        }

        public DateTime startVal;
        public DateTime endVal;

        public DateTime Start
        {
            get { return start; }
            set
            {
                if (Validation.isDateAfterDate(startVal, endVal))
                {
                    start = value;
                    data += "Start: " + start + "\n";
                }
                else
                {
                    feedback += "ERROR: Please choose an appointment that ends after it begins. \n";
                }
            }
        }

        public DateTime End
        {
            get { return end; }
            set
            {
                if (Validation.isDateAfterDate(startVal, endVal))
                {
                    end = value;
                    data += "End: " + end + "\n";
                }
            }
        }

        public string Comments
        {
            get { return comments; }
            set 
            { 
                comments = value;
                data += comments + "\n";
            }
        }

        //default constructor
        public Appointment()
        {
            //set feedback and data to an empty string
            feedback = "";
            data = "";
            //store the date and time of the creation of this object
            doe = DateTime.Now;
        }

        //Overloaded constructor
        public Appointment(string fName, string lName, string street1, string street2, string city, string state, string zip, DateTime start, DateTime end, string comments)
        {
            //set feedback and data to an empty string
            feedback = "";
            data = "";
            //store the date and time of the creation of this object
            doe = DateTime.Now;

            //fill this forms variables
            this.FName = fName;
            this.LName = lName;
            this.Street1 = street1;
            this.Street2 = street2;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.Start = start;
            this.End = end;
            this.Comments = comments;
        }

        //function that adds records to a database
        public string addRecord()
        {
            string results = "";

            //write sql command string
            string strSQL = "INSERT INTO Appointments (FName, LName, Street1, Street2, City, State, Zip, StartDate, EndDate, Comments) VALUES(@FName, @LName, @Street1, @Street2, @City, @State, @Zip, @StartDate, @EndDate, @Comments)";

            //create connection to the database
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=appointments.accdb;Persist Security Info=False;";
        
            //run the command
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;

            //bind the values in the SQL statement
            comm.Parameters.AddWithValue("@FName", fName);
            comm.Parameters.AddWithValue("@LName", lName);
            comm.Parameters.AddWithValue("@Street1", street1);
            comm.Parameters.AddWithValue("@Street2", street2);
            comm.Parameters.AddWithValue("@City", city);
            comm.Parameters.AddWithValue("@State", state);
            comm.Parameters.AddWithValue("@Zip", zip);
            comm.Parameters.AddWithValue("@StartDate", start);
            comm.Parameters.AddWithValue("@EndDate", end);
            comm.Parameters.AddWithValue("@Comments", comments);

            try
            {
                //open a database connection
                conn.Open();

                //add a record
                results = comm.ExecuteNonQuery().ToString() + " Appointment(s) Added";
 
                //close the database connection
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
