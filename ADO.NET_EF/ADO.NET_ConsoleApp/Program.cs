using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADO.NET_ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
           var path = ConfigurationManager.ConnectionStrings["entity"].ToString();

            SqlConnection conn = new SqlConnection(path);
            conn.Open();

        }
    }
}
