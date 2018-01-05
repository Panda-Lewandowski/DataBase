using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            int firstParamValue = 0;
            try
            {
                Console.Write("Введите величину, на которую изменяется цена: ");
                firstParamValue = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Введите название компании поставщика: ");
            string secondParamValue = Console.ReadLine();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand update = GenerateUpdateCommand(connection);
                    update.Parameters["@AddPrice"].Value = firstParamValue;
                    update.Parameters["@CompanyName"].Value = secondParamValue;
                    update.ExecuteNonQuery();
                    int count = (int)update.Parameters["@Count"].Value;
                    Console.WriteLine("Количество обновленных строк: {0}", count);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }

        private static SqlCommand GenerateUpdateCommand(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("PRODUCTS_UPDATE", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@AddPrice", SqlDbType.Int, 0, "UnitPirice"));
            command.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName"));
            command.Parameters.Add(new SqlParameter("@Count", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, null));
            command.UpdatedRowSource = UpdateRowSource.OutputParameters;
            return command;
        }
    }
}
/*
В учебной базе данных Northwind создать хранимую процедуру для обновления строк в таблице продуктов (Products), 
используя в качестве входных параметров величину, на которую изменяется цена продукта (UnitPrice), и название компании поставщика (Suppliers.CompanyName).
Создать проект консольного приложения на C#, которое вызывает процедуру обновления строк в таблице продуктов и 
выводит количество обновленных строк. Параметры процедуры вводить с консоли.

Пример выполнения приложения.

Введите величину, на которую изменяется цена: 5
Введите название компании поставщика: Exotic Liquids
Количество обновленных строк: 3
*/