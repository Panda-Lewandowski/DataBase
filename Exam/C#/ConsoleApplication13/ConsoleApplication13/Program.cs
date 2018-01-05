using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication13
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            string firstParamValue = string.Empty;
            Console.Write("Введите идентификационный номер клиента: ");
            firstParamValue = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Компания клиента {0}:  {1}", firstParamValue, LookUpCompanyName(connection, firstParamValue));
                Console.ReadLine();
            }
        }

        private static string LookUpCompanyName(SqlConnection connection, string customerID)
        {
	        string companyName = string.Empty;
            using (SqlCommand command = new SqlCommand("GET_CUSTOMER_COMPANY_NAME", connection))
	        {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NChar, 5, ParameterDirection.Input, false, 0, 0, "CustomerID", DataRowVersion.Default, customerID));
                command.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar, 40, ParameterDirection.Output, false, 0, 0, "CompanyName", DataRowVersion.Default, null));               
                command.ExecuteNonQuery();
                companyName = (string)command.Parameters["@CompanyName"].Value;
	        }
            return companyName;
        }
    }
}
/*
В учебной базе данных Northwind создать хранимую процедуру, которая возвращает название компании клиента по его идентификационному номеру.
Создать проект консольного приложения на C#, которое вызывает процедуру получения названия компании и 
выводит это название. Параметр процедуры вводить с консоли.

Пример выполнения приложения.

Введите идентификационный номер клиента: ALFKI
Компания клиента ALFKI:  Alfreds Futterkiste
*/
