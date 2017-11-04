-- #13 Instruction SELECT using subqueries in from
-- Survived underage girls without relatieves on a board
SELECT UnderageGirls.Passenger, UnderageGirls.TicketId
FROM (
        SELECT Survivors.Passenger, Survivors.TicketId, S.Parch
        FROM ( 
                SELECT PTS.PassengerId, PTS.Passenger, PTS.TicketId, P.Age, p.Sex
                FROM PTS JOIN P ON PTS.Passenger = P.Passenger 
                WHERE PTS.Survival = 1
        ) AS  Survivors
        JOIN S ON S.PassengerId = Survivors.PassengerId
        WHERE Survivors.Age < 16 AND Survivors.Sex = 'female'
    ) AS UnderageGirls
WHERE UnderageGirls.Parch = 0