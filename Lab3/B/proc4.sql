IF OBJECT_ID ( N'dbo.ScalarFunc', 'P' ) IS NOT NULL
      DROP PROCEDURE dbo.ScalarFunc
GO
CREATE PROCEDURE ScalarFunc @Amount INT OUTPUT AS
BEGIN
    DECLARE @dbname varchar(200), @mSql1 varchar(8000); SET NOCOUNT ON;
    DECLARE DBName_Cursor CURSOR FOR

    SELECT sys.objects.name
    FROM sys.objects JOIN sys.parameters ON sys.objects.name = sys.parameters.name
    WHERE [type] = 'FN'
    ORDER BY sys.objects.name;

    SET @Amount = 0

    OPEN DBName_Cursor;
    FETCH NEXT FROM DBName_Cursor INTO @dbname;
    WHILE @@FETCH_STATUS = 0
    BEGIN
   
    PRINT @dbname
    SET @Amount = @Amount + 1

    FETCH NEXT FROM DBName_Cursor INTO @dbname; 
    END;

    CLOSE DBName_Cursor;
    DEALLOCATE DBName_Cursor;
END;
GO

DECLARE @OutParm INT
EXECUTE ScalarFunc @OutParm OUTPUT;
SELECT @OutParm "Количество функций"
GO
