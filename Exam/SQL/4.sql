-- Создать хранимую процедуру с двумя входными параметрами – имя базы данных и имя таблицы, 
-- которая выводит сведения об индексах указанной таблицы в указанной базе данных.
-- Созданную хранимую процедуру протестировать.

-- Создаем хранимую процедуру получения сведений об индексах
IF OBJECT_ID(N'dbo.GetInfoAboutIndex','P') IS NOT NULL
      DROP PROCEDURE dbo.GetInfoAboutIndex;
GO

CREATE PROCEDURE dbo.GetInfoAboutIndex @dbname nvarchar(50), @tblname nvarchar(50) AS
BEGIN
    DECLARE @db_id int
    DECLARE @object_id int
    SET @db_id = DB_ID(@dbname)
    IF @db_id IS NULL
    BEGIN
        PRINT N'Invalid database'
        RETURN
    END

    SET @object_id = OBJECT_ID(@dbname+'.'+@tblname,'U')
    IF @object_id IS NULL
    BEGIN
        PRINT N'Invalid object'
        RETURN
    END

    SELECT * 
    FROM sys.dm_db_index_physical_stats(@db_id, @object_id, NULL, NULL, NULL);
    END
GO


-- Проверяем хранимую процедуру на четырех примерах
EXEC GetInfoAboutIndex @dbname=N'Family', @tblname=N'dbo.Person'
EXEC GetInfoAboutIndex @dbname=N'Family', @tblname=N'dbo.Orders'
EXEC GetInfoAboutIndex @dbname=N'Northwint', @tblname=N'dbo.Orders'
GO