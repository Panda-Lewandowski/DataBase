using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=master;Integrated Security=SSPI";
        string createCommand = "CREATE TABLE Foo(Column1 INT NOT NULL PRIMARY KEY)";
        string dropCommand = "DROP TABLE Foo";
        SqlConnection cn = new SqlConnection(connectionString);
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(createCommand, cn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table Created");
            Console.WriteLine("Press enter to continue (you can go check to make sure that it’s there first) ");
            Console.ReadLine();

            cmd.CommandText = dropCommand;
            cmd.ExecuteNonQuery();
            Console.WriteLine("It’s gone");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        finally
        {
            if (cn != null)
            {
                cn.Close();
            }
        }
    }
}
