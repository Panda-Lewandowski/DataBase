using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            Console.Write("Введите ограничитель числа служащих: ");
            int paramValue = Int32.Parse(Console.ReadLine());
            //int paramValue = 4;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "MANAGER_AND_REPORTS";
                    SqlParameter inparm = command.Parameters.Add("@limit", SqlDbType.Int);
                    inparm.Direction = ParameterDirection.Input;
                    inparm.Value = paramValue;
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("\t{0}\t{1}", "Manager", "Reports");
                    Console.WriteLine("\t{0}\t{1}", "-------", "-------");
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                    reader.Close();
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
Определить количество служащих, которые подают отчеты каждому менеджеру, ограничиваясь только теми менеджерами, которым подают отчеты более @limit служащих.

Пример 1.
Введите ограничитель числа служащих: 2
        Manager Reports
        ------- -------
        2       5
        5       3

Пример 2.
Введите ограничитель числа служащих: 4
        Manager Reports
        ------- -------
        2       5 
 
CREATE PROCEDURE dbo.MANAGER_AND_REPORTS (@limit int)
AS
BEGIN
	SELECT ReportsTo AS Manager, COUNT(*) AS Reports
	FROM dbo.Employees
	GROUP BY ReportsTo
	HAVING COUNT(*) > @limit
END  
*/