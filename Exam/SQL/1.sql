-- Создать и протестировать хранимую процедуру T-SQL, 
-- в которой для экземпляра SQLServer создаются резервные 
-- копии всех пользовательских баз данных. Имя файла резервной копии 
-- должно состоять из имени базы данных и даты создания резервной копии, разделенных 
-- символом нижнего подчеркивания. Дата создания резервной копии должна быть представлена 
-- в формате YYYYDDMM.

CREATE PROCEDURE usp_01 @path VARCHAR(256) AS
BEGIN
    DECLARE @name VARCHAR(50) -- имя базы данных
    DECLARE @fileName VARCHAR(256) -- полная спецификация файла 
    DECLARE @fileDate VARCHAR(20) -- часть имени backup-файла, содержащая дату его создания
    SELECT @fileDate = CONVERT(VARCHAR(20),GETDATE(),112) 
    DECLARE db_cursor CURSOR FOR
    SELECT name
    FROM sys.databases
    WHERE name NOT IN('master','model','msdb','tempdb')

    OPEN db_cursor
    FETCH NEXT FROM db_cursor INTO @name
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @fileName = @path + @name + '_'+ @fileDate + '.BAK' 
        BACKUP DATABASE @name TO DISK = @fileName 
        FETCH NEXT FROM db_cursor INTO @name
    END
    CLOSE db_cursor
    DEALLOCATE db_cursor
END
GO

EXEC usp_01 @path = 'D:\BACKUP\'
GO