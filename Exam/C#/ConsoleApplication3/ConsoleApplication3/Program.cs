using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            string queryString = @"SELECT OrderID, SUM(Quantity) AS Total
                                   FROM [Order Details]
                                   GROUP BY OrderID
                                   HAVING SUM(Quantity) > @down";
            int paramValue = 0;
            try
            {
                Console.Write("Введите нижнюю границу на количество заказанных продуктов: ");
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
                            Console.WriteLine("\t{0}\t{1}", "OrderID", "Total");
                            Console.WriteLine("\t{0}\t{1}", "-------", "-------");
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
  Определить общее количество единиц в каждом заказе, ограничиваясь только теми заказами, которые содержат больше заказанных продуктов, чем указанно в параметре запроса.
  Параметр запроса вводить с консоли.
 
  Пример выполнения приложения.
 
  Введите нижнюю границу на количество заказанных продуктов: 300
        OrderID Total
        ------- -------
        10895   346
        11030   330
 
*/
