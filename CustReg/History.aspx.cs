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
    // a page to show the booking history of the loggedin customer
    public partial class History : System.Web.UI.Page
    {
        // when the page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            //linda wallace -- to make gridview responsive
            if (grvHistory.HeaderRow != null)
            { 
            grvHistory.HeaderRow.TableSection = TableRowSection.TableHeader;
            }


            if (Session["CustId"] == null)
            {
                Response.Redirect(@"~\Default.aspx"); // redirect the customer to the main page to log in
            }
            int CustId = Convert.ToInt32(Session["CustId"]); // get the customer Id using the session

            // reading the data of the loggedin customer from DB
            Customer loggedinCust = GenericDB.GenericRead<Customer>("Customers", 1, CustId)[0];

            // a header for the page based on the customer name
            lblCust.Text = "Booking History for: "+loggedinCust.CustFirstName + " " + loggedinCust.CustLastName;

            // get a list of all bookings from DB 
            List<Booking> allBookings = GenericDB.GenericRead<Booking>("Bookings");

            // get a list of all packages from DB 
            List<Package> allPackages = GenericDB.GenericRead<Package>("Packages");

            // make an empty list of customer's bookings history
            List<HistoryEntity> relatedBookings = new List<HistoryEntity>();

            // look through the booking list to find the ones which are for the current customer
            foreach (Booking b in allBookings)
            {
                if (b.CustomerId == CustId)
                {
                    HistoryEntity htry = new HistoryEntity(); // make a new empty history object
                    htry.CustomerId = b.CustomerId;  // get the Id 
                    htry.TravelerCount = b.TravelerCount; // pick the no. of travelers 
                    htry.PackageId = b.PackageId; // get the package Id 
                    htry.BookingId = b.BookingId; // get the booking Id 
                    relatedBookings.Add(htry); // add the history object to the list of related bookings
                }                                   
            }

            // look through the related booking list made in the above method to fill its empty columns
            foreach (HistoryEntity h in relatedBookings)
            {
                // look through the package list to find the ones which are for the current customer and fill the related bookings list
                foreach (Package p in allPackages)
                {
                    if (p.PackageID == h.PackageId)
                    {
                        h.PackageName = p.PkgName; // get the Package Name 
                        h.BasePrice = p.PkgBasePrice; // get the Package base price 
                        h.AgencyCom = p.PkgAgencyCommission; // get the Package agency commission 
                        decimal tP = h.BasePrice + h.AgencyCom; // summ the commission and base
                        h.Total = Convert.ToDecimal(h.TravelerCount) * tP; // calculate the bill price
                    }
                }
            }
                        
            grvHistory.DataSource = relatedBookings; // show the ready list in the grid view 
            grvHistory.DataBind(); // data binding
            lblTotal.Text = relatedBookings.Sum(item => item.Total).ToString("C"); // showing the total debt of the customer
        }

        // hiding some columns of the grid view
        protected void grvHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Booking Id";
                e.Row.Cells[3].Text = "Package";
                e.Row.Cells[4].Text = "# of Travelers";
            }

            // linda Wallace -- format "Total" column to Currency
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string currencyValue = String.Format("{0:C}", Convert.ToDecimal(e.Row.Cells[7].Text));
                e.Row.Cells[7].Text = currencyValue;
            }
            e.Row.Cells[0].Visible = false; // customer Id column
            e.Row.Cells[2].Visible = false; // package Id column
            e.Row.Cells[5].Visible = false; // base price column
            e.Row.Cells[6].Visible = false; // commission column           
        }
    }
}