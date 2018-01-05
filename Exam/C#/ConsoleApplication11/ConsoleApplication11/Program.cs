using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            Console.Write("Введите название компании грузоотправителя: ");
            string firstParamValue = Console.ReadLine();
            Console.Write("Введите телефон компании грузоотправителя: ");
            string secondParamValue = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand insert = GenerateInsertCommand(connection);
                    insert.Parameters["@CompanyName"].Value = firstParamValue;
                    insert.Parameters["@Phone"].Value = secondParamValue;
                    insert.ExecuteNonQuery();
                    int newShipperID = (int)insert.Parameters["@ShipperID"].Value;
                    Console.WriteLine("newShipperID = {0}", newShipperID);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }

        private static SqlCommand GenerateInsertCommand(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SHIPPER_INSERT", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NChar, 40, "CompanyName"));
            command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NChar, 24, "Phone"));
            command.Parameters.Add(new SqlParameter("@ShipperID", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "ShipperID", DataRowVersion.Default, null));
            command.UpdatedRowSource = UpdateRowSource.OutputParameters;
            return command;
        }
    }
}
/*
В учебной базе данных Northwind создать хранимую процедуру для добавления одной строки в таблицу грузоотправителей (Shippers), 
используя в качестве входных параметров название компании грузоотправителя (CompanyName) и телефон компании грузоотправителя (Phone).
Создать проект консольного приложения на C#, которое вызывает процедуру добавления одной строки в таблицу грузоотправителей и 
выводит номер (ShipperID) вставленной строки. Параметры процедуры вводить с консоли.

Пример выполнения приложения.

Введите название компании грузоотправителя: Super Fast Shipping
Введите телефон компании грузоотправителя: (503) 555-6493
newShipperID = 4
*/