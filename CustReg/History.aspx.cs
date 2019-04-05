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
           
            if (Session["CustId"] == null)
            {
                Response.Redirect(@"~\Default.aspx"); //*************************************************************
            }
            int CustId = Convert.ToInt32(Session["CustId"]);

            Customer loggedinCust = GenericDB.GenericRead<Customer>("Customers", 1, CustId)[0];
            lblCust.Text = "Booking History for: "+loggedinCust.CustFirstName + " " + loggedinCust.CustLastName;
            List<Booking> allBookings = GenericDB.GenericRead<Booking>("Bookings");
            List<Package> allPackages = GenericDB.GenericRead<Package>("Packages");

            List<HistoryEntity> relatedBookings = new List<HistoryEntity>();

            foreach (Booking b in allBookings)
            {
                if (b.CustomerId == CustId)
                {
                    HistoryEntity htry = new HistoryEntity();
                    htry.CustomerId = b.CustomerId;
                    htry.TravelerCount = b.TravelerCount;
                    htry.PackageId = b.PackageId;
                    htry.BookingId = b.BookingId;
                    relatedBookings.Add(htry);
                }                                   
            }

            foreach (HistoryEntity h in relatedBookings)
            {
                foreach (Package p in allPackages)
                {            
                    if (p.PackageID == h.PackageId)
                    {
                        h.PackageName = p.PkgName;
                        h.BasePrice = p.PkgBasePrice;
                        h.AgencyCom = p.PkgAgencyCommission;
                        decimal tP = h.BasePrice + h.AgencyCom;
                        h.Total = Convert.ToDecimal(h.TravelerCount) * tP;
                    }
                }
            }

            grvHistory.DataSource = relatedBookings;
            grvHistory.DataBind();
            lblTotal.Text = relatedBookings.Sum(item => item.Total).ToString("C");
        }

        protected void grvHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            
        }
    }
}