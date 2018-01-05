using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Northwind;Integrated Security=true";
            string queryString = @"SELECT * FROM dbo.Customers
                                   WHERE CustomerID BETWEEN @lowBound AND @highBound";
            Console.Write("Введите нижнюю границу CustomerID: ");
            string firstParamValue = Console.ReadLine();
            Console.Write("Введите верхнюю границу CustomerID: ");
            string secondParamValue = Console.ReadLine();
            //string firstParamValue = "ALFKI";
            //string secondParamValue = "ANTON";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@lowBound", firstParamValue);
                command.Parameters.AddWithValue("@highBound", secondParamValue);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Результирующий набор данных пуст!");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("----------------------------------------");
                            for (int j = 0; j < reader.FieldCount; j++)
                            {
                                Console.WriteLine("\t" + reader.GetName(j) + ": " + reader[j].ToString() + "; ");
                            }
                        }
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
Введите нижнюю границу CustomerID: ALFKI
Введите верхнюю границу CustomerID: ANTON
----------------------------------------
        CustomerID: ALFKI;
        CompanyName: Alfreds Futterkiste;
        ContactName: Maria Anders;
        ContactTitle: Sales Representative;
        Address: Obere Str. 57;
        City: Berlin;
        Region: ;
        PostalCode: 12209;
        Country: Germany;
        Phone: 030-0074321;
        Fax: 030-0076545;
        CreditLimit: ;
----------------------------------------
        CustomerID: ANATR;
        CompanyName: Ana Trujillo Emparedados y helados;
        ContactName: Ana Trujillo;
        ContactTitle: Owner;
        Address: Avda. de la Constitucion 2222;
        City: Mexico D.F.;
        Region: ;
        PostalCode: 05021;
        Country: Mexico;
        Phone: (5) 555-4729;
        Fax: (5) 555-3745;
        CreditLimit: ;
----------------------------------------
        CustomerID: ANTON;
        CompanyName: Antonio Moreno Taqueria;
        ContactName: Antonio Moreno;
        ContactTitle: Owner;
        Address: Mataderos  2312;
        City: Mexico D.F.;
        Region: ;
        PostalCode: 05023;
        Country: Mexico;
        Phone: (5) 555-3932;
        Fax: ;
        CreditLimit: ;
  
Введите нижнюю границу CustomerID: QWERT
Введите верхнюю границу CustomerID: ASDFG
Результирующий набор строк пуст!  
 */
