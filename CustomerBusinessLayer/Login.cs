using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
   public class LoginInfo
    {

        public int CustId { get; set; }
        
        public string UserId { get; set; }
        
        public string Password { get; set; }

    }
}
