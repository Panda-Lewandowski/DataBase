sp_configure 'show advanced options', 1
GO
RECONFIGURE
GO
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

USE dbRobots
GO

CREATE ASSEMBLY SqlServerUDF
--AUTHORIZATION dbo
FROM 'D:\Nick\University\Labs-DB\Lab_4\SqlServerUDF\SqlServerUDF\bin\Debug\SqlServerUDF.dll'
GO

CREATE AGGREGATE CountChet( @instr int )
RETURNS INT
EXTERNAL NAME
SqlServerUDF.[Chet]
GO

SELECT dbo.CountChet(WorkingStaffNum) AS ChetStaffNum
FROM dbo.Company
GO

DROP AGGREGATE CountChet

DROP ASSEMBLY SqlServerUDF