-- #22 Instruction SELECT using сommon table expression
-- Finding survival man who is more than 18 years old and survived
WITH SurvMen (PassengerId, Passenger, Age, Survival)
AS 
(
    SELECT PTS.PassengerId, PTS.Passenger, P.Age, PTS.Survival
    FROM PTS JOIN P ON P.Passenger = PTS.Passenger
    WHERE P.Sex = 'male' AND P.Age IS NOT NULL
)
SELECT Passenger, Age, Survival
FROM SurvMen
WHERE Survival = 1 AND Age > 18