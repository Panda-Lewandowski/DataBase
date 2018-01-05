using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите пароль администратора: ");
            string pass = Console.ReadLine();
            Console.WriteLine("Введите имя базы данных: ");
            string db = Console.ReadLine();
            pass.Replace("\n", "");
            Console.WriteLine("Введите имя таблицы: ");
            string  table = Console.ReadLine();
            //Console.WriteLine("{0}", table);
            string connectionString = @"server = 192.168.1.36 ; database = " + db + "; user id = sa; password = " + pass;
            string queryString = @"SELECT * FROM " + table;
            try
            {
                           
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        connection.Open();
                        Console.WriteLine("Connection has been opened.");
                        Console.WriteLine("Connection properties:");
                        Console.WriteLine("\tConnection string: {0}", connection.ConnectionString);
                        Console.WriteLine("\tDatabase:          {0}", connection.Database);
                        Console.WriteLine("\tData Source:       {0}", connection.DataSource);
                        Console.WriteLine("\tServer version:    {0}", connection.ServerVersion);
                        Console.WriteLine("\tConnection state:  {0}", connection.State);
                        Console.WriteLine("\tWorkstation id:    {0}", connection.WorkstationId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                                Console.WriteLine("Метаданные таблицы  {0}:", table);
                                for (int j = 0; j < reader.FieldCount; j++)
                                {
                                    Console.WriteLine("\tИмя столбца: {0}    Тип: {1}", reader.GetName(j), reader.GetDataTypeName(j));
                                }
                            }
                        
                        }
                    }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
