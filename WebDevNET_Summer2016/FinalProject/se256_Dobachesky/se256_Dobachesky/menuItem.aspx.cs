using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace se256_Dobachesky
{
    public partial class menuItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //initialize the integer that will hold the route data value
            int menuItemID;

            //if the routedata value is not null then set the integer above to it
            if (RouteData.Values["menuItemID"] != null)
            {
                menuItemID = Convert.ToInt32(RouteData.Values["menuItemID"].ToString());
            }
            //if the routedata value is null then set the integer about to -1
            else
            {
                menuItemID = -1;
            }

            //if this is not a post back populate dropdown lists and run the bind data function, passing in the routedata information
            if (!IsPostBack)
            {
                ddlMenu.Items.Insert(0, "Please choose menu");
                ddlCategory.Items.Insert(0, "Please choose category");
                BindData(menuItemID);
            }
        }

        //function that sets the form to the information of the selected primary key
        private void BindData(int menuItemID)
        {
            //if the class if doesn't equal -1, set the page up as an update
            if (menuItemID != -1)
            {
                //make the button say 
                btnAddUpdate.Text = "Update";
                //instantiate a new class of the form type, passing in the routeData primary 
                se256_Dobachesky.MenuItem aItem = new se256_Dobachesky.MenuItem(menuItemID);
                //if the data exists, fill the form with it's information
                if (aItem != null)
                {
                    txtName.Text = aItem.item_name;
                    txtDescription.Text = aItem.item_desc;
                    txtAllergens.Text = aItem.item_allergens;
                    txtPrice.Text = aItem.item_price.ToString();
                    ddlCategory.SelectedValue = aItem.cat_id.ToString();
                    ddlMenu.SelectedValue = aItem.menu_id.ToString();
                    chkGlutenFree.Checked = aItem.item_gluten_free;
                    chkIsActive.Checked = aItem.item_active;
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
            se256_Dobachesky.MenuItem aMenuItem;
            //if the routedata information exists, finish the class by passing in the primary key id
            if (RouteData.Values["menuItemId"] != null)
            {
                aMenuItem = new se256_Dobachesky.MenuItem(Convert.ToInt32(RouteData.Values["menuItemId"].ToString()));
            }
            //if the routedata information does not exist, finish the class with a blank class
            else
            {
                aMenuItem = new se256_Dobachesky.MenuItem();
            }

            //set the object's properties to be equal to the information on the form
            aMenuItem.menu_id = Convert.ToInt32(ddlMenu.SelectedValue.Trim());
            aMenuItem.cat_id = Convert.ToInt32(ddlCategory.SelectedValue.Trim());
            aMenuItem.item_name = txtName.Text.Trim();
            aMenuItem.item_desc = txtDescription.Text.Trim();
            aMenuItem.item_allergens = txtAllergens.Text.Trim();
            aMenuItem.item_price = Convert.ToDecimal(txtPrice.Text.Trim().ToString());
            aMenuItem.item_gluten_free = Convert.ToBoolean(chkGlutenFree.Checked.ToString());
            aMenuItem.item_active = Convert.ToBoolean(chkIsActive.Checked.ToString());

            //if the primary key exists go forward with the update
            if (aMenuItem.item_id > 0)
            {
                //run the update method, and if it fails display an error message in a label
                if (se256_Dobachesky.MenuItem.UpdateItem(aMenuItem))
                {
                    Response.Redirect("/Admin/Menu-Items");
                }
                else
                {
                    lblMessage.Text = "Menu item update failed!";
                }
            }
            //if the primary key does not exist it is because the record does not exist yet, go forward with the add
            else
            {
                //run the insert method, and if it fails display an error message in a label
                if (se256_Dobachesky.MenuItem.InsertItem(aMenuItem))
                {
                    Response.Redirect("/Admin/Menu-Items");
                }
                else
                {
                    lblMessage.Text = "Menu item insert failed!";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect the user when cancel is clicked
            Response.Redirect("/Admin/Menu-Items");
        }

    }
}