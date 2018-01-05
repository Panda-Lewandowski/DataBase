using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\sqlexpress;Database=Northwind;Integrated Security=SSPI";
            string queryString = @"SELECT * FROM Employees";
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    DataSet dataset = new DataSet();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionString))
                    {
                        adapter.Fill(dataset);
                        Console.WriteLine("\nСхема таблицы Employees:");
                        DataTable table = dataset.Tables[0];
                        foreach (DataColumn col in table.Columns)
                        {
                            Console.WriteLine("\tСтолбец: {0,-15}\t Тип: {1}", col.ColumnName, col.DataType);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
/*
Пример работы приложения.

Схема таблицы Employees:
        Столбец: EmployeeID              Тип: System.Int32
        Столбец: LastName                Тип: System.String
        Столбец: FirstName               Тип: System.String
        Столбец: Title                   Тип: System.String
        Столбец: TitleOfCourtesy         Тип: System.String
        Столбец: BirthDate               Тип: System.DateTime
        Столбец: HireDate                Тип: System.DateTime
        Столбец: Address                 Тип: System.String
        Столбец: City                    Тип: System.String
        Столбец: Region                  Тип: System.String
        Столбец: PostalCode              Тип: System.String
        Столбец: Country                 Тип: System.String
        Столбец: HomePhone               Тип: System.String
        Столбец: Extension               Тип: System.String
        Столбец: Photo                   Тип: System.Byte[]
        Столбец: Notes                   Тип: System.String
        Столбец: ReportsTo               Тип: System.Int32
        Столбец: PhotoPath               Тип: System.String
*/