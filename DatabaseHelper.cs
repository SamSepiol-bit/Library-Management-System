using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration; 
using System.Data.SqlClient;

namespace LibraryApp
{
    public class DatabaseHelper
    {
        public static string GetConnectionString()
        {
          
            return ConfigurationManager.ConnectionStrings["LibraryDbConnection"].ConnectionString;
        }

        public static SqlConnection GetConnection()   
        {
            return new SqlConnection(GetConnectionString());  
        }
    }
}
