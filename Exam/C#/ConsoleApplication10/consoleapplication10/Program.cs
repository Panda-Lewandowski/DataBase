using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            string queryString = @"SELECT P.CategoryID, AVG(P.UnitPrice) AS AveragePrice
                                   FROM Products P
                                   GROUP BY P.CategoryID
                                   HAVING AVG(P.UnitPrice) > (
		                                SELECT AVG(UnitPrice)
		                                FROM Products
	                               )";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("\t{0}\t{1}", "CategoryID", "AveragePrice");
                            Console.WriteLine("\t{0}\t{1}", "----------", "------------");
                            while (reader.Read())
                            {
                                Console.WriteLine("\t{0}\t\t{1}", reader[0], reader[1]);
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
Определить среднюю цену продукта каждой категории, ограничиваясь только теми продуктами, 
средняя цена которых для данной категории больше средней цены по всем продуктам.

Пример выполнения приложения.
 
        CategoryID      AveragePrice
        ----------      ------------
        1               37,9791
        6               54,0066
        7               32,3700
*/