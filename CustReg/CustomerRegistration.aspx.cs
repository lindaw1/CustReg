﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerBusinessLayer;
using CustomerDataLayer;
using System.Text.RegularExpressions;

namespace CustReg
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            ErrPostal.Visible = false;
            
            Regex rgx = new Regex(@"[ABCEGHJKLMNPRSTVXY][0123456789][ABCEGHJKLMNPRSTVWXYZ][\s][0123456789][ABCEGHJKLMNPRSTVWXYZ][0123456789]");
            //Canadian postal codes can't contain the letters D, F, I, O, Q, or U, and cannot start with W or Z
            Match match = rgx.Match(txtPostalCode.Text);
            

            //^\(? ([0 - 9]{ 3})\)?[-.●]? ([0 - 9]{3})[-.●]? ([0 - 9]{4})$
            

            Customer customer = new Customer();
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.Email = txtEmail.Text; // optional
            customer.HomePhone = txtHomePhone.Text;//optional
            customer.BusPhone = txtBusPhone.Text;//optional
            customer.Country = txtCountry.Text;//future dropbox,for now textbox string
            customer.Province = txtProvince.Text;//dropbox for canadien provinces
            customer.City = txtCity.Text;
            customer.Address = txtAddress.Text;
            customer.Postal = txtPostalCode.Text;//REQUIRES CANADIEN REGEX
            customer.Password = txtPassword.Text;
            customer.UserId = txtUserId.Text;
            customer.AgentId = 1;

            //CustomerManager customerManager = new CustomerManager();
            //customerManager.AddCustomer(customer);

            if (match.Success)
            {
                CustomerDB customerdb = new CustomerDB();
                customerdb.SaveCustomer(customer);
            }
            else
            {
                ErrPostal.Visible = true;
            }
        }


    }
}