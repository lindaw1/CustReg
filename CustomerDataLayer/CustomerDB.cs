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
            //To do:  set up new fields in database
            string query = "INSERT INTO Customers ([CustFirstName],[CustLastName],[CustUserId],[CustPassword] VALUES (@FirstName, @LastName, @UserId,@Password)";

            SqlCommand cmnd = new SqlCommand(query, cnc);

            cmnd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmnd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmnd.Parameters.AddWithValue("@UserId", customer.UserId);
            cmnd.Parameters.AddWithValue("@Password", customer.Password);

            try
            {
                cnc.Open();
                cmnd.ExecuteNonQuery();
                    //to do:  study what the different options are re: executeNonQuery, scalar, reader etc.
            }
            catch
            {
                throw ;
            }
            finally
            {
                cnc.Close();
            }
    }
}
