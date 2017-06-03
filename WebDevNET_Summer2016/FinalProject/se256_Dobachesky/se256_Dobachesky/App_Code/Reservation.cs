using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace se256_Dobachesky
{
    public class Reservation
    {
        #region Constructors
        //default constructor, just allows access to properties and methods
        public Reservation()
        {
            
        }

        //overloaded constructor, takes an id as a parameter and fills the object's properties with the appropriate data
        public Reservation(int id)
        {
            //use private method to get the datatable for the specified reservation
            DataTable dt = se256_Dobachesky.Reservation.GetReservation(id);

            //if a record was found with that id, set the properties of this class
            if (dt.Rows.Count > 0)
            {
                this.res_id = Convert.ToInt32(dt.Rows[0]["res_id"].ToString());
                this.guest_id = Convert.ToInt32(dt.Rows[0]["guest_id"].ToString());
                this.tbl_id = Convert.ToInt32(dt.Rows[0]["tbl_id"].ToString());
                this.user_id = Convert.ToInt32(dt.Rows[0]["user_id"].ToString());
                this.res_date = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dt.Rows[0]["res_date"].ToString()));
                this.res_time = String.Format("{0:HH:mm:ss}", Convert.ToDateTime(dt.Rows[0]["res_time"].ToString()));
                this.res_guest_cnt = Convert.ToInt32(dt.Rows[0]["res_guest_cnt"].ToString());
                this.res_spec_req = dt.Rows[0]["res_spec_req"].ToString();
            }

        }
        #endregion

        #region Properties
        public int res_id { get; set; }
        public int guest_id { get; set; }
        public int tbl_id { get; set; }
        public int user_id { get; set; }
        public string res_date { get; set; }
        public string res_time { get; set; }
        public int res_guest_cnt { get; set; }
        public string res_spec_req { get; set; }
        #endregion

        #region Methods
        private static DataTable GetReservation(int id)
        {
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("reservations_getById", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters to stored procedure
            SqlParameter pResId = new SqlParameter("@res_id", SqlDbType.Int);
            pResId.Value = id;
            cmd.Parameters.Add(pResId);

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

        public static bool UpdateReservation(se256_Dobachesky.Reservation aReservation)
        {
            //start out with the boolean value at false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("reservations_update", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //add the parameters to be used in the update method
            cmd.Parameters.Add("@res_id", SqlDbType.Int).Value = aReservation.res_id;
            cmd.Parameters.Add("@guest_id", SqlDbType.Int).Value = aReservation.guest_id;
            cmd.Parameters.Add("@tbl_id", SqlDbType.Int).Value = aReservation.tbl_id;
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = aReservation.user_id;
            cmd.Parameters.Add("@res_date", SqlDbType.DateTime).Value = aReservation.res_date;
            cmd.Parameters.Add("@res_time", SqlDbType.Time).Value = aReservation.res_time;
            cmd.Parameters.Add("@res_guest_cnt", SqlDbType.Int).Value = aReservation.res_guest_cnt;
            cmd.Parameters.Add("@res_spec_req", SqlDbType.VarChar).Value = aReservation.res_spec_req;

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

        public static bool InsertReservation(se256_Dobachesky.Reservation aReservation)
        {
            //start out with the boolean equal to false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("reservations_insert", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //fill the parameters of the stored procedure
            cmd.Parameters.Add("@guest_id", SqlDbType.Int).Value = aReservation.guest_id;
            cmd.Parameters.Add("@tbl_id", SqlDbType.Int).Value = aReservation.tbl_id;
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = aReservation.user_id;
            cmd.Parameters.Add("@res_date", SqlDbType.DateTime).Value = aReservation.res_date;
            cmd.Parameters.Add("@res_time", SqlDbType.Time).Value = aReservation.res_time;
            cmd.Parameters.Add("@res_guest_cnt", SqlDbType.Int).Value = aReservation.res_guest_cnt;
            cmd.Parameters.Add("@res_spec_req", SqlDbType.VarChar).Value = aReservation.res_spec_req;

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

        public static string CheckReservation(string resDate, string resTime, int guestCount)
        {
            //instantiate the results string
            string results = "";

            //convert and format the reservation date and time
            string resDateConvert = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(resDate.ToString()));
            string resTimeConvert = String.Format("{0:HH:mm:ss}", Convert.ToDateTime(resTime.ToString()));

            //create sql connection object that gets the connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("tables_getTableForNewRes", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //fill the parameters of the stored procedure
            cmd.Parameters.Add("@head_count", SqlDbType.Int).Value = guestCount;
            cmd.Parameters.Add("@res_date", SqlDbType.Date).Value = resDateConvert;
            cmd.Parameters.Add("@res_time", SqlDbType.Time).Value = resTimeConvert;

            //initialize a data table
            DataTable dt = new DataTable();

            //try to open the connection and run the update, then set the boolean to true
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                results = dt.Rows[0]["tbl_id"].ToString();
            }
            //prepare the error as a string and set boolean to false
            catch (Exception e)
            {
                results = "";
                e.ToString();
            }
            //close the connection
            finally
            {
                conn.Close();
            }

            //return the results
            return results;
        }
        #endregion
    }
}