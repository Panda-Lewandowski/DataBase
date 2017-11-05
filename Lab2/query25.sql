-- #25 Instruction MERGE
WITH Passengers_with_tickets (Passenger, Class, Survival)
AS 
(
    SELECT DISTINCT PTS.Passenger, T.Class, PTS.Survival
    FROM PTS JOIN T ON PTS.TicketId = T.TicketId
)

SELECT * 
from Passengers_with_tickets;

WITH Info_of_Passengers
AS 
( 
    MERGE Passengers_with_tickets AS PT
    USING (
            SELECT *
            FROM P
        ) AS ALLP
    ON PT.Passenger = ALLP.Passenger
)
