Create Assembly SqlServerUDF
FROM 'D:\Nick\University\Labs-DB\Lab_4\SqlServerUDF\SqlServerUDF\bin\Debug\SqlServerUDF.dll'
GO

Create Procedure AvgStuffNum ( @Name NVARCHAR(4000) )
As
External Name
SqlServerUDF.[StoredProcedures].AvgStuffNum
GO

USE dbRobots
GO

EXEC AvgStuffNum 'U.S. Robots'
GO

DROP Procedure AvgStuffNum

DROP ASSEMBLY SqlServerUDF
