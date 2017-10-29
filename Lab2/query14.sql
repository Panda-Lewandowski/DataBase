-- #14 Instruction SELECT using GROUP BY
-- Info about ticket
SELECT Class,
    AVG(T.Fare) AS AVGPrice, 
    MAX(T.Fare) AS MAXPrice, 
    MAX(T.Persons) AS MAXPerson
FROM T
GROUP BY T.Class


