using CustomerBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataLayer
{
    public class CustomerDB
    {
        public SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\Sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public void SaveCustomer(Customer customer)
        {
            SqlConnection cnc = GetConnection();

            //@AgentId
            //    [AgentId],    

            string query = "INSERT INTO Customers VALUES (" + "'" + customer.FirstName + "'" + "," +
                "'" + customer.LastName + "'" + "," +
                "'" + customer.Address + "'" + "," +
                "'" + customer.City + "'" + "," +
                "'" + customer.Province + "'" + "," +
                "'" + customer.Postal + "'" + "," +
                "'" + customer.Country + "'" + "," +
                "'" + customer.HomePhone + "'" + "," +
                "'" + customer.BusPhone + "'" + "," +
                "'" + customer.Email + "'" + "," 
                 + customer.AgentId  + ","+
                "'" + customer.Password + "'" + ","+
                "'" + customer.UserId + "'" +")";

            SqlCommand cmnd = new SqlCommand(query, cnc);
            /*
             *string query = "INSERT INTO Customers ([CustFirstName],[CustLastName],[CustAddress],[CustCity],[CustProv],[CustPostal],[CustCountry],[CustHomePhone],[CustBusPhone],[CustEmail],[CustPassword],[CustUserID]) VALUES (@FirstName, @LastName, @Address, @City, @Prov, @Postal, @Country, @HomePhone, @BusPhone, @Email, @Password, @UserId)";
             * 
            cmnd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmnd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmnd.Parameters.AddWithValue("@Address", customer.Address);
            cmnd.Parameters.AddWithValue("@City", customer.City);
            cmnd.Parameters.AddWithValue("@Prov", customer.Province);
            cmnd.Parameters.AddWithValue("@Postal", customer.Postal);
            cmnd.Parameters.AddWithValue("@Country", customer.Country);
            cmnd.Parameters.AddWithValue("@HomePhone", customer.HomePhone);
            cmnd.Parameters.AddWithValue("@BusPhone", customer.BusPhone);
            cmnd.Parameters.AddWithValue("@Email", customer.Email);
            cmnd.Parameters.AddWithValue("@Password", customer.Password);
            cmnd.Parameters.AddWithValue("@UserId", customer.UserId);
            //cmnd.Parameters.AddWithValue("@AgentId", null);
            */
            try
            {
                cnc.Open();
                cmnd.ExecuteNonQuery();
                //to do:  study what the different options are re: executeNonQuery, scalar, reader etc.
            }
            catch
            {
                throw;
            }
            finally
            {
                cnc.Close();
            }
        }
    }
}
