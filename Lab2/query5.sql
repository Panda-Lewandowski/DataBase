-- #5 Instruction SELECT using EXIST predicate with nested subquery
-- Passengers with unknown age
--SELECT P.Passenger
--FROM P
--WHERE EXISTS (
    SELECT T.Passenger
    FROM T LEFT OUTER JOIN P 
    ON T.Passenger = P.Passenger
    WHERE P.Age IS NULL
--)

