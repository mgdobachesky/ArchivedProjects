using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace se256_Dobachesky
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //initialize the integer that will hold the route data value
            int userID;

            //if the routedata value is not null then set the integer above to it
            if(RouteData.Values["userID"] != null)
            {
                userID = Convert.ToInt32(RouteData.Values["userID"].ToString());
            }
            //if the routedata value is null then set the integer about to -1
            else
            {
                userID = -1;
            }

            //if this is not a post back populate dropdown lists and run the bind data function, passing in the routedata information
            if (!IsPostBack)
            {
                ddlState.Items.Insert(0, "Please choose state");
                BindData(userID);
            }
        }

        //function that sets the form to the information of the selected primary key
        private void BindData(int userID)
        {
            //if the class if doesn't equal -1, set the page up as an update
            if(userID != -1)
            {
                //make the button say update
                btnAddUpdate.Text = "Update";
                //instantiate a new class of the form type, passing in the routeData primary key
                se256_Dobachesky.User aUser = new se256_Dobachesky.User(userID);
                //if the data exists, fill the form with it's information
                if(aUser != null)
                {
                    txtEmail.Text = aUser.user_email;
                    txtFirstName.Text = aUser.user_first;
                    txtLastName.Text = aUser.user_last;
                    txtAddress1.Text = aUser.user_add1;
                    txtAddress2.Text = aUser.user_add2;
                    txtCity.Text = aUser.user_city;
                    ddlState.SelectedValue = aUser.state_id;
                    TxtZip.Text = aUser.user_zip;
                    txtPassword.Text = aUser.user_password;
                    txtPhone.Text = aUser.user_phone;
                    chkIsActive.Checked = aUser.user_active;
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
            se256_Dobachesky.User aUser;
            //if the routedata information exists, finish the class by passing in the primary key id
            if (RouteData.Values["userID"] != null)
            {
                //make a new user class using it's overloaded constructor
                aUser = new se256_Dobachesky.User(Convert.ToInt32(RouteData.Values["userID"].ToString()));
            }
            //if the routedata information does not exist, finish the class with a blank class
            else
            {
                aUser = new se256_Dobachesky.User();
            }

            //set the object's properties to be equal to the information on the form
            aUser.user_email = txtEmail.Text.Trim();
            aUser.user_first = txtFirstName.Text.Trim();
            aUser.user_last = txtLastName.Text.Trim();
            aUser.user_add1 = txtAddress1.Text.Trim();
            aUser.user_add2 = txtAddress2.Text.Trim();
            aUser.user_city = txtCity.Text.Trim();
            aUser.state_id = ddlState.SelectedValue.Trim();
            aUser.user_zip = TxtZip.Text.Trim();
            aUser.user_password = txtPassword.Text.Trim();
            aUser.user_phone = txtPhone.Text.Trim();
            aUser.user_active = Convert.ToBoolean(chkIsActive.Checked.ToString());

            //if the primary key exists go forward with the update
            if (aUser.user_id > 0)
            {
                //run the update method, and if it fails display an error message in a label
                if(se256_Dobachesky.User.UpdateUser(aUser))
                {
                    Response.Redirect("/Admin/Users");
                }
                else
                {
                    lblMessage.Text = "User update failed!";
                }
            }
            //if the primary key does not exist it is because the record does not exist yet, go forward with the add
            else
            {
                //run the insert method, and if it fails display an error message in a label
                if(se256_Dobachesky.User.InsertUser(aUser))
                {
                    Response.Redirect("/Admin/Users");
                }
                else
                {
                    lblMessage.Text = "User insert failed!";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect the user when cancel is clicked
            Response.Redirect("/Admin/Users");
        }
    }
}