using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            string queryString = @"SELECT ProductID, ProductName, UnitPrice
                                   FROM Products
                                   WHERE UnitPrice > ALL (
		                                SELECT UnitPrice
		                                FROM Products
		                                WHERE CategoryID = @number
	                                )";
            int paramValue = 0;
            try
            {
                Console.Write("Введите номер категории продукта: ");
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
                        command.Parameters.AddWithValue("@number", paramValue);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("\t{0}\t{1}\t\t{2}", "ProductID", "ProductName", "UnitPrice");
                            Console.WriteLine("\t{0}\t{1}\t\t{2}", "---------", "-----------", "---------");
                            while (reader.Read())
                            {
                                //Console.WriteLine("\t{0}\t\t{1,10:c2}", reader[0], reader[1]+": "+reader[2]);
                                Console.WriteLine("\t{0}\t\t{1,-22}\t{2, 9:c2}", reader[0], reader[1], reader[2]);
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
Получить сведения о продуктах (ProductID, ProductName, UnitPrice), цена которых больше цены любого продукта той категории, номер которой указан в параметре запроса.
Параметр запроса вводить с консоли.

Пример выполнения приложения.

Введите номер категории продукта: 2
        ProductID       ProductName             UnitPrice
        ---------       -----------             ---------
        9               Mishi Kobe Niku           97,00р.
        18              Carnarvon Tigers          61,88р.
        20              Sir Rodney's Marmalade    81,00р.
        28              Rossle Sauerkraut         45,60р.
        29              Thuringer Rostbratwurst  123,79р.
        38              Cote de Blaye            263,50р.
        43              Ipoh Coffee               46,00р.
        51              Manjimup Dried Apples     53,00р.
        59              Raclette Courdavault      55,00р.
        62              Tarte au sucre            49,30р.
*/