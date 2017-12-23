CREATE ASSEMBLY SqlServerUDF
FROM 'D:\Nick\University\Labs-DB\Lab_4\SqlServerUDF\SqlServerUDF\bin\Debug\SqlServerUDF.dll'
GO

USE dbRobots
GO

CREATE TRIGGER SafeTr
ON Connectivity
INSTEAD OF DELETE
AS
EXTERNAL NAME
SqlServerUDF.[Triggers].SafeTrigger
GO

DELETE dbRobots.dbo.Connectivity
WHERE ID = 1
GO

DROP TRIGGER SafeTr

DROP ASSEMBLY SqlServerUDF
