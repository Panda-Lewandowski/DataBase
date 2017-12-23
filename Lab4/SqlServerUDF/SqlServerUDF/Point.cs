using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native, IsByteOrdered = true)]
public struct Point : INullable
{
    private bool is_Null;
    private Int32 _x;
    private Int32 _y;

    public bool IsNull
    {
        get
        {
            return (is_Null);
        }
    }

    public static Point Null
    {
        get
        {
            Point pt = new Point();
            pt.is_Null = true;
            return pt;
        }
    }
  
    public override string ToString()
    {
        if (this.IsNull)
            return "NULL";
        else
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_x);
            builder.Append(", ");
            builder.Append(_y);
            return builder.ToString();
        }
    }

    [SqlMethod(OnNullCall = false)]
    public static Point Parse(SqlString s)
    { 
        if (s.IsNull)
            return Null;
  
        Point pt = new Point();
        string[] xy = s.Value.Split(",".ToCharArray());
        pt.x = Int32.Parse(xy[0]);
        pt.y = Int32.Parse(xy[1]);

        return pt;
    }
  
    public Int32 x
    {
        get
        {
            return this._x;
        }

        set
        {
            _x = value;
        }
    }

    public Int32 y
    {
        get
        {
            return this._y;
        }

        set
        {
            _y = value;
        }
    }

    [SqlMethod(OnNullCall = false)]
    public Double Distance()
    {
        return DistanceFromXY(0, 0);
    }
  
    [SqlMethod(OnNullCall = false)]
    public Double DistanceFrom(Point pFrom)
    {
        return DistanceFromXY(pFrom.x, pFrom.y);
    }

    [SqlMethod(OnNullCall = false)]
    public Double DistanceFromXY(Int32 iX, Int32 iY)
    {
        return Math.Sqrt(Math.Pow(iX - _x, 2.0) + Math.Pow(iY - _y, 2.0));
    }
}