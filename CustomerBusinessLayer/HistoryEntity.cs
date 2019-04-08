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
        
        [DisplayName("Package ID")]
        public int? PackageId { get; set; }

        [DisplayName("Package Name")]
        public string PackageName { get; set; }

        [DisplayName("# of Travelers")]
        public float? TravelerCount { get; set; }

        public decimal BasePrice { get; set; }

        public decimal AgencyCom { get; set; }

        [DisplayName("Total Cost")]
        public decimal Total { get; set; }
    }
}
