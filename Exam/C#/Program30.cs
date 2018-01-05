using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace ConsoleApplication30
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** ConsoleApplication30 *****\n");
            string connectionString = @"Integrated Security=SSPI;Initial Catalog=Northwind;Data Source=.\SqlExpress";
            string queryString1 = @"SELECT CategoryID, CategoryName, Description FROM Categories"; 
            string queryString2 = @"SELECT ProductName, UnitPrice FROM Products WHERE CategoryID = 1";
            DataSet ds = new DataSet("Northwind");
            SqlDataAdapter da1 = new SqlDataAdapter(queryString1, connectionString);
            SqlDataAdapter da2 = new SqlDataAdapter(queryString2, connectionString);
            da1.Fill(ds, "Categories");
            da2.Fill(ds, "Products");
            PrintDataSet(ds);
            SaveAsXml(ds);
            Console.ReadLine();
        } 
 
        static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine("DataSet is named: {0}", ds.DataSetName);
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("Data Table is named: {0}", dt.TableName);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(dt.Columns[j].ColumnName + "\t");
                }
                Console.WriteLine("\n----------------------------------------");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Console.Write(dt.Rows[i][j].ToString().Trim() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void SaveAsXml(DataSet ds)
        {
            ds.WriteXml("NWDataSet.xml");
            ds.WriteXmlSchema("NWDataSet.xsd");
            ds.Clear();
            //ds.ReadXml("NWDataSet.xml");
        } 
    }
}

