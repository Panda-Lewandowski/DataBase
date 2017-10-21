-- #2 Instruction SELECT using BETWEEN predicate 
-- Passenger who paid more than 50 dollars 
SELECT DISTINCT Passenger, Class
FROM T
WHERE Fare/T.Persons BETWEEN 50.0 AND 200.0
ORDER BY Class