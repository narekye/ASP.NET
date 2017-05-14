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

            using (SqlConnection conn = new SqlConnection(path))
            {
                try
                {
                    conn.OpenAsync().Wait();
                    SqlCommand command = new SqlCommand("Select * from Books", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine(reader.GetName(0) + "\t" + reader.GetName(1));
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetValue(0) + "\t" + reader.GetValue(1));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.Read();
        }
    }
}
