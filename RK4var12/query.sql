USE tempdb;
GO

CREATE TABLE Customer
(
	CustomerID nchar(5) NOT NULL PRIMARY KEY,
	CompanyName nvarchar(40) NOT NULL,
	CreditLimit money NULL
);

GO

/*DROP FUNCTION dbo.CustomerIDDependency;
GO*/

CREATE FUNCTION CustomerIDDependency(@id nchar(5))
RETURNS money
BEGIN
	RETURN DATALENGTH(@id) * 10 + CONVERT(int, SUBSTRING(@id, 1, 1));
END
GO

/*DROP TRIGGER CustomerTrigger;
GO*/

CREATE TRIGGER CustomerTrigger
ON Customer
AFTER INSERT
AS
	DECLARE @count int = (SELECT COUNT(*) FROM INSERTED);
	IF @count = 1
	BEGIN		
		UPDATE Customer SET CreditLimit = 1000 WHERE CustomerID = (SELECT CustomerID FROM INSERTED)
	END
	ELSE
	BEGIN
		UPDATE Customer SET CreditLimit = dbo.CustomerIDDependency(CustomerID) WHERE CustomerID IN (SELECT CustomerID FROM INSERTED)
	END
GO

/*INSERT INTO Customer VALUES (N'1', 'TestCompany', 100), (N'2', 'AnotherCompany', 200)*/