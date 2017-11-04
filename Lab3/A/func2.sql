USE TitanicDB
GO
IF OBJECT_ID (N'dbo.Survival', N'FN') IS NOT NULL
    DROP FUNCTION dbo.Survival
GO

CREATE FUNCTION dbo.Survival()
RETURNS TABLE
AS
RETURN (
    SELECT PTS.PassengerId, PTS.Passenger, P.Age, P.Sex, PTS.TicketId
    FROM P JOIN PTS ON P.Passenger = PTS.Passenger
    WHERE PTS.Survival = 1
    )
GO


SELECT *
FROM dbo.Survival()
GO
