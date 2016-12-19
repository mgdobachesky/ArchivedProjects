using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace se256_Dobachesky
{
    public class User
    {
        #region Constructors
        //default constructor, just allows access to properties and methods
        public User()
        {
            //constructor logic
        }

        //overloaded constructor, takes an id as a parameter and fills the object's properties with the appropriate data
        public User(int id)
        {
            //use private method to get the datatable for the specified user
            DataTable dt = se256_Dobachesky.User.GetUser(id);

            //if a record was found with that id, set the properties of this class
            if (dt.Rows.Count > 0)
            {
                this.user_id = Convert.ToInt32(dt.Rows[0]["user_id"].ToString());
                this.user_email = dt.Rows[0]["user_email"].ToString();
                this.user_first = dt.Rows[0]["user_first"].ToString();
                this.user_last = dt.Rows[0]["user_last"].ToString();
                this.user_add1 = dt.Rows[0]["user_add1"].ToString();
                this.user_add2 = dt.Rows[0]["user_add2"].ToString();
                this.user_city = dt.Rows[0]["user_city"].ToString();
                this.state_id = dt.Rows[0]["state_id"].ToString();
                this.user_zip = dt.Rows[0]["user_zip"].ToString();
                this.user_password = dt.Rows[0]["user_pwd"].ToString();
                this.user_phone = dt.Rows[0]["user_phone"].ToString();
                this.user_active = Convert.ToBoolean(dt.Rows[0]["user_active"].ToString());
            }

        }
        #endregion

        #region Properties
        public int user_id { get; set; }
        public string user_email { get; set; }
        public string user_first { get; set; }
        public string user_last { get; set; }
        public string user_add1 { get; set; }
        public string user_add2 { get; set; }
        public string user_city { get; set; }
        public string state_id { get; set; }
        public string user_zip { get; set; }
        public string user_password { get; set; }
        public string user_phone { get; set; }
        public bool user_active { get; set; }
        #endregion

        #region Methods
        private static DataTable GetUser(int id)
        {
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("users_getById", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters to stored procedure
            SqlParameter pUserId = new SqlParameter("@user_id", SqlDbType.Int);
            pUserId.Value = id;
            cmd.Parameters.Add(pUserId);

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

        public static bool UpdateUser(se256_Dobachesky.User aUser)
        {
            //start out with the boolean value at false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("users_update", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //add the parameters to be used in the update method
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = aUser.user_id;
            cmd.Parameters.Add("@user_email", SqlDbType.VarChar).Value = aUser.user_email;
            cmd.Parameters.Add("@user_first", SqlDbType.VarChar).Value = aUser.user_first;
            cmd.Parameters.Add("@user_last", SqlDbType.VarChar).Value = aUser.user_last;
            cmd.Parameters.Add("@user_add1", SqlDbType.VarChar).Value = aUser.user_add1;
            cmd.Parameters.Add("@user_add2", SqlDbType.VarChar).Value = aUser.user_add2;
            cmd.Parameters.Add("@user_city", SqlDbType.VarChar).Value = aUser.user_city;
            cmd.Parameters.Add("@state_id", SqlDbType.VarChar).Value = aUser.state_id;
            cmd.Parameters.Add("@user_zip", SqlDbType.VarChar).Value = aUser.user_zip;
            cmd.Parameters.Add("@user_salt", SqlDbType.VarChar).Value = "salt";
            cmd.Parameters.Add("@user_pwd", SqlDbType.VarChar).Value = aUser.user_password;
            cmd.Parameters.Add("@user_phone", SqlDbType.VarChar).Value = aUser.user_phone;
            cmd.Parameters.Add("@user_active", SqlDbType.Bit).Value = aUser.user_active;

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

        public static bool InsertUser(se256_Dobachesky.User aUser)
        {
            //start out with the boolean equal to false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("users_insert", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //fill the parameters of the stored procedure
            cmd.Parameters.Add("@user_email", SqlDbType.VarChar).Value = aUser.user_email;
            cmd.Parameters.Add("@user_first", SqlDbType.VarChar).Value = aUser.user_first;
            cmd.Parameters.Add("@user_last", SqlDbType.VarChar).Value = aUser.user_last;
            cmd.Parameters.Add("@user_add1", SqlDbType.VarChar).Value = aUser.user_add1;
            cmd.Parameters.Add("@user_add2", SqlDbType.VarChar).Value = aUser.user_add2;
            cmd.Parameters.Add("@user_city", SqlDbType.VarChar).Value = aUser.user_city;
            cmd.Parameters.Add("@state_id", SqlDbType.VarChar).Value = aUser.state_id;
            cmd.Parameters.Add("@user_zip", SqlDbType.VarChar).Value = aUser.user_zip;
            cmd.Parameters.Add("@user_salt", SqlDbType.VarChar).Value = "salt";
            cmd.Parameters.Add("@user_pwd", SqlDbType.VarChar).Value = aUser.user_password;
            cmd.Parameters.Add("@user_phone", SqlDbType.VarChar).Value = aUser.user_phone;
            cmd.Parameters.Add("@user_active", SqlDbType.Bit).Value = aUser.user_active;

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

        public static DataTable Login(string userEmail, string userPassword)
        {
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("users_login", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters to stored procedure
            SqlParameter pUserEmail = new SqlParameter("@user_email", SqlDbType.VarChar, 100);
            pUserEmail.Value = userEmail;
            cmd.Parameters.Add(pUserEmail);
            SqlParameter pPassword = new SqlParameter("@user_pwd", SqlDbType.VarChar, 500);
            pPassword.Value = userPassword;
            cmd.Parameters.Add(pPassword);

            //initialize return value
            DataTable dt = new DataTable();

            //open database connection and execute the command
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                conn.Close();
            }

            //return dataset
            return dt;
        }
        #endregion
    }
}