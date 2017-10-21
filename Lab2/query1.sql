-- #1 Instruction SELECT using comparison predicate
-- Less than 16 y.o. girls
SELECT Passenger, Age
FROM P 
WHERE Age < 16 AND Sex = 'female'
ORDER BY Age ASC 
