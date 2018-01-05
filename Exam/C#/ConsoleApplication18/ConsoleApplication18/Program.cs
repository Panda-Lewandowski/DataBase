using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication18
{
    class Program
    {
        static void Main(string[] args)
        {
		    string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwind;Integrated Security=True";
		    string queryString = "SELECT COUNT(*) FROM ";
	        Console.Write("Введите имя таблицы: ");
            string tableName = Console.ReadLine();
            queryString = queryString + "[" + tableName + "]";
            int rowCount = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        rowCount = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.WriteLine("Количество строк в таблице [{0}] = {1}.", tableName, rowCount);
            Console.ReadLine();
        }
    }
}
/*
Введите имя таблицы: Customers
Количество строк в таблице [Customers] = 92.
*/
