-- #7 Instruction SELECT using aggregate functions
-- Avarage fare for all classes
SELECT AVG(Fare) As 'Fare AVG (Class 1)'
FROM T
WHERE Class = 1
UNION 
SELECT AVG(Fare) As 'Fare AVG (Class 2)'
FROM T
WHERE Class = 2
UNION 
SELECT AVG(Fare) As 'Fare AVG (Class 3)'
FROM T
WHERE Class = 3