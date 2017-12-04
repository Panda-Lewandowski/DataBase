using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


namespace HandWrittenUDF
{
    public class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunctionAttribute]
        public static SqlInt32 GetRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next();
        }
    }
}
