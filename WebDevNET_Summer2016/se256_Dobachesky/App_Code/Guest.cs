using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace se256_Dobachesky
{
    public class Guest
    {
        #region Constructors
        //default constructor, just allows access to properties and methods
        public Guest()
        {
            //constructor logic
        }

        //overloaded constructor, takes an id as a parameter and fills the object's properties with the appropriate data
        public Guest(int id)
        {
            //use private method to get the datatable for the specified guest
            DataTable dt = se256_Dobachesky.Guest.GetGuestById(id);

            //if a record was found with that id, set the properties of this class
            if (dt.Rows.Count > 0)
            {
                this.guest_id = Convert.ToInt32(dt.Rows[0]["guest_id"].ToString());
                this.guest_email = dt.Rows[0]["guest_email"].ToString();
                this.guest_first = dt.Rows[0]["guest_first"].ToString();
                this.guest_last = dt.Rows[0]["guest_last"].ToString();
                this.guest_pwd = dt.Rows[0]["guest_pwd"].ToString();
                this.guest_phone = dt.Rows[0]["guest_phone"].ToString();
            }

        }

        //overloaded constructor, takes an email as a parameter and fills the object's properties with the appropriate data
        public Guest(string email)
        {
            //use private method to get the datatable for the specified guest
            DataTable dt = se256_Dobachesky.Guest.GetGuestByEmail(email);

            //if a record was found with that id, set the properties of this class
            if (dt.Rows.Count > 0)
            {
                this.guest_id = Convert.ToInt32(dt.Rows[0]["guest_id"].ToString());
                this.guest_email = dt.Rows[0]["guest_email"].ToString();
                this.guest_first = dt.Rows[0]["guest_first"].ToString();
                this.guest_last = dt.Rows[0]["guest_last"].ToString();
                this.guest_pwd = dt.Rows[0]["guest_pwd"].ToString();
                this.guest_phone = dt.Rows[0]["guest_phone"].ToString();
            }

        }
        #endregion

        #region Properties
        public int guest_id { get; set; }
        public string guest_email { get; set; }
        public string guest_first { get; set; }
        public string guest_last { get; set; }
        public string guest_pwd { get; set; }
        public string guest_phone { get; set; }
        #endregion

        #region Methods
        private static DataTable GetGuestById(int id)
        {
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("guests_getById", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters to stored procedure
            SqlParameter pGuestId = new SqlParameter("@guest_id", SqlDbType.Int);
            pGuestId.Value = id;
            cmd.Parameters.Add(pGuestId);

            //initialize return value
            DataTable dt = new DataTable();

            //open database connection and execute the command
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            //return dataset
            return dt;
        }

        private static DataTable GetGuestByEmail(string email)
        {
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("guests_getByEmail", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters to stored procedure
            SqlParameter pGuestEmail = new SqlParameter("@guest_email", SqlDbType.VarChar);
            pGuestEmail.Value = email;
            cmd.Parameters.Add(pGuestEmail);

            //initialize return value
            DataTable dt = new DataTable();

            //open database connection and execute the command
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            //return dataset
            return dt;
        }

        public static bool UpdateGuest(se256_Dobachesky.Guest aGuest)
        {
            //start out with the boolean value at false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("guests_update", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //add the parameters to be used in the update method
            cmd.Parameters.Add("@guest_id", SqlDbType.Int).Value = aGuest.guest_id;
            cmd.Parameters.Add("@guest_email", SqlDbType.VarChar).Value = aGuest.guest_email;
            cmd.Parameters.Add("@guest_first", SqlDbType.VarChar).Value = aGuest.guest_first;
            cmd.Parameters.Add("@guest_last", SqlDbType.VarChar).Value = aGuest.guest_last;
            cmd.Parameters.Add("@guest_salt", SqlDbType.VarChar).Value = "salt";
            cmd.Parameters.Add("@guest_pwd", SqlDbType.VarChar).Value = aGuest.guest_pwd;
            cmd.Parameters.Add("@guest_phone", SqlDbType.VarChar).Value = aGuest.guest_phone;

            //try to open the connection and run the command, then set the boolean value to true
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                blnSuccess = true;
            }
            //prepare the error as a string and set boolean value to false
            catch (Exception e)
            {
                e.ToString();
                blnSuccess = false;
            }
            //close the connection
            finally
            {
                conn.Close();
            }
            //return the boolean containing information as to of if the operation was a success or not
            return blnSuccess;
        }

        public static bool InsertGuest(se256_Dobachesky.Guest aGuest)
        {
            //start out with the boolean equal to false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("guests_insert", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //fill the parameters of the stored procedure
            cmd.Parameters.Add("@guest_email", SqlDbType.VarChar).Value = aGuest.guest_email;
            cmd.Parameters.Add("@guest_first", SqlDbType.VarChar).Value = aGuest.guest_first;
            cmd.Parameters.Add("@guest_last", SqlDbType.VarChar).Value = aGuest.guest_last;
            cmd.Parameters.Add("@guest_salt", SqlDbType.VarChar).Value = "salt";
            cmd.Parameters.Add("@guest_pwd", SqlDbType.VarChar).Value = "password";
            cmd.Parameters.Add("@guest_phone", SqlDbType.VarChar).Value = aGuest.guest_phone;

            //try to open the connection and run the update, then set the boolean to true
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                blnSuccess = true;
            }
            //prepare the error as a string and set boolean to false
            catch (Exception e)
            {
                e.ToString();
                blnSuccess = false;
            }
            //close the connection
            finally
            {
                conn.Close();
            }
            //return whether or not the method was successful
            return blnSuccess;
        }
        #endregion
    }
}