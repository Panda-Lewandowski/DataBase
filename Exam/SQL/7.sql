-- Создать хранимую процедуру без параметров, которая в текущей базе данных обновляет 
-- все статистики для таблиц в схеме 'dbo'. 
-- Созданную хранимую процедуру протестировать.

USE master
GO
CREATE PROCEDURE UPDATE_STATISTICS
AS
BEGIN
    DECLARE @tablename varchar(255), @tablename_header varchar(600), @sql varchar(600) 
    DECLARE tnames_cursor 
    CURSOR FOR
    SELECT'tablename'=o.name
    FROM sys.objects o
    WHERE o.type='U'AND o.principal_id IS NULL
    OPEN tnames_cursor
    FETCH NEXT FROM tnames_cursor INTO @tablename

    WHILE (@@fetch_status <> -1)
    BEGIN
        IF (@@fetch_status<>-2)
        BEGIN
            SELECT @tablename_header ='*** Updating'+ rtrim(upper(@tablename))+ '('+convert(varchar,getdate(), 20)+') ***' 
            PRINT @tablename_header
            SELECT @sql ='UPDATE STATISTICS '+'dbo.'+ @tablename
            EXEC ( @sql )
        END
        FETCH NEXT FROM tnames_cursor INTO @tablename
    END
    PRINT'*** Statistics has been updated for all tables ('+convert(varchar,getdate(),20)+') ***'
    CLOSE tnames_cursor
    DEALLOCATE tnames_cursor
END
GO

EXEC UPDATE_STATISTICS
GO
