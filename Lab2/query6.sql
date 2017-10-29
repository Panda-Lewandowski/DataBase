-- #1 Instruction SELECT using comparison predicate with quantor
SELECT Passenger, Fare, Embarked
FROM T
WHERE T.Fare < ALL(
            SELECT T.Fare
            FROM T 
            WHERE Embarked = 'C'
        )
        
