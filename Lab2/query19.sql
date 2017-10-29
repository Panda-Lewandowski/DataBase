-- #19 Instruction UPDATE
-- Discount for big families
UPDATE T
SET Fare = (
    SELECT MIN(Fare)
    FROM T
    WHERE Persons < 5
)
WHERE Persons > 3