-- Создать хранимую процедуру с выходным параметром, которая выводит текст 
-- на языке SQL всех скалярных SQL функций пользователя (функции типа 'FN') 
-- в текущей базе данных, имена которых начинаются с префикса 'ufn'. Выходной параметр 
-- возвращает количество найденных функций. Созданную хранимую процедуру протестировать.

USE master
GO

CREATE PROCEDURE Dropper_ufn @count INT OUT
WITH RECOMPILE
AS
BEGIN
SELECT sm.definition as Def
FROM sys.objects AS o
JOIN sys.sql_modules AS sm ON sm.object_id = o.object_id
WHERE o.type = 'FN' AND o.name LIKE 'ufn%'; 
SET @count = @@ROWCOUNT;
END
GO

DECLARE @c int;
EXEC Dropper_ufn @c OUT;
PRINT @c; 
GO