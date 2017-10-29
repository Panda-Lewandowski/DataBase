-- #11 Instruction SELECT using local temp table
-- Create table with fare for per person
SELECT TicketId, 
        Class, 
        CAST((Fare/Persons)AS money) AS Price
INTO #PricePerTicket
FROM T

--SELECT * FROM #PricePerTicket

--DROP TABLE TitanicDB.dbo.#PricePerTicket GO
