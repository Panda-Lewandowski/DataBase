-- #15 Instruction SELECT using HAVING
-- Women whose age is more than avarage one
SELECT Passenger
FROM P
WHERE Sex = 'female' AND Age IS NOT NULL
GROUP BY Passenger
HAVING AVG(Age) > 
(
		SELECT AVG(Age)
		FROM P
	)
