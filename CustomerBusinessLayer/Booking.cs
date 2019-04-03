using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBusinessLayer
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateTime? BookingDate { get; set; }

        public string BookingNo { get; set; }

        public float? TravelerCount { get; set; }

        public int? CustomerId { get; set; }

        public char TripTypeId { get; set; }

        public int? PackageId { get; set; }
    }
}
