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
        public int CustomerId { get; set; }

        [Required]
        public string CustFirstName { get; set; }

        [Required]
        public string CustLastName { get; set; }

        [Required]
        public string CustAddress { get; set; }

        [Required]
        public string CustCity { get; set; }

        [Required]
        public string CustProv { get; set; }

        [Required, RegularExpression(@"^[A - Z]\d[A - Z] \d[A - Z]\d$")]
        public string CustPostal { get; set; }

        [Required]
        public string CustCountry { get; set; }

        [Required]
        public string CustHomePhone { get; set; }

        [Required]
        public string  CustBusPhone { get; set; }

        [Required]
        public string CustEmail { get; set; }

        
        public int AgentId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserId { get; set; }

    
    }
}
