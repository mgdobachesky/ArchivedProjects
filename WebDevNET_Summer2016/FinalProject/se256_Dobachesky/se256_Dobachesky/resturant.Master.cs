using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace se256_Dobachesky
{
    public partial class resturant : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.IsAuthenticated)
            {
                //if user is logged in hide login button
                lbtnLogin.Visible = false;
                lbtnSignUp.Visible = false;
                //likewise, display the logout button
                lbtnLogout.Visible = true;
                //make a personalized message for the user to see on the site and grab the cookie
                if(Session["fullname"] != null)
                {
                    lblGreeting.Text = String.Concat("<h4>Welcome ", Session["fullname"].ToString(), "!</h4>");
                }
            }
            else
            {
                //if the user is not logged in then show the login button
                lbtnLogin.Visible = true;
                lbtnSignUp.Visible = true;
                //likewise, hide the logout button
                lbtnLogout.Visible = false;
                //create generic greeting for any casual user
                lblGreeting.Text = "<h4>Welcome to Vegetable City!</h4>";
            }
           
        }
        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sign-In");
        }

        protected void lbtnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sign-Up");
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            //logs user off from cookie authentication (built in .NET security system)
            FormsAuthentication.SignOut();
            //set the name session variable to be null
            Session["fullname"] = null;
            Session["user_id"] = null;
            //redirect user to home page
            Response.Redirect("/Home");
        }
    }
}