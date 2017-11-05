-- #17 Instruction INSERT with many rows
INSERT T (TicketId, Passenger, Fare, Persons, Class, Embarked)
SELECT PTS.TicketId, PTS.Passenger, NULL, 1, NULL, NULL 
    FROM PTS JOIN T ON PTS.TicketId = T.TicketId
    WHERE PTS.Passenger != T.Passenger

