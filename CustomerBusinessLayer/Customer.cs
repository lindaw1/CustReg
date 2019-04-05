using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
    public class Customer
    {
        public int CustId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required, RegularExpression(@"^[A - Z]\d[A - Z] \d[A - Z]\d$")]
        public string Postal { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string HomePhone { get; set; }

        [Required]
        public string  BusPhone { get; set; }

        [Required]
        public string Email { get; set; }

        
        public int AgentId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserId { get; set; }

    
    }
}
