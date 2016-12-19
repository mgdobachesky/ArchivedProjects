using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace se256_Dobachesky
{
    public partial class reservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //the following code is used to hide a page is a user is not logged in
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            if(!IsPostBack)
            {
                ddlUsers.Items.Insert(0, "Please choose user");
                ddlGuestCount.Items.Insert(0, "Please choose guest count");
            }

            ddlUsers.SelectedValue = Session["user_id"].ToString();
            ddlUsers.Enabled = false;

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //pass the datetime, email, and guest count to the CheckReservation method of the Reservation Class
            string checkReservation = se256_Dobachesky.Reservation.CheckReservation(txtResDate.Text.Trim().ToString(), txtResTime.Text.Trim().ToString(), Convert.ToInt32(ddlGuestCount.SelectedValue.Trim().ToString()));

            //set checkReservation to 0 if the method did not return anything
            if (checkReservation == "")
            {
                checkReservation = "0";
            }

            //go forward if the checkReservation method returned an available table
            if (Convert.ToInt32(checkReservation.ToString()) > 0)
            {
                //instantiate a new class for both reservations and guests
                se256_Dobachesky.Reservation aReservation = new se256_Dobachesky.Reservation();
                se256_Dobachesky.Guest aGuest = new se256_Dobachesky.Guest(txtEmail.Text.ToString());

                //set the object's properties to be equal to the information on the form
                aGuest.guest_email = txtEmail.Text.Trim().ToString();
                aGuest.guest_first = txtFirstName.Text.Trim().ToString();
                aGuest.guest_last = txtLastName.Text.Trim().ToString();
                aGuest.guest_phone = txtPhone.Text.Trim().ToString();
                aReservation.tbl_id = Convert.ToInt32(checkReservation.ToString());
                aReservation.user_id = Convert.ToInt32(ddlUsers.SelectedValue.Trim().ToString());
                aReservation.res_date = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(txtResDate.Text.Trim()));
                aReservation.res_time = String.Format("{0:HH:mm:ss}", Convert.ToDateTime(txtResTime.Text.Trim()));
                aReservation.res_guest_cnt = Convert.ToInt32(ddlGuestCount.SelectedValue.Trim());
                aReservation.res_spec_req = txtSpecReq.Text.Trim();

                //if the primary key exists go forward with the update
                if (aGuest.guest_id > 0)
                {
                    //run the update method, and if it fails display an error message in a label
                    if (se256_Dobachesky.Guest.UpdateGuest(aGuest))
                    {
                        aReservation.guest_id = Convert.ToInt32(aGuest.guest_id);
                        lblMessage.Text = "";
                    }
                    else
                    {
                        lblMessage.Text = "Error updating guest!";
                    }
                }
                //if the primary key does not exist it is because the record does not exist yet, go forward with the add
                else
                {
                    //run the insert method, and if it fails display an error message in a label
                    if (se256_Dobachesky.Guest.InsertGuest(aGuest))
                    {
                        se256_Dobachesky.Guest aGuest2 = new se256_Dobachesky.Guest(txtEmail.Text.ToString());
                        aReservation.guest_id = Convert.ToInt32(aGuest2.guest_id);
                        lblMessage.Text = "";
                    }
                    else
                    {
                        lblMessage.Text = "Error adding guest!";
                    }
                }

                //run the update method, and if it fails display an error message in a label
                if (se256_Dobachesky.Reservation.InsertReservation(aReservation))
                {
                    lblMessage.Text = "";
                    Response.Redirect("/Reservations");
                }
                else
                {
                    lblMessage.Text = "Error adding reservation!";
                }
            }
            else
            {
                lblMessage.Text = "All qualified tables are filled for this time slot!";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //redirect the user when cancel is clicked
            Response.Redirect("/Reservations");
        }
    }
}