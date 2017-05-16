namespace ConsoleAppDemo
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        static void Main()
        {
            var path = "Data Source=.;initial catalog=newusers;integrated security=True";
            using (SqlConnection conn = new SqlConnection(path))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = "select * from Users";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            Console.WriteLine(reader.GetString(1) + "  " + reader.GetString(2));
                    }

                    Console.WriteLine("Select close.. press enter..");
                    Console.Read();

                    command.CommandText = "Insert into Users(FirstName, LastName) Values" +
                                          $"('{Console.ReadLine()}'" +
                                          $",'{Console.ReadLine()}')";

                    try
                    {
                        int affected = command.ExecuteNonQuery();
                        Console.WriteLine(affected);
                        transaction.Commit();
                        Console.WriteLine($"Commited at: {DateTime.Now.ToShortTimeString()} successful..");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Rolled back..!");
                    }
                }
            }
            Console.WriteLine("Close");
        }
    }
}
