using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            Console.Write("Введите CategoryID: ");
            int paramValue = Int32.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UPDATE_PRODUCT_PRICE";
                    SqlParameter inparam = command.Parameters.Add("@CategoryID", SqlDbType.Int);
                    inparam.Direction = ParameterDirection.Input;
                    inparam.Value = paramValue;
                    SqlParameter outparam = command.Parameters.Add("@cnt", SqlDbType.Int);
                    outparam.Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    Console.WriteLine("Количество обновленных строк {0}", command.Parameters["@cnt"].Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
/*
Увеличить цены продуктов категории @CategoryID на 10%.
Подсчитать количество обновленных строк.

Пример 1
Введите CategoryID: 10
Количество обновленных строк 0
 
Пример 2.
Введите CategoryID: 8
Количество обновленных строк 12
*/
