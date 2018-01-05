using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            string queryString = @"SELECT TOP 3 * FROM Customers FOR XML RAW";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (XmlReader reader = command.ExecuteXmlReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Строка:");
                            if (reader.HasAttributes)
                            {
                                for (int j = 0; j < reader.AttributeCount; j++)
                                {
                                    reader.MoveToAttribute(j);
                                    Console.WriteLine("\t{0}: {1}", reader.Name, reader.Value);
                                }
                                reader.MoveToElement();
                            }
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
