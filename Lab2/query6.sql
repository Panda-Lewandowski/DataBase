-- #6 Instruction SELECT using comparison predicate with quantor
-- Passengers whose fare for tickets is less than fare from C
SELECT Passenger, Fare, Embarked
FROM T
WHERE T.Fare < ALL(
            SELECT T.Fare
            FROM T 
            WHERE Embarked = 'C'
        )
        
