using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace se256_Dobachesky
{
    public class Section
    {
        #region Constructors
        //default constructor, just allows access to properties and methods
        public Section()
        {
            
        }

        //overloaded constructor, takes an id as a parameter and fills the object's properties with the appropriate data
        public Section(int id)
        {
            //use private method to get the datatable for the specified section
            DataTable dt = se256_Dobachesky.Section.GetSection(id);

            //if a record was found with that id, set the properties of this class
            if (dt.Rows.Count > 0)
            {
                this.sect_id = Convert.ToInt32(dt.Rows[0]["sect_id"].ToString());
                this.sect_name = dt.Rows[0]["sect_name"].ToString();
                this.sect_desc = dt.Rows[0]["sect_desc"].ToString();
                this.sect_active = Convert.ToBoolean(dt.Rows[0]["sect_active"].ToString());
            }

        }
        #endregion

        #region Properties
        public int sect_id { get; set; }
        public string sect_name { get; set; }
        public string sect_desc { get; set; }
        public bool sect_active { get; set; }
        #endregion

        #region Methods
        private static DataTable GetSection(int id)
        {
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("sections_getById", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters to stored procedure
            SqlParameter pSectId = new SqlParameter("@sect_id", SqlDbType.Int);
            pSectId.Value = id;
            cmd.Parameters.Add(pSectId);

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

        public static bool UpdateSection(se256_Dobachesky.Section aSection)
        {
            //start out with the boolean value at false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("sections_update", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //add the parameters to be used in the update method
            cmd.Parameters.Add("@sect_id", SqlDbType.Int).Value = aSection.sect_id;
            cmd.Parameters.Add("@sect_name", SqlDbType.VarChar).Value = aSection.sect_name;
            cmd.Parameters.Add("@sect_desc", SqlDbType.VarChar).Value = aSection.sect_desc;
            cmd.Parameters.Add("@sect_active", SqlDbType.Bit).Value = aSection.sect_active;

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

        public static bool InsertSection(se256_Dobachesky.Section aSection)
        {
            //start out with the boolean equal to false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("sections_insert", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //fill the parameters of the stored procedure
            cmd.Parameters.Add("@sect_name", SqlDbType.VarChar).Value = aSection.sect_name;
            cmd.Parameters.Add("@sect_desc", SqlDbType.VarChar).Value = aSection.sect_desc;
            cmd.Parameters.Add("@sect_active", SqlDbType.Bit).Value = aSection.sect_active;

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