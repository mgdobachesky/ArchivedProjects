using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace se256_Dobachesky
{
    public partial class reservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             //initialize the integer that will hold the route data value
             int resID;

             //if the routedata value is not null then set the integer above to it
             if (RouteData.Values["resID"] != null)
             {
                 resID = Convert.ToInt32(RouteData.Values["resID"].ToString());
             }
             //if the routedata value is null then set the integer about to -1
             else
             {
                 resID = -1;
             }

             //if this is not a post back populate dropdown lists and run the bind data function, passing in the routedata information
             if (!IsPostBack)
             {
                 ddlTables.Items.Insert(0, "Please choose table");
                 ddlUsers.Items.Insert(0, "Please choose user");
                 ddlGuestCount.Items.Insert(0, "Please choose guest count");
                 BindData(resID);
             }
         }

         //function that sets the form to the information of the selected primary key
         private void BindData(int resID)
         {
             //if the class if doesn't equal -1, set the page up as an update
             if (resID != -1)
             {
                 //make the button say update
                 btnAddUpdate.Text = "Update";
                 //instantiate a new class of the form type, passing in the routeData primary key
                 se256_Dobachesky.Reservation aReservation = new se256_Dobachesky.Reservation(resID);
                
                //get the guest id of this reservation then instantiate an instance of the guest class via overloaded constructor with it
                int guest_id = aReservation.guest_id;
                se256_Dobachesky.Guest aGuest = new se256_Dobachesky.Guest(guest_id);

                 //if the data exists, fill the form with it's information
                 if (aReservation != null)
                 {
                    txtEmail.Text = aGuest.guest_email.ToString();
                    txtFirstName.Text = aGuest.guest_first.ToString();
                    txtLastName.Text = aGuest.guest_last.ToString();
                    txtPhone.Text = aGuest.guest_phone.ToString();
                     ddlTables.SelectedValue = aReservation.tbl_id.ToString();
                     ddlUsers.SelectedValue = aReservation.user_id.ToString();
                     txtResDate.Text = aReservation.res_date;
                     txtResTime.Text = aReservation.res_time;
                     ddlGuestCount.SelectedValue = aReservation.res_guest_cnt.ToString();
                     txtSpecReq.Text = aReservation.res_spec_req;
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
             //instantiate a new class for both reservations and guests
             se256_Dobachesky.Reservation aReservation;
            se256_Dobachesky.Guest aGuest;
             //if the routedata information exists, finish the classes by passing in the primary key ids
             if (RouteData.Values["resID"] != null)
             {
                 aReservation = new se256_Dobachesky.Reservation(Convert.ToInt32(RouteData.Values["resID"].ToString()));
                aGuest = new se256_Dobachesky.Guest(aReservation.guest_id);
             }
             //if the routedata information does not exist, finish the classes with a blank class
             else
             {
                 aReservation = new se256_Dobachesky.Reservation();
                aGuest = new se256_Dobachesky.Guest();
             }

            //set the object's properties to be equal to the information on the form
            aGuest.guest_email = txtEmail.Text.ToString();
            aGuest.guest_first = txtFirstName.Text.ToString();
            aGuest.guest_last = txtLastName.Text.ToString();
            aGuest.guest_phone = txtPhone.Text.ToString();
             aReservation.tbl_id = Convert.ToInt32(ddlTables.SelectedValue.Trim());
             aReservation.user_id = Convert.ToInt32(ddlUsers.SelectedValue.Trim().ToString());
             aReservation.res_date = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(txtResDate.Text.Trim()));
             aReservation.res_time = String.Format("{0:HH:mm:ss}", Convert.ToDateTime(txtResTime.Text.Trim()));
             aReservation.res_guest_cnt = Convert.ToInt32(ddlGuestCount.SelectedValue.Trim());
             aReservation.res_spec_req = txtSpecReq.Text.Trim();

             //if the primary key exists go forward with the update
             if (aReservation.res_id > 0)
             {
                 //run the update method, and if it fails display an error message in a label
                 if (se256_Dobachesky.Reservation.UpdateReservation(aReservation) && se256_Dobachesky.Guest.UpdateGuest(aGuest))
                 {
                     Response.Redirect("/Admin/Res-Management");
                 }
                 else
                 {
                     lblMessage.Text = "Reservation update failed!";
                 }
             }
             //if the primary key does not exist it is because the record does not exist yet, go forward with the add
             else
             {
                 //run the insert method, and if it fails display an error message in a label
                 if (se256_Dobachesky.Reservation.InsertReservation(aReservation) && se256_Dobachesky.Guest.InsertGuest(aGuest))
                 {
                     Response.Redirect("/Admin/Res-Management");
                 }
                 else
                 {
                     lblMessage.Text = "Reservation insert failed!";
                 }
             }
         }

         protected void btnCancel_Click(object sender, EventArgs e)
         {
             //redirect the user when cancel is clicked
             Response.Redirect("/Admin/Res-Management");
         }

     }
 }
 