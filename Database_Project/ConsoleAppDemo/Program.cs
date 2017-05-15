using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleAppDemo
{
    class Program
    {
        static void Main()
        {
            var path = "Data Source=.;initial catalog=newusers;integrated security=True";

            using (SqlConnection conn = new SqlConnection(path))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand command = conn.CreateCommand();

                command.Transaction = transaction;
                command.CommandText = "Select * from Users";

                var reader = command.ExecuteReader();
                while (reader.Read())
                    Console.WriteLine(reader.GetInt32(0) + "  " + reader.GetString(1) + "  " + reader.GetString(2));
                
                // command.CommandText = $"INSERT INTO Users(FirstName,LastName) VALUES ({Console.ReadLine()},{Console.ReadLine()})";
                // command.ExecuteNonQuery();
                // Console.WriteLine(count);
                Console.WriteLine("Close");
            }
        }
    }
}
