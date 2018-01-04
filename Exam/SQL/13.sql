-- Создать хранимую процедуру с выходным параметром, которая выводит
-- список имен и параметров всех скалярных SQL функций пользователя 
-- (функции типа 'FN') в текущей базе данных. Имена функций без параметров 
-- не выводить. Имена и список параметров должны выводиться в одну строку. 
-- Выходной параметр возвращает количество найденных функций. 
-- Созданную хранимую процедуру протестировать.

IF OBJECT_ID ( N'dbo.ScalarFunc', 'P' ) IS NOT NULL
      DROP PROCEDURE dbo.ScalarFunc
GO
CREATE PROCEDURE ScalarFunc @Amount INT OUTPUT AS
BEGIN
    DECLARE @funcname varchar(200), @Par varchar(200); SET NOCOUNT ON;
    DECLARE funcName_Cursor CURSOR FOR

    SELECT DISTINCT sys.objects.object_id
    FROM sys.objects JOIN sys.parameters ON sys.objects.object_id = sys.parameters.object_id
    WHERE [type] = 'FN'
    --ORDER BY sys.objects.name;

    --SELECT *
    --FROM sys.parameters 

    SET @Amount = 0

    OPEN funcName_Cursor;
    FETCH NEXT FROM funcName_Cursor INTO @funcname;
    WHILE @@FETCH_STATUS = 0
    BEGIN

    SET @Par = (SELECT COUNT(name) FROM sys.parameters WHERE sys.parameters.object_id = @funcname)

    IF (@Par != 0)
    BEGIN
        SELECT DISTINCT sys.objects.name AS 'Имя функции', sys.parameters.name AS 'Параметры' 
        FROM sys.objects JOIN sys.parameters ON sys.objects.object_id = sys.parameters.object_id
        WHERE sys.objects.object_id = @funcname
    END
    SET @Amount = @Amount + 1

    FETCH NEXT FROM funcName_Cursor INTO @funcname; 
    END;

    CLOSE funcName_Cursor;
    DEALLOCATE funcName_Cursor;
END;
GO

DECLARE @OutParm INT
EXECUTE ScalarFunc @OutParm OUTPUT;
SELECT @OutParm "Количество функций"
GO