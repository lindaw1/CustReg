using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerBusinessLayer;
using CustomerDataLayer;
using System.Text.RegularExpressions;
using ClassDB;

namespace CustReg
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        int? CustId = null;
        Customer loggedinCust;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustId"] != null)
            {
                CustId = Convert.ToInt32(Session["CustId"]);
                loggedinCust = GenericDB.GenericRead<Customer>("Customers", 1, CustId)[0];
            }

            //Bind list boxes --Matthew
            if (!IsPostBack)
            {
                txtCountry.DataSource = Country_ProvDB.GetCountries();
                txtCountry.DataTextField = "CountryName";
                txtCountry.DataValueField = "CountryName";
                txtCountry.DataBind();

                txtProvince.DataSource = Country_ProvDB.GetProvinces();
                txtProvince.DataTextField = "ProvName";
                txtProvince.DataValueField = "Initial";
                txtProvince.DataBind();
                // Load DropDownList here

                //default country is Canada
                txtCountry.SelectedIndex = 30;

                if (Session["CustId"] != null)
                {
                    lblGreeting.Text = "Modify Account"; //--linda--change greeting depending if modifying or creating

                    txtFirstName.Text = loggedinCust.CustFirstName;
                    txtLastName.Text = loggedinCust.CustLastName;
                    txtAddress.Text = loggedinCust.CustAddress;
                    txtBusPhone.Text = loggedinCust.CustBusPhone;
                    txtCity.Text = loggedinCust.CustCity;
                    txtEmail.Text = loggedinCust.CustEmail;
                    txtHomePhone.Text = loggedinCust.CustHomePhone;
                    txtProvince.SelectedValue = loggedinCust.CustProv;
                    txtPostalCode.Text = loggedinCust.CustPostal;
                    txtUserId.Text = loggedinCust.UserId;
                    btnRegister.Text = "Save";
                    txtCountry.SelectedValue = loggedinCust.CustCountry;
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            ErrUserId.Visible = false;

            //checks to see if user id is already in use.--Matthew
            List<LoginInfo> LogCheck = CustomerDB.GetLoginList();
            
            //creates new customer---Matthew & Linda
            Customer customer = new Customer();
            customer.CustFirstName = txtFirstName.Text;
            customer.CustLastName = txtLastName.Text;
            customer.CustEmail = txtEmail.Text; // optional for assignment, but "Not Null" in db
            customer.CustHomePhone = txtHomePhone.Text;//optional for assignment, but "Not Null" in db
            customer.CustBusPhone = txtBusPhone.Text;//optional for assignment, but "Not Null" in db
            customer.CustCountry = txtCountry.SelectedItem.Text;//dropbox
            customer.CustProv = txtProvince.SelectedValue;//dropbox for canadien provinces
            customer.CustCity = txtCity.Text;
            customer.CustAddress = txtAddress.Text;
            customer.CustPostal = txtPostalCode.Text;// REGEX in aspx
            customer.Password = txtPassword.Text;
            customer.UserId = txtUserId.Text;
            customer.AgentId = 1;  // this value gets changed to Null when it loads.

            foreach (LoginInfo log in LogCheck)
            {
                if (log.UserId == txtUserId.Text)
                {
                    ErrUserId.Visible = true;
                    break;  //--linda--stops code,  once it finds a match
                }
            }

            if (ErrUserId.Visible == false)
            {
                if (CustId == null)
                {
                    //add new
                    CustomerDB customerdb = new CustomerDB();
                    customerdb.SaveCustomer(customer);
                    Response.Redirect("Default");
                }
                else
                {
                    //update
                    customer.CustomerId = loggedinCust.CustomerId;
                    int[] checkId = { 13 };//userId, let Generic Update method check userID duplication while updating.
                    GenericDB.GenericUpdate<Customer>("Customers", loggedinCust, customer, null, null, checkId);
                }
            }
        }
    }
}