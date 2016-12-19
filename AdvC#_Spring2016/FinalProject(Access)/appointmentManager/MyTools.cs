using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Drawing;

namespace appointmentManager
{
    class MyTools
    {
        public static OleDbDataReader fillStates()
        {
            //get states from database and store them in data reader
            //create and start db tools
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();

            //connection string
            string strConn = MyTools.getConnected();

            //sql command string to pull the states
            string sqlString = "SELECT * FROM States ORDER BY State;";

            //tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //give the command object the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;

            //open the database connection and yell sql command
            conn.Open();
            OleDbDataReader dr = comm.ExecuteReader();

            //return the combobox
            return dr;
        }

        public static OleDbDataReader fillPeople()
        {
            //get states from database and store them in data reader
            //create and start db tools
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();

            //connection string
            string strConn = MyTools.getConnected();

            //sql command string to pull the states
            string sqlString = "SELECT PersonId, FName, LName FROM People ORDER BY PersonId;";

            //tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //give the command object the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;

            //open the database connection and yell sql command
            conn.Open();
            OleDbDataReader dr = comm.ExecuteReader();

            //return the combobox
            return dr;
        }

        public static string getConnected()
        {
            string strConn;
            strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=appointments.accdb;Persist Security Info=False;";
            return strConn;
        }
    }
}
