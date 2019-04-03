using ClassDB;
using ClassLibrary;
using CustomerBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustReg
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect(""); //*************************************************************
            }
            int Id = Convert.ToInt32(Session["Id"]);

            List<Booking> allBookings = GenericDB.GenericRead<Booking>("Bookings");
            List<Package> allPackages = GenericDB.GenericRead<Package>("Packages");

            List<HistoryEntity> relatedBookings = null;
            foreach (Booking b in allBookings)
            {
                if (b.CustomerId == Id)
                {
                    HistoryEntity htry = new HistoryEntity();
                    htry.CustomerId = b.CustomerId;
                    htry.TravelerCount = b.TravelerCount;
                    htry.PackageId = b.PackageId;
                    relatedBookings.Add(htry);
                }                                   
            }

            foreach (HistoryEntity h in relatedBookings)
            {
                foreach (Package p in allPackages)
                {            
                    if (p.PackageID == h.PackageId)
                    {
                        h.PackageName = p.PackageName;
                        h.BasePrice = p.BasePrice;
                        h.AgencyCom = p.AgencyCom;
                        decimal tP = h.BasePrice + h.AgencyCom;
                        h.Total = Convert.ToDecimal(h.TravelerCount) * tP;
                    }
                }
            }
            grvHistory.DataSource = relatedBookings;

            grvHistory.Columns[0].Visible = false;            
            grvHistory.Columns[4].Visible = false;
            grvHistory.Columns[5].Visible = false;
            
            grvHistory.DataBind();
        }
    }
}