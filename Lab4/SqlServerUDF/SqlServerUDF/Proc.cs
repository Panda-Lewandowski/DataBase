using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void AvgStuffNum (string company_name)
    {
        using (SqlConnection contextConnection = new SqlConnection("context connection = true"))
        {
            SqlCommand contextCommand =
               new SqlCommand(
               "Select AVG(WorkingStaffNum) from Company " +
               "where CompanyName = @name", contextConnection);

            contextCommand.Parameters.AddWithValue("@name", company_name);
            contextConnection.Open();

            SqlContext.Pipe.ExecuteAndSend(contextCommand);
        }

    }
}
