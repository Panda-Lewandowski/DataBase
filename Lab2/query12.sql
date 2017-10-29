-- #12 Instruction SELECT using subqueries in from
-- Rich foreingners
SELECT T.Passenger, T.Fare
FROM T JOIN 
    (
    SELECT PTS.Passenger, PTS.PassengerId
    FROM PTS 
    WHERE Passenger NOT LIKE '%Mr.%' 
    INTERSECT
    SELECT PTS.Passenger, PTS.PassengerId
    FROM PTS 
    WHERE Passenger NOT LIKE '%Mrs.%'
    INTERSECT
    SELECT PTS.Passenger, PTS.PassengerId
    FROM PTS 
    WHERE Passenger NOT LIKE '%Miss.%'  
        INTERSECT
    SELECT PTS.Passenger, PTS.PassengerId
    FROM PTS 
    WHERE Passenger NOT LIKE '%Dr.%'
    ) AS Foreigners ON Foreigners.Passenger = T.Passenger
WHERE T.Class < 3