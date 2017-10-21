-- #3 Instruction SELECT using LIKE predicate 
-- Doctors with families
SELECT DISTINCT PTS.Passenger, S.SibSp, S.Parch
FROM PTS JOIN S ON S.PassengerId = PTS.PassengerId
WHERE Passenger LIKE '%Dr.%'
