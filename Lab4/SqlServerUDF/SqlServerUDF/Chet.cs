using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.UserDefined, MaxByteSize = 8000)]
public struct Chet : IBinarySerialize
{
    private int count;

    public void Init()
    {
        count = 0;
    }

    public void Accumulate(SqlInt32 Value)
    {
        if (Value % 2 == 0)
            count++;
    }

    public void Merge (Chet Group)
    {
        count += Group.count;
    }

    public SqlInt32 Terminate ()
    {
        return new SqlInt32(count);
    }

    #region IBinarySerialize Members

    public void Read(System.IO.BinaryReader r)
    {
        count = r.ReadInt32();
    }

    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(count);
    }

    #endregion
}
