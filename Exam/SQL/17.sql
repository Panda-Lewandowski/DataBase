-- Создать хранимую процедуру с входным параметром, которая выводит имена хранимых
-- процедур, созданных с параметром WITH RECOMPILE, в тексте которых на языке
--  SQL встречается строка, задаваемая параметром процедуры. Созданную хранимую процедуру протестировать.

CREATE PROCEDURE TextChecker @TextToCheck NVARCHAR(20)
WITH RECOMPILE
AS
SELECT sm.object_id AS ProcedureID,OBJECT_NAME(sm.object_id) AS ProcedureName
FROM sys.sql_modules AS sm
       JOIN sys.objects AS o ON sm.object_id=o.object_id
WHERE sm.is_recompiled= 1 AND sm.definition LIKE '%' + @TextToCheck+ '%'

EXEC TextChecker 'SELECT sm.object_id'
GO
EXEC TextChecker  'SEasdasd'
GO
