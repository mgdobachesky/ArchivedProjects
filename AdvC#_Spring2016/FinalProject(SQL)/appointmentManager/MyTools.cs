using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace appointmentManager
{
    class MyTools
    {
        public static SqlDataReader fillStates()
        {
            //get states from database and store them in data reader
            //create and start db tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

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
            SqlDataReader dr = comm.ExecuteReader();

            //return the combobox
            return dr;
        }

        public static SqlDataReader fillPeople()
        {
            //get states from database and store them in data reader
            //create and start db tools
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //connection string
            string strConn = MyTools.getConnected();

            //sql command string to pull the states
            string sqlString = "SELECT PersonId, FName, LName FROM PeopleFinal ORDER BY PersonId;";

            //tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //give the command object the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;

            //open the database connection and yell sql command
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();

            //return the combobox
            return dr;
        }

        public static string getConnected()
        {
            string strConn;
            strConn = "Server=sql.neit.edu;Database=se255_MDobachesky;User Id=se255_MDobachesky;Password=001264912;";
            return strConn;
        }
    }
}
