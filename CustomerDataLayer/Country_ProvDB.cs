using CustomerBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataLayer
{
   public class Country_ProvDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\Sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public static List<Country> GetCountries()
        {

            SqlConnection cnn = GetConnection();
            List<Country> CountryList = new List<Country>();
            string selectStmt = "Select*FROM Countries";
            SqlCommand command = new SqlCommand(selectStmt, cnn);

            try
            {
                cnn.Open();
                SqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Country country = new Country();

                    country.CountryId = (decimal)Reader["CountryId"];
                    country.CountryName = (string)Reader["Country"];
                    

                    CountryList.Add(country);


                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return CountryList;
        }
        public static List<Prov> GetProvinces()
        {

            SqlConnection cnn = GetConnection();
            List<Prov> ProvList = new List<Prov>();
            string selectStmt = "Select*FROM Provinces";
            SqlCommand command = new SqlCommand(selectStmt, cnn);

            try
            {
                cnn.Open();
                SqlDataReader Reader = command.ExecuteReader();


                while (Reader.Read())
                {
                    Prov province = new Prov();

                    province.Initial = (string)Reader["ProvKey"];
                    province.ProvName = (string)Reader["ProvinceName"];


                    ProvList.Add(province);


                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

            return ProvList;

        }

    }
}
