using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication19
{
    class Program
    {
        static void Main(string[] args)
        {
            string conectionString = @"server=.\sqlexpress;database=northwind;integrated security=SSPI";
            Console.Write("Введите имя таблицы: ");
            string tableName = Console.ReadLine();
            string queryString = "SELECT * FROM [" + tableName + "]";
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int j = 0; j < reader.FieldCount; j++)
                                {
                                    Console.Write(reader.GetName(j) + ": " + reader[j].ToString() + "; ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
/*
Введите имя таблицы: Shippers
ShipperID: 1; CompanyName: Speedy Express; Phone: (503) 555-9831;
ShipperID: 2; CompanyName: United Package; Phone: (503) 555-3199;
ShipperID: 3; CompanyName: Federal Shipping; Phone: (503) 555-9931;
*/
