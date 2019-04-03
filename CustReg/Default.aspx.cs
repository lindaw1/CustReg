using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string Username = UserBox.Text;
            string Password = PassBox.Text;

            if(Username == "" || Password == "")
            {
                ErrLogin.Visible = true;
            }




        }
    }
}