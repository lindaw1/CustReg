using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerBusinessLayer;
using CustomerDataLayer;

namespace CustReg
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.Address = txtAddress.Text;
            customer.City = txtCity.Text;
            customer.Province = txtProvince.Text;
            customer.Postal = txtPostalCode.Text;
            customer.Country = txtCountry.Text;
            customer.HomePhone = txtHomePhone.Text;
            customer.BusPhone = txtBusPhone.Text;
            customer.Email = txtEmail.Text;
            customer.Password = txtPassword.Text;
            customer.UserId = txtUserId.Text;
            customer.AgentId = 1;

            //CustomerManager customerManager = new CustomerManager();
            //customerManager.AddCustomer(customer);

            CustomerDB customerdb = new CustomerDB();
            customerdb.SaveCustomer(customer);
        }


    }
}