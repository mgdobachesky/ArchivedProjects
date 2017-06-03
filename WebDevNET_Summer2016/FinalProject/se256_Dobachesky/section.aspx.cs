using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace se256_Dobachesky
{
    public partial class section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //initialize the integer that will hold the route data value
            int sectionID;

            //if the routedata value is not null then set the integer above to it
            if (RouteData.Values["sectionID"] != null)
            {
                sectionID = Convert.ToInt32(RouteData.Values["sectionID"].ToString());
            }
            //if the routedata value is null then set the integer about to -1
            else
            {
                sectionID = -1;
            }

            //if this is not a post back populate dropdown lists and run the bind data function, passing in the routedata information
            if (!IsPostBack)
            {
                BindData(sectionID);
            }
        }

        //function that sets the form to the information of the selected primary key
        private void BindData(int sectionID)
        {
            //if the class if doesn't equal -1, set the page up as an update
            if (sectionID != -1)
            {
                //make the button say update
                btnAddUpdate.Text = "Update";
                //instantiate a new class of the form type, passing in the routeData primary 
                se256_Dobachesky.Section aSection = new se256_Dobachesky.Section(sectionID);
                //if the data exists, fill the form with it's information
                if (aSection != null)
                {
                    txtName.Text = aSection.sect_name;
                    txtDesc.Text = aSection.sect_desc;
                    chkIsActive.Checked = aSection.sect_active;
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
            se256_Dobachesky.Section aSection;
            //if the routedata information exists, finish the class by passing in the primary key id
            if (RouteData.Values["sectionID"] != null)
            {
                aSection = new se256_Dobachesky.Section(Convert.ToInt32(RouteData.Values["sectionID"].ToString()));
            }
            //if the routedata information does not exist, finish the class with a blank class
            else
            {
                aSection = new se256_Dobachesky.Section();
            }

            //set the object's properties to be equal to the information on the form
            aSection.sect_name = txtName.Text.Trim();
            aSection.sect_desc = txtDesc.Text.Trim();
            aSection.sect_active = Convert.ToBoolean(chkIsActive.Checked.ToString());

            //if the primary key exists go forward with the update
            if (aSection.sect_id > 0)
            {
                //run the update method, and if it fails display an error message in a label
                if (se256_Dobachesky.Section.UpdateSection(aSection))
                {
                    Response.Redirect("/Admin/Sections");
                }
                else
                {
                    lblMessage.Text = "Section update failed!";
                }
            }
            //if the primary key does not exist it is because the record does not exist yet, go forward with the add
            else
            {
                //run the insert method, and if it fails display an error message in a label
                if (se256_Dobachesky.Section.InsertSection(aSection))
                {
                    Response.Redirect("/Admin/Sections");
                }
                else
                {
                    lblMessage.Text = "Section insert failed!";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect the user when cancel is clicked
            Response.Redirect("/Admin/Sections");
        }

    }
}