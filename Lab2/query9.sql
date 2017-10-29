SELECT PTS.Passenger,
	CASE (S.Parch + S.SibSp)
    WHEN 0 THEN 'Without relatives'
    ELSE (S.Parch + S.SibSp) + ' relatives'
	END AS 'Relatives'
FROM S JOIN PTS ON S.PassengerId = PTS.PassengerId
