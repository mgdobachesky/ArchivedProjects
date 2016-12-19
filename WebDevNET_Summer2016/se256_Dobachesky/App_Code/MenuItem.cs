using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace se256_Dobachesky
{
    public class MenuItem
    {
        #region Constructors
        //default constructor, just allows access to properties and methods
        public MenuItem()
        {

        }

        //overloaded constructor, takes an id as a parameter and fills the object's properties with the appropriate data
        public MenuItem(int id)
        {
            //use private method to get the datatable for the specified item
            DataTable dt = se256_Dobachesky.MenuItem.GetItem(id);

            //if a record was found with that id, set the properties of this class
            if (dt.Rows.Count > 0)
            {
                this.item_id = Convert.ToInt32(dt.Rows[0]["item_id"].ToString());
                this.menu_id = Convert.ToInt32(dt.Rows[0]["menu_id"].ToString());
                this.cat_id = Convert.ToInt32(dt.Rows[0]["cat_id"].ToString());
                this.item_name = dt.Rows[0]["item_name"].ToString();
                this.item_desc = dt.Rows[0]["item_desc"].ToString();
                this.item_allergens = dt.Rows[0]["item_allergens"].ToString();
                this.item_price = Convert.ToDecimal(dt.Rows[0]["item_price"].ToString());
                this.item_gluten_free = Convert.ToBoolean(dt.Rows[0]["item_gluten_free"].ToString());
                this.item_active = Convert.ToBoolean(dt.Rows[0]["item_active"].ToString());
            }

        }
        #endregion

        #region Properties
        public int item_id { get; set; }
        public int menu_id { get; set; }
        public int cat_id { get; set; }
        public string item_name { get; set; }
        public string item_desc { get; set; }
        public string item_allergens { get; set; }
        public decimal item_price { get; set; }
        public bool item_gluten_free { get; set; }
        public bool item_active { get; set; }
        #endregion

        #region Methods
        private static DataTable GetItem(int id)
        {
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("menu_items_getById", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters to stored procedure
            SqlParameter pItemId = new SqlParameter("@item_id", SqlDbType.Int);
            pItemId.Value = id;
            cmd.Parameters.Add(pItemId);

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

        public static bool UpdateItem(se256_Dobachesky.MenuItem aItem)
        {
            //start out with the boolean value at false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("menu_items_update", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //add the parameters to be used in the update method
            cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = aItem.item_id;
            cmd.Parameters.Add("@menu_id", SqlDbType.Int).Value = aItem.menu_id;
            cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = aItem.cat_id;
            cmd.Parameters.Add("@item_name", SqlDbType.VarChar).Value = aItem.item_name;
            cmd.Parameters.Add("@item_desc", SqlDbType.VarChar).Value = aItem.item_desc;
            cmd.Parameters.Add("@item_allergens", SqlDbType.VarChar).Value = aItem.item_allergens;
            cmd.Parameters.Add("@item_price", SqlDbType.Decimal).Value = aItem.item_price;
            cmd.Parameters.Add("@item_gluten_free", SqlDbType.Bit).Value = aItem.item_gluten_free;
            cmd.Parameters.Add("@item_active", SqlDbType.Bit).Value = aItem.item_active;

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

        public static bool InsertItem(se256_Dobachesky.MenuItem aItem)
        {
            //start out with the boolean equal to false
            bool blnSuccess = false;
            //create sql connection object that gets connection string from web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_CS"].ConnectionString);
            //create sql command as stored procedure
            SqlCommand cmd = new SqlCommand("menu_items_insert", conn);
            //set the command as a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //fill the parameters of the stored procedure
            cmd.Parameters.Add("@menu_id", SqlDbType.Int).Value = aItem.menu_id;
            cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = aItem.cat_id;
            cmd.Parameters.Add("@item_name", SqlDbType.VarChar).Value = aItem.item_name;
            cmd.Parameters.Add("@item_desc", SqlDbType.VarChar).Value = aItem.item_desc;
            cmd.Parameters.Add("@item_allergens", SqlDbType.VarChar).Value = aItem.item_allergens;
            cmd.Parameters.Add("@item_price", SqlDbType.Decimal).Value = aItem.item_price;
            cmd.Parameters.Add("@item_gluten_free", SqlDbType.Bit).Value = aItem.item_gluten_free;
            cmd.Parameters.Add("@item_active", SqlDbType.Bit).Value = aItem.item_active;

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