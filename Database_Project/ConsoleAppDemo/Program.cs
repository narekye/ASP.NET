using System;
using System.Data.SqlClient;

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
                var select = "select * from Users";
                command.CommandText = select;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        Console.WriteLine(reader.GetString(1) + "  " + reader.GetString(2));

                    
                    reader.Close();
                }
                Console.WriteLine("Select close.. press enter..");
                Console.Read();
                command.CommandText = "Insert into Users(FirstName, LastName) Values ('Poghos','Atoyan')";

                int affected = command.ExecuteNonQuery();
                Console.WriteLine(affected);
                transaction.Commit();
                command.Dispose();
            }
            Console.WriteLine("Close");
        }
    }
}
