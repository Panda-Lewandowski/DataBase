USE TitanicDB
GO
IF OBJECT_ID (N'dbo.AveragePrice', N'FN') IS NOT NULL
    DROP FUNCTION dbo.AveragePrice
GO
CREATE FUNCTION dbo.AveragePrice()
RETURNS smallmoney
WITH SCHEMABINDING
AS
BEGIN
       RETURN (SELECT AVG(Fare) FROM dbo.T)
END
GO

SELECT dbo.AveragePrice()
