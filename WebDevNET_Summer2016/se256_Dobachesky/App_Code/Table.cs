using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace se256_Dobachesky
{
    public class Table
    {
        #region Constructors
        //default constructor, just allows access to properties and methods
        public Table()
        {
            
        }

        //overloaded constructor, takes an id as a parameter and fills the object's properties with the appropriate data
        public Table(int id)
        {
            //use private method to get the datatable for the specified table
            DataTable dt = se256_Dobachesky.Table.GetTable(id);

            //if a record was found with that id, set the properties of this class
            if (dt.Rows.Count > 0)
            {
                this.tbl_id = Convert.ToInt32(dt.Rows[0]["tbl_id"].ToString());
                this.sect_id = Convert.ToInt32(dt.Rows[0]["sect_id"].ToString());
                this.tbl_name = dt.Rows[0]["tbl_name"].ToString();
                this.tbl_desc = dt.Rows[0]["tbl_desc"].ToString();
                this.tbl_seat_cnt = Convert.ToInt32(dt.Rows[0]["tbl_seat_cnt"].ToString());
                this.tbl_active = Convert.ToBoolean(dt.Rows[0]["tbl_active"].ToString());
            }

        }
        #endregion

        #region Properties
        public int tbl_id { get; set; }
        public int sect_id { get; set; }
        public string tbl_name { get; set; }
        public string tbl_desc { get; set; }
        public int tbl_seat_cnt { get; set; }
        public bool tbl_active { get; set; }
        #endregion

        #region Methods
        private static DataTable GetTable(int id)
        {
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("tables_getById", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters to stored procedure
            SqlParameter pTblId = new SqlParameter("@tbl_id", SqlDbType.Int);
            pTblId.Value = id;
            cmd.Parameters.Add(pTblId);

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

        public static bool UpdateTable(se256_Dobachesky.Table aTable)
        {
            //start out with the boolean value at false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("tables_update", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //add the parameters to be used in the update method
            cmd.Parameters.Add("@tbl_id", SqlDbType.Int).Value = aTable.tbl_id;
            cmd.Parameters.Add("@sect_id", SqlDbType.Int).Value = aTable.sect_id;
            cmd.Parameters.Add("@tbl_name", SqlDbType.VarChar).Value = aTable.tbl_name;
            cmd.Parameters.Add("@tbl_desc", SqlDbType.VarChar).Value = aTable.tbl_desc;
            cmd.Parameters.Add("@tbl_seat_cnt", SqlDbType.Int).Value = aTable.tbl_seat_cnt;
            cmd.Parameters.Add("@tbl_active", SqlDbType.Bit).Value = aTable.tbl_active;

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

        public static bool InsertTable(se256_Dobachesky.Table aTable)
        {
            //start out with the boolean equal to false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("tables_insert", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //fill the parameters of the stored procedure
            cmd.Parameters.Add("@sect_id", SqlDbType.Int).Value = aTable.sect_id;
            cmd.Parameters.Add("@tbl_name", SqlDbType.VarChar).Value = aTable.tbl_name;
            cmd.Parameters.Add("@tbl_desc", SqlDbType.VarChar).Value = aTable.tbl_desc;
            cmd.Parameters.Add("@tbl_seat_cnt", SqlDbType.Int).Value = aTable.tbl_seat_cnt;
            cmd.Parameters.Add("@tbl_active", SqlDbType.Bit).Value = aTable.tbl_active;

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