using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace ConsoleApplication2
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
            string table = Console.ReadLine();
            //Console.WriteLine("{0}", table);
            string connectionString = @"server = 192.168.1.36 ; database = " + db + "; user id = sa; password = " + pass;
            string queryString = @"SELECT TOP 3 * FROM " + table + " FOR XML AUTO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (XmlReader reader = command.ExecuteXmlReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.Name);
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
