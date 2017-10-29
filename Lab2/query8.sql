-- #8 Instruction SELECT using scalar subquery in columns
-- It's no meaning 
SELECT	PassengerId,
	  (
		SELECT AVG(T.Fare/T.Persons)
		FROM T
		WHERE T.TicketId = PTS.TicketId 
    ) AS AVGFare,
PTS.Passenger
FROM PTS JOIN T ON  T.TicketId = PTS.TicketId
WHERE Survival = 0
ORDER BY AVGFare DESC