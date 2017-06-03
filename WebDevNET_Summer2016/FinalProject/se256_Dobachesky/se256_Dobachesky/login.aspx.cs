using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using System.Web.Security;


namespace se256_Dobachesky
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //the following code is used to hide a page is a user is not logged in
            //it has been placed here for reference only
            /*
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            */

        }

        protected void lbtnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forgot-Password");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //declare datatable for the User class login method to return to
            DataTable dt = new DataTable();
            //try to validate user credentials
            if(!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                //call the login method of the Users class with appropriate string parameters
                dt = se256_Dobachesky.User.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            }
            else
            {
                lblMessage.Text = "Please enter both a username and password";
                return;
            }

            //check to be sure the datatable got at least one row
            if(dt.Rows.Count > 0)
            {
                //use .NET security system to set user_id in a client-side cookie
                FormsAuthenticationTicket authTicket =
                    new FormsAuthenticationTicket(
                        1,
                        dt.Rows[0]["user_id"].ToString(),
                        DateTime.Now,
                        DateTime.Now.AddMinutes(480),
                        false,
                        "Admin");

                //hash cookies for security reasons
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie httpCookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName, encTicket);
                //add cookie to response
                Response.Cookies.Add(httpCookie);

                //set the username to a client-side cookie for later user
                Session["fullname"] = dt.Rows[0]["fullname"].ToString();
                Session["user_id"] = dt.Rows[0]["user_id"].ToString();

                //redirect the browser to the home page
                Response.Redirect("Home");
            }
            else
            {
                //if login fails then display an error message
                lblMessage.Text = "Incorrect username or password";
            }

        }
    }
}