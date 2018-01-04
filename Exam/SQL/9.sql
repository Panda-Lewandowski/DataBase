-- Создать хранимую процедуру с выходным параметром, которая уничтожает все 
-- SQL DDL триггеры (триггеры типа 'TR') в текущей базе данных.
-- Выходной параметр возвращает количество уничтоженных триггеров. 
-- Созданную хранимую процедуру протестировать.

USE master
GO
IF DB_ID(N'sample_db') IS NOT NULL 
    DROP DATABASE sample_db
GO

CREATE DATABASE sample_db
GO

USE sample_db
GO

IF OBJECT_ID('dbo.sample_table','U') IS NOT NULL 
    DROP TABLE dbo.sample_table GO
CREATE TABLE dbo.sample_table
(
      c1 int NOT NULL IDENTITY(1,1),
      c2 char(10) NULL,
      c3 datetime NULL
CONSTRAINT PK_sample_table PRIMARY KEY (c1) )
GO

INSERT INTO dbo.sample_table(c2, c3)
VALUES ('qwe',GETDATE()),('asd',GETDATE()),('zxc',GETDATE())
GO

IF OBJECT_ID('dbo.insert_trigger','TR') IS NOT NULL 
    DROP TRIGGER dbo.insert_trigger 
GO

CREATE TRIGGER dbo.insert_trigger ON dbo.sample_table AFTER INSERT 
AS
      PRINT'INSERT TRIGGER'
GO

IF OBJECT_ID('dbo.update_trigger','TR') IS NOT NULL 
    DROP TRIGGER dbo.update_trigger 
GO

CREATE TRIGGER dbo.update_trigger ON dbo.sample_table AFTER UPDATE
AS
    PRINT'UPDATE TRIGGER'
GO

IF OBJECT_ID('dbo.delete_trigger','TR') IS NOT NULL 
    DROP TRIGGER dbo.delete_trigger 
GO

CREATE TRIGGER dbo.delete_trigger ON dbo.sample_table AFTER DELETE
AS
      PRINT'DELETE TRIGGER'
GO

IF EXISTS(SELECT * FROM sys.triggers 
        WHERE parent_class = 0 
             AND name ='trigger_table') 
    DROP TRIGGER trigger_table ON DATABASE
GO

CREATE TRIGGER trigger_table ON DATABASE FOR DROP_TABLE, ALTER_TABLE AS
    PRINT'You must disable "trigger_table" to drop or alter tables!'
    ROLLBACK; 
GO

IF EXISTS(SELECT * FROM sys.triggers
        WHERE parent_class = 0 
            AND name ='trigger_index') 
    DROP TRIGGER trigger_index ON DATABASE
GO

CREATE TRIGGER trigger_index ON DATABASE FOR DROP_INDEX, ALTER_INDEX AS
    PRINT'You must disable "trigger_index" to drop or alter indexes!'
    ROLLBACK; 
GO

IF OBJECT_ID('dbo.drop_all_SQL_DDL_triggers','P') IS NOT NULL
    DROP PROCEDURE dbo.drop_all_SQL_DDL_triggers 
GO

CREATE PROCEDURE drop_all_SQL_DDL_triggers @cnt int OUTPUT 
AS
BEGIN
    DECLARE @trigger_name nvarchar(255), @SqlString nvarchar(1000) 
    SET @cnt = 0
    IF NOT EXISTS(SELECT * FROM sys.triggers 
                    WHERE parent_class = 0)
        RETURN
    DECLARE trigger_list 
    CURSOR FORWARD_ONLY STATIC FOR 
    SELECT name FROM sys.triggers WHERE parent_class = 0 
    OPEN trigger_list
    FETCH NEXT FROM trigger_list into @trigger_name 
    WHILE @@FETCH_STATUS= 0
    BEGIN
        SET @cnt = @cnt+1
        SET @SqlString =N'DROP TRIGGER '+@trigger_name+N' ON DATABASE';
        EXEC (@SqlString)
        FETCH NEXT FROM trigger_list into @trigger_name
        END
        CLOSE trigger_list
        DEALLOCATE trigger_list
END 
GO

SELECT * FROM sys.triggers
GO
DECLARE @cnt int
EXEC drop_all_SQL_DDL_triggers @cnt OUTPUT
SELECT @cnt
GO
SELECT * FROM sys.triggers
GO

USE master
DROP DATABASE sample_db
GO