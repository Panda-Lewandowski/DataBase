-- #15 Instruction SELECT using HAVING
-- Women wose age is more than another's age
SELECT Passenger
FROM P
WHERE Sex = 'female' AND Age IS NOT NULL
GROUP BY Passenger
HAVING AVG(Age) > 
(
		SELECT AVG(Age)
		FROM P
	)
