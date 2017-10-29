SELECT	PassengerId,
	(
		SELECT AVG(T.Fare)
		FROM T
		WHERE T.TicketId = PTS.TicketId
    ) AS AvgFare,
    (
		SELECT MAX(T.Fare)
		FROM T
		WHERE T.TicketId = PTS.TicketId
    ) AS MaxFare,
PTS.Passenger
FROM PTS JOIN T ON  T.TicketId = PTS.TicketId
WHERE Survival = 0