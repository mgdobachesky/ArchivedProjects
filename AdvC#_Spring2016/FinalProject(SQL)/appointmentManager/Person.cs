using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

namespace appointmentManager
{
    //create appointment class
    public class Person
    {
        //declare the private variables
        private string fName;
        private string lName;
        private string street1;
        private string street2;
        private string city;
        private string state;
        private string zip;
        private string email;
        private string phone;
        private string feedback;
        private string data;
        private DateTime doe;

        public Int32 personId = 0;

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
            set
            {
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

        public string Phone
        {
            get { return phone; }
            set
            {
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
            set
            {
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

        //default constructor
        public Person()
        {
            //set feedback and data to an empty string
            feedback = "";
            data = "";
            //store the date and time of the creation of this object
            doe = DateTime.Now;
        }

        //Overloaded constructor
        public Person(string fName, string lName, string street1, string street2, string city, string state, string zip, string email, string phone)
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
            this.Email = email;
            this.Phone = phone;
        }

        //function that adds records to a database
        public string addRecord()
        {
            string results = "";

            //write sql command string
            string strSQL = "INSERT INTO PeopleFinal (FName, LName, Street1, Street2, City, State, Zip, Email, Phone) VALUES(@FName, @LName, @Street1, @Street2, @City, @State, @Zip, @Email, @Phone)";

            //create connection to the database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = MyTools.getConnected();

            //run the command
            SqlCommand comm = new SqlCommand();
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
            comm.Parameters.AddWithValue("@Email", email);
            comm.Parameters.AddWithValue("@Phone", phone);

            try
            {
                //open a database connection
                conn.Open();

                //add a record
                results = comm.ExecuteNonQuery().ToString() + " Person(s) Added";

                //close the database connection
                conn.Close();
            }
            catch (Exception err)
            {
                results = "ERROR: " + err.Message;
            }

            return results;
        }

        public DataSet searchPeople(String FirstName, String LastName)
        {
            //create an empty dataset what can later be returned
            DataSet ds = new DataSet();

            //create a command to write the sql query with
            SqlCommand comm = new SqlCommand();

            //write a select statement to do the appointment search with
            String strSql = "SELECT PersonId, FName, LName, Street1, Street2, City, State, Zip, Email, Phone FROM PeopleFinal WHERE 0=0";

            //include the search criteria if it is filled in
            if (FirstName.Length > 0)
            {
                strSql += " AND FName LIKE @FirstName";
                comm.Parameters.AddWithValue("@FirstName", "%" + FirstName + "%");
            }
            //include the search criteria if it is filled in
            if (LastName.Length > 0)
            {
                strSql += " AND LName LIKE @LastName";
                comm.Parameters.AddWithValue("@LastName", "%" + LastName + "%");
            }

            //create the who, what, and where of the db
            SqlConnection conn = new SqlConnection();
            string strConn = MyTools.getConnected();
            conn.ConnectionString = strConn;

            //fill in the information for the command object
            comm.Connection = conn;
            comm.CommandText = strSql;

            //create the data adapter and translate the query
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            //fill the dataset
            conn.Open();
            da.Fill(ds, "People");
            conn.Close();

            //return the dataset
            return ds;
        }

        public SqlDataReader PersonInformation(int personId)
        {
            //create the correct database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //connection string
            string strConn = MyTools.getConnected();

            //sql command used to pull data
            string sqlString = "SELECT PersonId, FName, LName, Street1, Street2, City, State, Zip, Email, Phone FROM PeopleFinal WHERE PersonId = @PersonId";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonId", personId);

            //open the database connection and return the results of the command
            conn.Open();
            return comm.ExecuteReader();
        }

        public Int32[] DeletePerson(int personId)
        {
            Int32 numAppointments = 0;
            Int32 numPeople = 0;

            //create and prepare the database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //connection string
            string strConn = MyTools.getConnected();

            //delete the person's appointments
            //sql command that deletes an appointment
            string sqlString = "DELETE FROM AppointmentsFinal WHERE PersonId = @PersonId;";

            //plug the connection string into the connection object
            conn.ConnectionString = strConn;

            //plug in the information that the command needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonId", personId);

            //open the database connection to input the command
            conn.Open();

            //run the delete and stor the number of records affected
            numAppointments = comm.ExecuteNonQuery();

            //close the connection
            conn.Close();

            //delete the person
            //sql command that deletes an appointment
            sqlString = "DELETE FROM PeopleFinal WHERE PersonId = @PersonId;";

            //plug the connection string into the connection object
            conn.ConnectionString = strConn;

            //plug in the information that the command needs
            comm.Connection = conn;
            comm.CommandText = sqlString;

            //open the database connection to input the command
            conn.Open();

            //run the delete and stor the number of records affected
            numPeople = comm.ExecuteNonQuery();

            //close the connection
            conn.Close();


            //return the number of records affected
            Int32[] deletedStuff = {numAppointments, numPeople};
            return deletedStuff;
        }

        public Int32[] peopleSelected(int personId)
        {
            //create the database tools to be used
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //connection string
            string strConn = MyTools.getConnected();
            
            //select appointments to be deleted
            //sql command used to pull data
            string sqlString = "SELECT COUNT(*) FROM AppointmentsFinal WHERE PersonId = @PersonId;";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonId", personId);

            //open the database connection and return the results
            conn.Open();
            Int32 appointmentCount = (Int32)comm.ExecuteScalar();
            conn.Close();
            
            //select people to be deleted
            //sql command used to pull data
            sqlString = "SELECT COUNT(*) FROM PeopleFinal WHERE PersonId = @PersonId;";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;

            //open the database connection and return the results
            conn.Open();
            Int32 personCount = (Int32)comm.ExecuteScalar();
            conn.Close();
            
            //make an array to return how many appointments will be deleted, as well as how many people
            Int32[] toDelete = {personCount, appointmentCount};
            return toDelete;
        }

        public Int32 updatePerson()
        {
            Int32 numRecords = 0;

            //write sql update statement
            string sqlString = "UPDATE PeopleFinal SET FName = @FName, LName = @LName, Street1 = @Street1, Street2 = @Street2, City = @City, State = @State, Zip = @Zip, Email = @Email, Phone = @Phone WHERE PersonId = @PersonId;";

            //create and set up a connection to the database
            SqlConnection conn = new SqlConnection();
            string strConn = MyTools.getConnected();
            conn.ConnectionString = strConn;

            //write and configure the command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = sqlString;
            comm.Connection = conn;

            //fill the parameters
            comm.Parameters.AddWithValue("@FName", fName);
            comm.Parameters.AddWithValue("@LName", lName);
            comm.Parameters.AddWithValue("@Street1", street1);
            comm.Parameters.AddWithValue("@Street2", street2);
            comm.Parameters.AddWithValue("@City", city);
            comm.Parameters.AddWithValue("@State", state);
            comm.Parameters.AddWithValue("@Zip", zip);
            comm.Parameters.AddWithValue("@Email", email);
            comm.Parameters.AddWithValue("@Phone", phone);
            comm.Parameters.AddWithValue("@PersonId", personId);

            try
            {
                //open the connection
                conn.Open();

                //update records and store how many were affected
                numRecords = comm.ExecuteNonQuery();
            }

            catch (Exception error)
            {
                var errors = error;
            }

            finally
            {
                //close the connection
                conn.Close();
            }

            return numRecords;
        }

    }
}
