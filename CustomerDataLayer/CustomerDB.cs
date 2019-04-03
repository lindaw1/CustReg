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
                "'" + customer.UserId + "'" + ","+
                "'" + customer.Password + "'" +")";

            SqlCommand cmnd = new SqlCommand(query, cnc);
           

            try
            {
                cnc.Open();
                cmnd.ExecuteNonQuery();
                
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

        public List<Customer> GetCustomers()
        {

           SqlConnection cnn = GetConnection();
            List<Customer> Customers = mbox



            return Customers;

        }




    }
}
