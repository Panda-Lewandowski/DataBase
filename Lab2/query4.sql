-- #4 Instruction SELECT using IN predicate with nested subquery
-- Survived people from Queenstown
SELECT Passenger, TicketId 
FROM PTS
WHERE TicketId IN (
    SELECT TicketId
    FROM T
    WHERE Embarked = 'Q' 
    ) AND Survival = 1

