﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
    //coded mostly by Linda and Matthew
    public class Customer
    {

        public int? CustomerId { get; set; } //can't be null

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

        
        public string  CustBusPhone { get; set; }

        [Required]
        public string CustEmail { get; set; }
    
        public int? AgentId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserId { get; set; }

    
    }
}
