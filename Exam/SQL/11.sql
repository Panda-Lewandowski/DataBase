-- Создать хранимую процедуру с выходным параметром,
-- которая уничтожает все SQL функции пользователя (функции типа 'FN', 'IF' и 'TF') 
-- в схеме 'dbo' в текущей базе данных. Выходной параметр возвращает количество уничтоженных функций. 
-- Созданную хранимую процедуру протестировать.

IF OBJECT_ID('dbo.drop_all_SQL_functions','P') IS NOT NULL
      DROP PROCEDURE dbo.drop_all_SQL_functions
GO
CREATE PROCEDURE dbo.drop_all_SQL_functions @cnt int OUTPUT
AS
BEGIN
    DECLARE @function_name nvarchar(255), @SqlString nvarchar(1000) 
    SET @cnt = 0
    DECLARE function_list 
    CURSOR FORWARD_ONLY STATIC FOR
    SELECT name FROM sys.objects WHERE type='FN' OR type='IF' OR type='TF' 
    OPEN function_list
    FETCH NEXT FROM function_list into @function_name
    WHILE @@FETCH_STATUS= 0
    BEGIN
        SET @cnt = @cnt+1
        SET @SqlString = N'IF OBJECT_ID(N''[dbo].['+@function_name+']'', ''FN'') IS NOT NULL
        DROP FUNCTION [dbo].['+@function_name+']'
        EXEC (@SqlString)
        SET @SqlString = N'IF OBJECT_ID(N''[dbo].['+@function_name+']'', ''IF'') IS NOT NULL
        DROP FUNCTION [dbo].['+@function_name+']'
        EXEC (@SqlString)
        SET @SqlString =N'IF OBJECT_ID(N''[dbo].['+@function_name+']'', ''TF'') IS NOT NULL
            DROP FUNCTION [dbo].['+@function_name+']'
        EXEC (@SqlString)
        FETCH NEXT FROM function_list into @function_name
    END
    CLOSE function_list
    DEALLOCATE function_list
END
GO

SELECT* FROM sys.sql_modules
GO
DECLARE @cnt int
EXEC dbo.drop_all_SQL_functions @cnt OUTPUT
SELECT @cnt
GO
SELECT* FROM sys.sql_modules
GO