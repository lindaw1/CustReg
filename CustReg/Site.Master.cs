using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustReg
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CustId"] == null)
            {
                btnLogin.Text= "Login";
            }
            else
            {
                btnLogin.Text = "LogOut";
            }
            

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["CustId"] == null)
            {
               Response.Redirect(@"~\Default.aspx");
            }
            else
            {
                Session.Clear();
                Response.Redirect(@"~\Default.aspx");
            }
        }
    }
}