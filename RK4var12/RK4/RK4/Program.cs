using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RK4
{
    class Program
    {
        static readonly string connectionString = @"server = localhost;Initial Catalog = tempdb;integrated security = true;";
        static SqlConnection connection = null;
        static int id = 0;
        
        static void Main(string[] args)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string answer = String.Empty;

            do
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Add rows");
                Console.WriteLine("2. Show table");
                Console.WriteLine("q. Exit");
                Console.Write("->");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        {
                            AddRows();
                            break;
                        }

                    case "2":
                        {
                            ShowTable();
                            break;
                        }

                    case "q":
                        {
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Not correct choice!");
                            break;
                        }
                }

                Console.WriteLine();
            }
            while (answer != "q");

            connection.Close();
        }

        static void AddRows()
        {
            Console.Write("How many rows to add: ");
            StringBuilder text = new StringBuilder("INSERT INTO Customer VALUES ");

            try
            {
                int count = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    string companyName = String.Empty;
                    Console.Write("Enter CompanyName: ");
                    companyName = Console.ReadLine();
                    double money = 0;
                    Console.Write("Enter CreditLimit: ");
                    money = Convert.ToDouble(Console.ReadLine());

                    text.Append(String.Format("('{0}', '{1}', {2})", id++, companyName, money));

                    if (i + 1 != count)
                    {
                        text.Append(',');
                    }

                    Console.WriteLine();
                }

                SqlCommand command = connection.CreateCommand();
                command.CommandText = text.ToString();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not correct value!");
            }
        }

        static void ShowTable()
        {
            Console.WriteLine("Table:");

            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Customer";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i].ToString());
                            Console.Write('\t');
                        }

                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }
    }
}
