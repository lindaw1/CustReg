using CustomerDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerBusinessLayer;

namespace CustReg
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Loginbtn_Click(object sender, EventArgs e)
        {
            ErrLogin.Visible = false;
            string Username = Userbox1.Text;
            string Password = Passbox1.Text;
            bool match = false;
           if(Username == "" || Password == "")
            {
                ErrLogin.Visible = true;
            }

            List<LoginInfo> loginList = new List<LoginInfo>();
             loginList =CustomerDB.GetLoginList();

            foreach(LoginInfo login in loginList)
            {
                if(Username == login.UserId)
                {
                    if(Password == login.Password)
                    {
                        match = true;
                        Session.Add("CustId", login.CustId);
                        Response.Redirect("History");
                    }
                }
            }
            if(match == false)
            {
                ErrLogin.Visible = true;
            }
            
        }

        protected void Createbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRegistration");
        }
    }
}