SELECT TicketId, Class,
	CASE
		WHEN Fare < 10 THEN 'Inexpensive'
		WHEN Fare < 50 THEN 'Fair'
		WHEN Fare < 100 THEN 'Expensive'
		ELSE 'Very Expensive'
	END AS Price
FROM T