using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\sqlexpress;Database=Northwind; Integrated Security=SSPI";
            string queryString = @"SELECT * FROM Employees";
            using (SqlConnection connection = new SqlConnection())
            {
                // Configure the SqlConnection object's connection string.
                connection.ConnectionString = connectionString;
                // Open the database connection
                connection.Open();
                // create the data set
                DataSet dataset = new DataSet();
                // create the sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                // create the command builder so we can do modifications
                SqlCommandBuilder commbuilder = new SqlCommandBuilder(adapter);
                // populate the data set from the database
                adapter.Fill(dataset);
                // obtain the data table
                DataTable table = dataset.Tables[0];
                // perform the LINQ query
            //IEnumerable<string> result = from e in table.AsEnumerable()
            //                                where e.Field<int>(0) < 3
            //                                select e.Field<string>(1);

                var query = from row in table.AsEnumerable()
                            //where row.Field<string>("Country") < 'UK' 
                            select new
                            {
                                LastName = row.Field<string>("LastName"),
                                FirstName = row.Field<string>("FirstName"),
                                HireDate = row.Field<DateTime>("HireDate")
                            };

                foreach (var item in query)
                {
                    Console.WriteLine("LastName: {0} FirstName: {1:d} HireDate: {2}",
                        item.LastName,
                        item.FirstName,
                        item.HireDate);
                }
            }
            Console.ReadLine();
        }
    }
}
