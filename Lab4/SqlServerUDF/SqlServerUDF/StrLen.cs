using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections;

public partial class SqlServerUDF
{
    [Microsoft.SqlServer.Server.SqlFunction(FillRowMethodName = "FillRow",
           TableDefinition = "charpart nchar(1), intpart int")]
    public static IEnumerable StrLen(string InputName)
    {
        yield return new NameRow(InputName, InputName.Length);
    }

    public static void FillRow(object row, out SqlString word, out int len)
    {
        // Разбор строки на отдельные столбцы. 
        word = ((NameRow)row).word;
        len = ((NameRow)row).len;
    }
}

public class NameRow
{
    public SqlString word;
    public Int32 len;

    public NameRow(SqlString c, Int32 i)
    {
        word = c;
        len = i;
    }
}

