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
        private int personId;
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

        public Int32 appointmentId = 0;

        //allow access to the person id
        public int PersonId
        {
            get { return personId; }
            set {
                if (Validation.isFilledIn(value) && value != 0)
                {
                    personId = value;
                    data += "Person Id: " + personId + "\n";
                }
                else
                {
                    feedback += "ERROR: Please choose a person \n";
                }
            }
        }

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
        public Appointment(Int32 personId, string street1, string street2, string city, string state, string zip, DateTime start, DateTime end, string comments)
        {
            //set feedback and data to an empty string
            feedback = "";
            data = "";
            //store the date and time of the creation of this object
            doe = DateTime.Now;

            //fill this forms variables
            this.PersonId = personId;
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
            string strSQL = "INSERT INTO Appointments (PersonId, Street1, Street2, City, State, Zip, StartDate, EndDate, Comments) VALUES(@PersonId, @Street1, @Street2, @City, @State, @Zip, @StartDate, @EndDate, @Comments)";

            //create connection to the database
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = MyTools.getConnected();
        
            //run the command
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;

            //bind the values in the SQL statement
            comm.Parameters.AddWithValue("@PersonId", personId);
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

        public DataSet searchAppointments(Int32 personId)
        {
            //create an empty dataset what can later be returned
            DataSet ds = new DataSet();

            //create a command to write the sql query with
            OleDbCommand comm = new OleDbCommand();

            //write a select statement to do the appointment search with
            String strSql = "SELECT AppointmentId, Street1, Street2, City, State, Zip, StartDate, EndDate, Comments FROM Appointments WHERE PersonId = @PersonId;";

            //create the who, what, and where of the db
            OleDbConnection conn = new OleDbConnection();
            string strConn = MyTools.getConnected();
            conn.ConnectionString = strConn;

            //fill in the information for the command object
            comm.Connection = conn;
            comm.CommandText = strSql;
            comm.Parameters.AddWithValue("@PersonId", personId);

            //create the data adapter and translate the query
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = comm;

            //fill the dataset
            conn.Open();
            da.Fill(ds, "Appointments");
            conn.Close();

            //return the dataset
            return ds;
        }

        public OleDbDataReader AppointmentInformation(int appointmentId)
        {
            //create the correct database tools
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();

            //connection string
            string strConn = MyTools.getConnected();

            //sql command used to pull data
            string sqlString = "SELECT AppointmentId, PersonId, Street1, Street2, City, State, Zip, StartDate, EndDate, Comments FROM Appointments WHERE AppointmentId = @AppointmentId;";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@AppointmentId", appointmentId);

            //open the database connection and return the results of the command
            conn.Open();
            return comm.ExecuteReader();
        }

        public Int32 DeleteAppointment(int appointmentId)
        {
            Int32 numRecords = 0;

            //create and prepare the database tools
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();

            //connection string
            string strConn = MyTools.getConnected();

            //sql command that deletes an appointment
            string sqlString = "DELETE FROM Appointments WHERE AppointmentId = @AppointmentId;";

            //plug the connection string into the connection object
            conn.ConnectionString = strConn;

            //plug in the information that the command needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@AppointmentId", appointmentId);

            //open the database connection to input the command
            conn.Open();

            //run the delete and stor the number of records affected
            numRecords = comm.ExecuteNonQuery();
            
            //close the connection
            conn.Close();

            //return the number of records affected
            return numRecords;
        }

        public Int32 recordsSelected(int appointmentId)
        {
            //create the database tools to be used
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();

            //connection string
            string strConn = MyTools.getConnected();

            //sql command used to pull data
            string sqlString = "SELECT COUNT(*) FROM Appointments WHERE AppointmentId = @AppointmentId;";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@AppointmentId", appointmentId);

            //open the database connection and return the results
            conn.Open();
            Int32 rowCount = (Int32)comm.ExecuteScalar();
            return rowCount;
        }

        public Int32 updateAppointment()
        {
            Int32 numRecords = 0;

            //write sql update statement
            string sqlString = "UPDATE Appointments SET Street1 = @Street1, Street2 = @Street2, City = @City, State = @State, Zip = @Zip, StartDate = @StartDate, EndDate = @EndDate, Comments = @Comments WHERE AppointmentId = @AppointmentId";

            //create and set up a connection to the database
            OleDbConnection conn = new OleDbConnection();
            string strConn = MyTools.getConnected();
            conn.ConnectionString = strConn;

            //write and configure the command
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = sqlString;
            comm.Connection = conn;

            //fill the parameters
            comm.Parameters.AddWithValue("@Street1", street1);
            comm.Parameters.AddWithValue("@Street2", street2);
            comm.Parameters.AddWithValue("@City", city);
            comm.Parameters.AddWithValue("@State", state);
            comm.Parameters.AddWithValue("@Zip", zip);
            comm.Parameters.AddWithValue("@StartDate", start);
            comm.Parameters.AddWithValue("@EndDate", end);
            comm.Parameters.AddWithValue("@Comments", comments);
            comm.Parameters.AddWithValue("@AppointmentId", appointmentId);

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
