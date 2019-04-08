using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
    // an entity class to create history objects
    public class HistoryEntity
    {        
        // properties
        public int? CustomerId { get; set; }

        public int? BookingId { get; set; }
        
        public int? PackageId { get; set; }

        public string PackageName { get; set; }

        public float? TravelerCount { get; set; }

        public decimal BasePrice { get; set; }

        public decimal AgencyCom { get; set; }

        public decimal Total { get; set; }
    }
}
