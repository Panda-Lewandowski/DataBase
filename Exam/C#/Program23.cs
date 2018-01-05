using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Diagnostics;  //  For the StackTrace.

namespace ConsoleApplication23
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";
            string queryString = @"
            SELECT O.EmployeeID, E.FirstName + ' ' + E.LastName as EmployeeName, O.CustomerID, C.CompanyName, O.ShipCountry
            FROM Orders O JOIN Employees E on O.EmployeeID = E.EmployeeID JOIN Customers C on O.CustomerID = C.CustomerID"; 
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
            Console.Write("Введите название страны: ");
            string country = Console.ReadLine();
            using (SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionString))
            {
                using (DataSet ds = new DataSet())
                {
                    try
                    {
                        adapter.Fill(ds, "EmpCustShip");
                        var ordersQuery = ds.Tables["EmpCustShip"].AsEnumerable()
                            .Where(r => r.Field<string>("ShipCountry").Equals(country))
                            .Distinct(System.Data.DataRowComparer.Default)
                            .OrderBy(r => r.Field<string>("EmployeeName"))
                            .ThenBy(r => r.Field<string>("CompanyName"));

                        foreach (var dataRow in ordersQuery)
                        {
                            Console.WriteLine("\t{0,-20} {1,-20}", dataRow.Field<string>("EmployeeName"), dataRow.Field<string>("CompanyName"));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }
    }
}
/*
Сначала
O.EmployeeID, E.FirstName + ' ' + E.LastName as EmployeeName, O.CustomerID, C.CompanyName, O.ShipCountry
Потом
EmployeeName, CompanyName 
для поставку в страну, указываемой параметром запроса
Параметр запроса вводить с консоли

Пример выполнения приложения.
 
Main : Begin
Введите название страны: Denmark
        Andrew Fuller        Simons bistro
        Andrew Fuller        Vaffeljernet
        Janet Leverling      Vaffeljernet
        Laura Callahan       Vaffeljernet
        Margaret Peacock     Simons bistro
        Margaret Peacock     Vaffeljernet
        Michael Suyama       Vaffeljernet
        Nancy Davolio        Vaffeljernet
        Robert King          Simons bistro
        Robert King          Vaffeljernet
Main : End
*/
