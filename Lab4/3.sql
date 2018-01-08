CREATE ASSEMBLY SqlServerUDF
FROM 'SqlServerUDF/SqlServerUDF/bin/Debug/SqlServerUDF.dll'
GO

CREATE FUNCTION StrLen ( @InputName NVARCHAR(4000) )
RETURNS TABLE 
(
   word NVARCHAR(4000), 
   len INT
)
AS
EXTERNAL NAME
SqlServerUDF.[SqlServerUDF].StrLen 
GO

SELECT * FROM dbo.StrLen ('Hello')
GO

DROP FUNCTION StrLen

DROP ASSEMBLY SqlServerUDF
