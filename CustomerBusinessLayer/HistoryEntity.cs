using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
    public class HistoryEntity
    {        
        public int? CustomerId { get; set; }
        
        public float? TravelerCount { get; set; }
        
        public int? PackageId { get; set; }

        public string PackageName { get; set; }
                
        public decimal BasePrice { get; set; }

        public decimal AgencyCom { get; set; }

        public decimal Total { get; set; }
    }
}
