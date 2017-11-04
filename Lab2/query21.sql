-- #21 Instruction DELETE using subqueries in where
-- DELETE information about relatives if passenger is survived
DELETE FROM S
WHERE S.PassengerId IN (
    SELECT PTS.PassengerId
    FROM PTS
    WHERE PTS.Survival = 1
)
