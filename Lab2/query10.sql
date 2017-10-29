-- #10 Instruction SELECT using Search Case
-- Sorting tickets by fare
SELECT TicketId, Class, Fare,
	CASE
		WHEN Fare < 10 THEN 'Inexpensive'
		WHEN Fare < 50 THEN 'Fair'
		WHEN Fare < 100 THEN 'Expensive'
		ELSE 'Very Expensive'
	END AS Price
FROM T
ORDER BY Class