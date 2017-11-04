-- #24 Instruction PIVOT
SELECT Persons AS 'Persons/Class', [1], [2], [3]
FROM
(
    SELECT Passenger, Class, Persons
    FROM T
) AS SourceTable
PIVOT
(
COUNT(Passenger)
FOR Class IN ([1], [2], [3])
) AS PivotTable