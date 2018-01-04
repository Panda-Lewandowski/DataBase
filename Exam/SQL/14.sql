-- Создать хранимую процедуру с выходным параметром, которая уничтожает все 
-- представления в текущей базе данных, которые не были зашифрованы. 
-- Выходной параметр возвращает количество уничтоженных представлений. 
-- Созданную хранимую процедуру протестировать.

IF OBJECT_ID(N'dbo.DROP_VIEWS',N'P') IS NOT NULL
      DROP PROCEDURE dbo.DROP_VIEWS;
GO

CREATE PROCEDURE dbo.DROP_VIEWS @cnt int OUTPUT
AS BEGIN
    DECLARE @view_name nvarchar(128), @SQLString nvarchar(1000);
    SET @cnt = 0;
    IF NOT EXISTS(SELECT 1 FROM sys.objects WHERE type='V'
        AND SCHEMA_NAME(schema_id)='dbo')
        RETURN;
    DECLARE view_list CURSOR FORWARD_ONLY STATIC FOR
        SELECT name FROM sys.objects WHERE type='V'
        AND SCHEMA_NAME(schema_id)='dbo';

    OPEN view_list
    FETCH NEXT FROM view_list INTO @view_name
    WHILE @@FETCH_STATUS= 0
    BEGIN
        SET @cnt = @cnt+1;
        SET @SQLString =N'IF OBJECT_ID(N''[dbo].['+@view_name+']'', ''V'') IS NOT NULL DROP VIEW [dbo].['+@view_name+'];'
        EXEC ( @SQLString );
        FETCH NEXT FROM view_list INTO @view_name;
    END
        CLOSE view_list;
        DEALLOCATE view_list;
END
GO

CREATE VIEW dbo.vw_1
AS
      SELECT'Hello world!' AS [Hello world!]
GO

CREATE VIEW dbo.vw_2
AS
      SELECT'Test' AS [Test]
GO

CREATE VIEW dbo.vw_3
AS
      SELECT'No'AS [No]
GO

DECLARE @cnt int
EXEC dbo.DROP_VIEWS @cnt OUTPUT
SELECT @cnt AS Number
GO