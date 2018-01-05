using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication16
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\sqlexpress;Database=Northwind;Integrated Security=SSPI";
            string queryString = @"SELECT OrderID, CustomerID, OrderDate 
                                   FROM Orders
                                   WHERE CustomerID IN (
		                                SELECT CustomerID
		                                FROM Customers
		                                WHERE City = 'London'
	                                ) AND EmployeeID = 1";
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
                        DataTable table = dataset.Tables[0];
                        Console.WriteLine("\t{0}\t{1}\t{2}", "OrderID", "CustomerID", "OrderDate");
                        Console.WriteLine("\t{0}\t{1}\t{2}", "-------", "----------", "------------------");
                        foreach (DataRow row in table.Rows)
                        {
                            Console.WriteLine("\t{0}\t{1}\t\t{2}", row[0], row[1], row[2]);
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

        OrderID CustomerID      OrderDate
        ------- ----------      ------------------
        10558   AROUT           04.06.1997 0:00:00
        10453   AROUT           21.02.1997 0:00:00
        10743   AROUT           17.11.1997 0:00:00
        11023   BSBEV           14.04.1998 0:00:00
        10364   EASTC           26.11.1996 0:00:00
        10400   EASTC           01.01.1997 0:00:00
        10377   SEVES           09.12.1996 0:00:00
        10800   SEVES           26.12.1997 0:00:00
*/
