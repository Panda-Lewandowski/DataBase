using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication31
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over DataSet *****\n");
            string connectionString = @"Integrated Security=SSPI;Initial Catalog=Northwind;Data Source=.\SqlExpress";
            string queryString = @"SELECT * FROM Customers"; 
            DataSet ds = new DataSet("Northwind");
            SqlDataAdapter da = new SqlDataAdapter(queryString, connectionString);
            da.Fill(ds, "Customers");
            DataTable dt = ds.Tables["Customers"];
            
            // Show all London customers.
            ShowLondonCustomers(dt);
            Console.WriteLine();

            // Show all UK customers.
            ShowUKCustomers(dt);
            Console.WriteLine();
            
            BuildDataTableFromQuery(dt);
            Console.WriteLine();

            Console.ReadLine();
        }

        static void ShowLondonCustomers(DataTable dt)
        {
            var LondonCustomers = from c in dt.AsEnumerable() 
                                  where c.Field<string>("City") == "London"
                                  select new
                                  {
                                      ID = c.Field<string>("CustomerID"),
                                      Name = c.Field<string>("CompanyName"),
                                      Title = c.Field<string>("ContactTitle")
                                  };
            Console.WriteLine("***** Customers from London *****");
            foreach (var item in LondonCustomers)
            {
                Console.WriteLine("{0} {1} {2}", item.ID, item.Name, item.Title);
            }
        }

        static void ShowUKCustomers(DataTable dt)
        {
            var LondonCustomers = from c in dt.AsEnumerable() 
                                  where c.Field<string>("Region") != null // "UK"
                                  select new
                                  {
                                      ID = c.Field<string>("CustomerID"),
                                      Name = c.Field<string>("CompanyName"),
                                      Title = c.Field<string>("ContactTitle")
                                  };
            Console.WriteLine("***** Customers from UK *****");
            foreach (var item in LondonCustomers)
            {
                Console.WriteLine("{0} {1} {2}", item.ID, item.Name, item.Title);
            }
        }

        static void BuildDataTableFromQuery(DataTable dt)
        {
            var customers = from c in dt.AsEnumerable()
                            where c.Field<string>("CustomerID").StartsWith("A")
                            select c;

            DataTable newTable = customers.CopyToDataTable();
            newTable.TableName = "NewCustomers";
            
            Console.WriteLine("***** Customers StartsWith A *****");
            for (int i = 0; i < newTable.Rows.Count; i++)
            {
                for (int j = 0; j < newTable.Columns.Count; j++)
                {
                    Console.Write(newTable.Rows[i][j].ToString().Trim() + "\t");
                }
                Console.WriteLine();
            }
            newTable.WriteXml("Cusromers.xml");
            newTable.WriteXmlSchema("Customers.xsd");
            
        }
    }
}

