USE TitanicDB
GO
IF OBJECT_ID (N'dbo.FromQueenstown', N'FN') IS NOT NULL
    DROP FUNCTION dbo.FromQueenstown
GO

CREATE FUNCTION dbo.FromQueenstown()
RETURNS @Queenstown TABLE 
(
    Passenger VARCHAR(85) NOT NULL, 
    Sex VARCHAR(6), 
    Age INT,
    Survival BIT
)
AS
BEGIN
    INSERT INTO @Queenstown
    SELECT P.Passenger, P.Sex, P.Age, PTS.Survival
    FROM P JOIN PTS ON P.Passenger = PTS.Passenger JOIN T ON PTS.TicketId = T.TicketId
    WHERE T.Embarked = 'Q'
RETURN
END
GO


SELECT *
FROM dbo.FromQueenstown()
