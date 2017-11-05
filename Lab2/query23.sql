-- #22 Instruction SELECT using recursion сommon table expression
-- Finding survival man who is more than 18 years old and survived
-- Для составления запроса с использованием рекурсивного обобщенного 
-- табличного выражения требуется модифицировать одну из таблиц таким образом, 
-- чтобы в этой таблице был определен внешний ключ, ссылающийся на саму таблицу.

--ALTER TABLE dbo.P ADD
--CONSTRAINT PK_P_P PRIMARY KEY CLUSTERED (Passenger ASC)
--GO

WITH SurvAdultMen (Passenger)
AS 
(
    SELECT PTS.Passenger
    FROM PTS 
    WHERE PTS.Survival = 1

    UNION ALL

    SELECT P.Passenger
    FROM P JOIN SurvAdultMen ON P.Passenger = SurvAdultMen.Passenger
    WHERE P.Sex = 'male' AND P.Age > 18
)

SELECT *
FROM SurvAdultMen