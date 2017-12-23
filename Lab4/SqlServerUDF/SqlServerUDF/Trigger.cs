using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

public partial class Triggers
{        
    // Введите существующую таблицу или представление для целевого объекта и раскомментируйте строку атрибута.
    // [Microsoft.SqlServer.Server.SqlTrigger (Name="Trigger", Target="Table1", Event="FOR UPDATE")]
    public static void SafeTrigger ()
    {
        SqlTriggerContext triggerContext = SqlContext.TriggerContext;

        if (triggerContext.TriggerAction == TriggerAction.Delete)
            SqlContext.Pipe.Send("You can't delete while safe trigger active! Sorry boi");
    }
}

