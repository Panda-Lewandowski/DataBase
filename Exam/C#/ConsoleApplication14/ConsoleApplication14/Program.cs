using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            int firstParamValue = 0;
            Console.Write("Введите идентификационный номер поставщика: ");
            try
            {
                firstParamValue = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Компания поставщика {0}:  {1}", firstParamValue, LookUpCompanyName(connection, firstParamValue));
                Console.ReadLine();
            }
        }

        private static string LookUpCompanyName(SqlConnection connection, int supplierID)
        {
            string companyName = string.Empty;
            string queryString = @"SELECT CompanyName FROM Suppliers WHERE SupplierID = @SupplierID";
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.Add(new SqlParameter("@SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "SupplierID", DataRowVersion.Default, supplierID));
                companyName = (string)command.ExecuteScalar();
            }
            return companyName;
        }
    }
}
/*
Создать проект консольного приложения на C#, которое выполняет скалярный запрос в учебной базе данных Northwind: 
"Получить название компании поставщика по его идентификационному номеру". Параметр запроса вводить с консоли.

Пример выполнения приложения.

Введите идентификационный номер поставщика: 1
Компания поставщика 1:  Exotic Liquids
*/