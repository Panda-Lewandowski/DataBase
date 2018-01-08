Create Assembly SqlServerUDF
FROM 'SqlServerUDF/SqlServerUDF/bin/Debug/SqlServerUDF.dll'
GO

CREATE TYPE dbo.Point  
EXTERNAL NAME SqlServerUDF.[Point];
GO

CREATE TABLE dbo.Test
( 
  id INT IDENTITY(1,1) NOT NULL, 
  p Point NULL,
);
GO

-- Testing inserts
-- Correct values 
INSERT INTO dbo.Test(p) VALUES('12,15'); 
INSERT INTO dbo.Test(p) VALUES('1,0'); 
INSERT INTO dbo.Test(p) VALUES('21,8');  
GO 
-- An incorrect value 
INSERT INTO dbo.Test(p) VALUES('a,2');
GO

-- Check the data - byte stream
SELECT * FROM dbo.Test;

SELECT id, p.ToString() AS Point 
FROM dbo.Test;

DECLARE @p1 dbo.Point
SET @p1 = CAST('7,5' AS dbo.Point)
SELECT @p1.Distance() AS 'Distance'
GO
 
DECLARE @p1 dbo.Point, @p2 dbo.Point
SET @p1 = CAST('7,5' AS dbo.Point)
SET @p2 = CAST('7,10' AS dbo.Point)
SELECT @p1.DistanceFrom(@p2) AS 'Distance from point'
GO

DROP TABLE dbo.Test
GO

DROP TYPE Point
GO

DROP ASSEMBLY SqlServerUDF
GO
