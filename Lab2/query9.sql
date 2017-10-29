-- #9 Instruction SELECT using simple CASE
-- Check number of relatives
SELECT PTS.Passenger,
	CASE (S.Parch + S.SibSp)
    WHEN 0 THEN 'Without relatives'
    ELSE CAST((S.Parch + S.SibSp) AS varchar(5))+ ' relatives'
	END AS 'Relatives'
FROM S JOIN PTS ON S.PassengerId = PTS.PassengerId
