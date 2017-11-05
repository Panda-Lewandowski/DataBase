USE TitanicDB
GO

IF OBJECT_ID ( N'dbo.SelectWomen', 'P' ) IS NOT NULL
      DROP PROCEDURE dbo.SelectWomen
GO
CREATE PROCEDURE dbo.SelectWomen @Amount INT OUTPUT AS
BEGIN
      SELECT P.Passenger, Age, TicketId, Survival
      FROM P JOIN PTS ON P.Passenger = PTS.Passenger
      WHERE P.Sex = 'female'

      SET @Amount = @@ROWCOUNT
      RETURN (SELECT AVG(Age) from p)
END
GO

DECLARE @OutParm INT, @RetVal INT
EXEC @RetVal = dbo.SelectWomen @OutParm OUTPUT
SELECT @OutParm "Количество женщин", @RetVal "Средний возраст" 
GO
