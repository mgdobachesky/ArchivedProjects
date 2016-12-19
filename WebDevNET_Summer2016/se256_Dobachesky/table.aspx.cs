using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace se256_Dobachesky
{
    public partial class table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //initialize the integer that will hold the route data value
            int tableID;

            //if the routedata value is not null then set the integer above to it
            if (RouteData.Values["tableID"] != null)
            {
                tableID = Convert.ToInt32(RouteData.Values["tableID"].ToString());
            }
            //if the routedata value is null then set the integer about to -1
            else
            {
                tableID = -1;
            }

            //if this is not a post back populate dropdown lists and run the bind data function, passing in the routedata information
            if (!IsPostBack)
            {
                BindData(tableID);
                ddlSection.Items.Insert(0, "Please choose section");
            }
        }

        //function that sets the form to the information of the selected primary key
        private void BindData(int tableID)
        {
            //if the class if doesn't equal -1, set the page up as an update
            if (tableID != -1)
            {
                //make the button say update
                btnAddUpdate.Text = "Update";
                //instantiate a new class of the form type, passing in the routeData primary key
                se256_Dobachesky.Table aTable = new se256_Dobachesky.Table(tableID);
                //if the data exists, fill the form with it's information
                if (aTable != null)
                {
                    txtName.Text = aTable.tbl_name;
                    txtDesc.Text = aTable.tbl_desc;
                    ddlSection.SelectedValue = aTable.sect_id.ToString();
                    txtSeatCount.Text = aTable.tbl_seat_cnt.ToString();
                    chkIsActive.Checked = aTable.tbl_active;
                }
            }
            //if the class does equal -1, set the form up as an add
            else
            {
                btnAddUpdate.Text = "Add";
            }
        }

        protected void btnAddUpdate_Click(object sender, EventArgs e)
        {
            //instantiate a new class
            se256_Dobachesky.Table aTable;
            //if the routedata information exists, finish the class by passing in the primary key id
            if (RouteData.Values["tableID"] != null)
            {
                aTable = new se256_Dobachesky.Table(Convert.ToInt32(RouteData.Values["tableID"].ToString()));
            }
            //if the routedata information does not exist, finish the class with a blank class
            else
            {
                aTable = new se256_Dobachesky.Table();
            }

            //set the object's properties to be equal to the information on the form
            aTable.sect_id = Convert.ToInt32(ddlSection.SelectedValue.ToString());
            aTable.tbl_name = txtName.Text.Trim();
            aTable.tbl_desc = txtDesc.Text.Trim();
            aTable.tbl_seat_cnt = Convert.ToInt32(txtSeatCount.Text.Trim());
            aTable.tbl_active = Convert.ToBoolean(chkIsActive.Checked.ToString());

            //if the primary key exists go forward with the update
            if (aTable.tbl_id > 0)
            {
                //run the update method, and if it fails display an error message in a label
                if (se256_Dobachesky.Table.UpdateTable(aTable))
                {
                    Response.Redirect("/Admin/Tables");
                }
                else
                {
                    lblMessage.Text = "Table update failed!";
                }
            }
            //if the primary key does not exist it is because the record does not exist yet, go forward with the add
            else
            {
                //run the insert method, and if it fails display an error message in a label
                if (se256_Dobachesky.Table.InsertTable(aTable))
                {
                    Response.Redirect("/Admin/Tables");
                }
                else
                {
                    lblMessage.Text = "Table insert failed!";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect the user when cancel is clicked
            Response.Redirect("/Admin/Tables");
        }

    }
}