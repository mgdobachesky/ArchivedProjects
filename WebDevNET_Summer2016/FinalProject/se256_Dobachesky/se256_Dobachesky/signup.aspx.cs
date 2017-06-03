using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace se256_Dobachesky
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlState.Items.Insert(0, "Please choose state");
            }
        }

        protected void btnAddUpdate_Click(object sender, EventArgs e)
        {
            //instantiate a new user class
            se256_Dobachesky.User aUser;
            aUser = new se256_Dobachesky.User();

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
            aUser.user_active = Convert.ToBoolean(true.ToString());

            //run the insert method, and if it fails display an error message in a label
            if (se256_Dobachesky.User.InsertUser(aUser))
            {
                Response.Redirect("/Home");
            }
            else
            {
                lblMessage.Text = "Error signing up!";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect the user when cancel is clicked
            Response.Redirect("/Home");
        }
    }
}