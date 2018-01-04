-- Создать хранимую процедуру без параметров, которая осуществляет поиск потенциально
-- опасных ключевых слов в хранимых процедурах в текущей базе данных. 

USE master
GO
CREATE PROCEDURE MetadataWorker
AS
BEGIN
    DECLARE @exec_string varchar(40)
    DECLARE[CURSOR]CURSOR
    GLOBAL
    FOR
        SELECT SUBSTRING(sm.definition,CHARINDEX('EXEC',sm.definition, 0), 60)
        FROM sys.sql_modules AS sm JOIN sys.objects AS o ON sm.object_id=o.object_id
        WHERE CHARINDEX('EXEC',sm.definition)<> 0 
                AND OBJECT_NAME(sm.object_id)<>'MetadataWorker' 
                AND o.type='P'
                AND SUBSTRING(sm.definition,CHARINDEX('EXEC',sm.definition, 0), 40)<>'';
    
    OPEN[Cursor];
    FETCH NEXT FROM[CURSOR] INTO @exec_string;
    PRINT CONVERT(varchar,@exec_string);

    CLOSE[Cursor];
    DEALLOCATE[Cursor];
END


EXEC MetadataWorker
GO

--DROP PROCEDURE MetadataWorker
--GO