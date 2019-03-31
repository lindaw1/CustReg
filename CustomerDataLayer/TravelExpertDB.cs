using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB
{
    public static class TravelExpertDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\Sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
