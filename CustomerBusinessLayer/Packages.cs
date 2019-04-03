using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //Matthew MacMAster
    //2019-03-27
   public class Package
    {
        [Required]
       public int PackageID { get; set; }
        [Required]
       public string PkgName { get; set; }

      public  DateTime? PkgStartDate { get; set; }

       public DateTime? PkgEndDate { get; set; }

       public string PkgDesc { get; set; }

      public  decimal PkgBasePrice { get; set; }

       public decimal PkgAgencyCommission { get; set; }

    }
}
