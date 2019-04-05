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
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\Sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public void SaveCustomer(Customer customer)
        {
            SqlConnection cnc = GetConnection();

           

            string query = "INSERT INTO Customers VALUES (" + "'" + customer.CustFirstName + "'" + "," +
                "'" + customer.CustLastName + "'" + "," +
                "'" + customer.CustAddress + "'" + "," +
                "'" + customer.CustCity + "'" + "," +
                "'" + customer.CustProv + "'" + "," +
                "'" + customer.CustPostal + "'" + "," +
                "'" + customer.CustCountry + "'" + "," +
                "'" + customer.CustHomePhone + "'" + "," +
                "'" + customer.CustBusPhone + "'" + "," +
                "'" + customer.CustEmail + "'" + ","
                 +  "NULL" + "," + 
                "'" + customer.UserId + "'" + "," +
                "'" + customer.Password + "'" + ")";
            //DBNULL agent id is null for the time being, as required by the workshop
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

        public static List<LoginInfo> GetLoginList()
        {

            SqlConnection cnn = GetConnection();
            List<LoginInfo> LoginList = new List<LoginInfo>();
            string selectStmt = "Select CustomerId,UserId, Password FROM Customers";
            SqlCommand command = new SqlCommand(selectStmt, cnn);

            try
            {
                cnn.Open();
                SqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    LoginInfo logininfo = new LoginInfo();

                    logininfo.CustId = (int)Reader["CustomerId"];
                    logininfo.UserId = (string)Reader["UserId"];
                    logininfo.Password = (string)Reader["Password"];

                    LoginList.Add(logininfo);


                }

            }

            catch
            {
                throw;
            }
            finally
            {
                cnn.Close();
            }

            return LoginList;

        }

    }


}

