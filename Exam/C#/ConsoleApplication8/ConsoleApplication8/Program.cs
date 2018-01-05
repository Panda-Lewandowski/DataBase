using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            string queryString = @"SELECT Country, COUNT(*) AS NumberOfCliens
                                   FROM Customers
                                   GROUP BY country
                                   HAVING COUNT(*) > @down";
            int paramValue = 0;
            try
            {
                Console.Write("Введите нижнюю границу на количество клиентов: ");
                paramValue = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@down", paramValue);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("\t{0}\t{1}", "Country", "NumberOfCliens");
                            Console.WriteLine("\t{0}\t{1}", "-------", "--------------");
                            while (reader.Read())
                            {
                                Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
/*
Определить общее количество клиентов в каждой стране, ограничиваясь только теми странами, в которых количество клиентов больше, чем указанно в параметре запроса.
Параметр запроса вводить с консоли.

Пример выполнения приложения.
 
Введите нижнюю границу на количество клиентов: 5
        Country NumberOfCliens
        ------- --------------
        Brazil  9
        France  11
        Germany 11
        UK      7
        USA     13
*/