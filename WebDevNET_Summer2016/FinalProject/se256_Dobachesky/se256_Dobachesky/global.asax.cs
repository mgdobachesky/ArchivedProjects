using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace se256_Dobachesky
{
    public class global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            registerRoutes(RouteTable.Routes);
        }

        public static void registerRoutes(RouteCollection routes)
        {
            //ignore WebResource.axd file
            routes.Ignore("{resource}.axd/{*pathInfo}");
            //map static pages
            routes.MapPageRoute("default", "Home", "~/default.aspx");
            routes.MapPageRoute("breakfastMenu", "Breakfast-Menu", "~/breakfastMenu.aspx");
            routes.MapPageRoute("lunchMenu", "Lunch-Menu", "~/lunchMenu.aspx");
            routes.MapPageRoute("dinnerMenu", "Dinner-Menu", "~/dinnerMenu.aspx");
            routes.MapPageRoute("reservations", "Reservations", "~/reservations.aspx");
            routes.MapPageRoute("reservation", "Reservation", "~/reservation.aspx");
            routes.MapPageRoute("directions", "Directions", "~/directions.aspx");
            routes.MapPageRoute("about", "About", "~/about.aspx");
            routes.MapPageRoute("contact", "Contact", "~/contact.aspx");
            routes.MapPageRoute("signIn", "Sign-In", "~/login.aspx");
            routes.MapPageRoute("signUp", "Sign-Up", "~/signup.aspx");
            routes.MapPageRoute("forgotPassword", "Forgot-Password", "~/forgotPassword.aspx");
            routes.MapPageRoute("adminDefault", "Admin", "~/adminDefault.aspx");
            routes.MapPageRoute("user", "Admin/User", "~/user.aspx");
            routes.MapPageRoute("users", "Admin/Users", "~/users.aspx");
            routes.MapPageRoute("menuItems", "Admin/Menu-Items", "~/menuItems.aspx");
            routes.MapPageRoute("menuItem", "Admin/Menu-Item", "~/menuItem.aspx");
            routes.MapPageRoute("sections", "Admin/Sections", "~/sections.aspx");
            routes.MapPageRoute("section", "Admin/Section", "~/section.aspx");
            routes.MapPageRoute("tables", "Admin/Tables", "~/tables.aspx");
            routes.MapPageRoute("table", "Admin/Table", "~/table.aspx");
            routes.MapPageRoute("resManagement", "Admin/Res-Management", "~/resMgmt.aspx");

            //map dynamic pages
            routes.MapPageRoute("menuItemsId", "Admin/Menu-Item/{menuItemID}", "~/menuItem.aspx", false, new RouteValueDictionary { { "menuItemID", "-1" } });
            routes.MapPageRoute("reservationsId", "Reservation/{resID}", "~/reservation.aspx", false, new RouteValueDictionary { { "resID", "-1" } });
            routes.MapPageRoute("resManagementId", "Admin/Reservation/{resID}", "~/reservation.aspx", false, new RouteValueDictionary { { "resID", "-1" } });
            routes.MapPageRoute("sectionsId", "Admin/Section/{sectionID}", "~/section.aspx", false, new RouteValueDictionary { { "sectionID", "-1" } });
            routes.MapPageRoute("tablesId", "Admin/Table/{tableID}", "~/table.aspx", false, new RouteValueDictionary { { "tableID", "-1" } });
            routes.MapPageRoute("usersId", "Admin/User/{userID}", "~/user.aspx", false, new RouteValueDictionary { { "usersID", "-1" } });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}