namespace ConsoleAppDemo
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        static void Main()
        {
            var path = "Data Source=.;initial catalog=newusers;integrated security=True";
            SqlWork(path);
            Console.WriteLine("Close");
        }

        public static void SqlWork(string path)
        {
            using (SqlConnection conn = new SqlConnection(path))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = "SELECT * FROM Users";
                    // SELECT command
                    using (SqlDataReader reader = command.ExecuteReaderAsync().Result)
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                                Console.WriteLine(reader.GetString(1) + "  " + reader.GetString(2));
                    }

                    Console.WriteLine("Select close.. press enter..");
                    // Delay !
                    Console.Read();
                    // INSERT command..
                    command.CommandText = "INSERT INTO Users(FirstName, LastName) Values" +
                                          $"('{Console.ReadLine()}'" +
                                          $",'{Console.ReadLine()}')";

                    try
                    {
                        int affected = command.ExecuteNonQueryAsync().Result;
                        if (affected != 0)
                            transaction.Commit();
                        Console.WriteLine($"Commited at: {DateTime.Now.ToShortTimeString()} successfull..\n" +
                                          $"affected: {affected}"); // info
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Rolled back..!");
                    }
                }
            }
        }
    }
}