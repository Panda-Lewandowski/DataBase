USE TitanicDB
GO

IF OBJECT_ID ( N'dbo.SelectSurvAdultMen', 'P' ) IS NOT NULL
      DROP PROCEDURE dbo.SelectSurvAdultMen
GO

CREATE PROCEDURE dbo.SelectSurvAdultMen
AS
    WITH SurvAdultMen (Passenger)
    AS 
    (
        SELECT PTS.Passenger
        FROM PTS 
        WHERE PTS.Survival = 1

        UNION ALL

        SELECT P.Passenger
        FROM P JOIN SurvAdultMen ON P.Passenger = SurvAdultMen.Passenger
        WHERE P.Sex = 'male' AND P.Age > 18
    )

    SELECT *
    FROM SurvAdultMen

GO