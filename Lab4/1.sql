sp_configure 'show advanced options', 1
GO
RECONFIGURE
GO
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO


CREATE ASSEMBLY SqlServerUDF
AUTHORIZATION dbo
FROM 'SqlServerUDF/SqlServerUDF/bin/Debug/SqlServerUDF.dll'
WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION GetRandomNumber ()
RETURNS INT
AS
EXTERNAL NAME
SqlServerUDF.[SqlServerUDF].GetRandomNumber
GO

SELECT dbo.GetRandomNumber() AS RandomNumber
GO