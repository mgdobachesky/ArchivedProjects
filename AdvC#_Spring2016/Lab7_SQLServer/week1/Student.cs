 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidationLibrary;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

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

        public Int32 personId = 0;

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

        public string AddRecord()
        {
            string results = "";

            //Write SQL command string
            string strSQL = "INSERT INTO Persons (FName, MName, LName, Street1, Street2, City, State, Zip, Phone, Email, GPA) VALUES(@FName, @MName, @LName, @Street1, @Street2, @City, @State, @Zip, @Phone, @Email, @GPA);";

            //Create a connection to the database
            SqlConnection conn = new SqlConnection();

            //Determine the who, what, and where of the Database
            conn.ConnectionString = MyUtilities.GetConnected();

            //Run the command
            SqlCommand comm = new SqlCommand();
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
            comm.Parameters.AddWithValue("@GPA", gpa);

            try
            {
                //Open a connection to the db
                conn.Open();

                //Here is where we will add a record
                results = comm.ExecuteNonQuery().ToString() + " Records Added";

                //Close the db
                conn.Close();
            }
            catch (Exception err)
            {
                results = "ERROR: " + err.Message;
            }

            return results;
        }

        public DataSet searchFunction(String FName, String LName)
        {
            //create an empty dataset that can later be returned after it is filled
            DataSet ds = new DataSet();

            //create a command to write an sql query with
            SqlCommand comm = new SqlCommand();

            //write a select statement to do the db search with
            String strSQL = "SELECT ID, FName, MName, LName, Street1, Street2, City, State, Zip, Phone, Email, GPA FROM Persons WHERE 0=0";

            //include the search criteria if it is filled in
            if (FName.Length > 0)
            {
                strSQL += " AND FName LIKE @FName";
                comm.Parameters.AddWithValue("@FName", "%" + FName + "%");
            }
            if (LName.Length > 0)
            {
                strSQL += " AND LName LIKE @LName";
                comm.Parameters.AddWithValue("@LName", "%" + LName + "%");
            }

            //create database tools and configure the database part 1
            //create the who, what, and where of the db
            SqlConnection conn = new SqlConnection();
            string strConn = MyUtilities.GetConnected();
            conn.ConnectionString = strConn;

            //create database tools and configure the database part 2
            //fill in information for command object
            comm.Connection = conn;
            comm.CommandText = strSQL;

            //create database tools and configure the database part 3
            //create the data adapter to translate the query
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            //fill the dataset
            conn.Open();
            da.Fill(ds, "Persons");
            conn.Close();

            //return the dataset
            return ds;
        }

        //method for returning the data for a person of a specified id
        public SqlDataReader findData(int intId)
        {
            //create the database tools to be used
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //connection string
            string strConn = MyUtilities.GetConnected();

            //sql command used to pull data
            string sqlString = "SELECT ID, FName, MName, LName, Street1, Street2, City, State, Zip, Phone, Email, GPA FROM Persons WHERE ID = @intId;";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@intId", intId);

            //open the database connection and return the results of the command
            conn.Open();
            return comm.ExecuteReader();
        }

        //delete a record of a specific ID and return an integer of the number of records affected
        public Int32 DeletePerson(int personId)
        {
            Int32 numRecords = 0;

            //create and prepare the database tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //connection string
            string connString = MyUtilities.GetConnected();

            //sql command that deletes a persons data
            string sqlSting = "DELETE FROM Persons WHERE ID = @personId;";

            //plug in the connection string to the connection object
            conn.ConnectionString = connString;

            //plug in the information that the command needs
            comm.Connection = conn;
            comm.CommandText = sqlSting;
            comm.Parameters.AddWithValue("@personId", personId);

            //open the database connection to input the command
            conn.Open();

            //run the delete and store the number of records affected
            numRecords = comm.ExecuteNonQuery();

            //close the connection
            conn.Close();

            //return the number of records affected
            return numRecords;
        }

        public Int32 recordsSelected(int intId)
        {
            //create the database tools to be used
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //connection string
            string strConn = MyUtilities.GetConnected();

            //sql command used to pull data
            string sqlString = "SELECT COUNT(*) FROM Persons WHERE ID = @intId;";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@intId", intId);

            //open the database connection and return the results of the command
            conn.Open();
            Int32 rowCount = (Int32)comm.ExecuteScalar();
            return rowCount;
        }

        public Int32 updateContact()
        {
            Int32 numRecords = 0;

            //write sql update statement
            string sqlString = "UPDATE Persons SET FName = @FName, MName = @MName, LName = @LName, Street1 = @Street1, Street2 = @Street2, City = @City, State = @State, Zip = @Zip, Phone = @Phone, Email = @Email, GPA = @GPA WHERE ID = @personId;";
            
            //create and set up a connection to the database
            SqlConnection conn = new SqlConnection();
            string connStr = MyUtilities.GetConnected();
            conn.ConnectionString = connStr;

            //write and configure the command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = sqlString;
            comm.Connection = conn;

            //fill the parameters
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
            comm.Parameters.AddWithValue("@GPA", gpa);
            comm.Parameters.AddWithValue("@personId", personId);

            try
            {
                //open the connection
                conn.Open();

                //update records and store the number of records affected
                numRecords = comm.ExecuteNonQuery();
            }

            catch (Exception error)
            {
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
