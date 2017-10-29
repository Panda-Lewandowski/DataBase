-- #18 Instruction UPDATE
-- Discount for big families
UPDATE T
SET Fare = Fare - 10
WHERE Persons > 3