using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Assignment.Services
{
    public class Helper
    {
        public static SqlConnection CreateDatabaseConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Assignment"].ConnectionString);
        }
    }
}