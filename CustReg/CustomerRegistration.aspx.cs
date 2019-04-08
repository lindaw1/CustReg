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
        int? CustId=null;
        Customer loggedinCust;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustId"] != null)
            {
                CustId = Convert.ToInt32(Session["CustId"]);
                loggedinCust = GenericDB.GenericRead<Customer>("Customers", 1, CustId)[0];
            }

                //Bind list boxes here after lunch
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

                txtCountry.SelectedIndex = 30;
                if (Session["CustId"] != null)
                {

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
            ErrPostal.Visible = false;
            ErrUserId.Visible = false;
            ErrHome.Visible = false;
            ErrBus.Visible = false;
            List<LoginInfo> LogCheck = CustomerDB.GetLoginList();

            //Postal REGEX
            Regex rgx = new Regex(@"[ABCEGHJKLMNPRSTVXY][0123456789][ABCEGHJKLMNPRSTVWXYZ][\s][0123456789][ABCEGHJKLMNPRSTVWXYZ][0123456789]");
            //Canadian postal codes can't contain the letters D, F, I, O, Q, or U, and cannot start with W or Z
            Match match = rgx.Match(txtPostalCode.Text);

            //Phone REGEX
            Regex phoneRgx = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            Match Homematch = phoneRgx.Match(txtHomePhone.Text);
            Match Busmatch = phoneRgx.Match(txtBusPhone.Text);
            
            Customer customer = new Customer();
            customer.CustFirstName = txtFirstName.Text;
            customer.CustLastName = txtLastName.Text;
            customer.CustEmail = txtEmail.Text; // optional
            customer.CustHomePhone = txtHomePhone.Text;//optional
            customer.CustBusPhone = txtBusPhone.Text;//optional
            customer.CustCountry = txtCountry.SelectedItem.Text;//future dropbox,for now textbox string
            customer.CustProv = txtProvince.SelectedValue;//dropbox for canadien provinces
            customer.CustCity = txtCity.Text;
            customer.CustAddress = txtAddress.Text;
            customer.CustPostal = txtPostalCode.Text;//REQUIRES CANADIEN REGEX
            customer.Password = txtPassword.Text;
            customer.UserId = txtUserId.Text;
            customer.AgentId = 1;
            bool regexCheck = false;

            foreach (LoginInfo log in LogCheck)
            {
                if(log.UserId == txtUserId.Text)
                {
                    ErrUserId.Visible = true;
                }
            }









            if (Homematch.Success)
            {
                if (Busmatch.Success)
                {
                    if (match.Success)
                    {
                        regexCheck = true;
                    }
                    else
                    {
                        ErrPostal.Visible = true;
                    }
                }
                else
                {
                    ErrBus.Visible = true;
                }
            }
            
            else
            {
                ErrHome.Visible = true;
            }
            if(ErrUserId.Visible == false)
            {

            
            if(regexCheck == true)
            {
                if (CustId == null)
                {

                    CustomerDB customerdb = new CustomerDB();
                    customerdb.SaveCustomer(customer);
                    Response.Redirect("Default");
                }
                else
                {
                    customer.CustomerId = loggedinCust.CustomerId;
                        int[] checkId= { 14 };
                    GenericDB.GenericUpdate<Customer>("Customers",loggedinCust,customer,null,null,checkId);
                }

            }
            }


        }
    }
}