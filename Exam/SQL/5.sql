-- Создать хранимую процедуру с входным параметром – имя таблицы, которая удаляет дубликаты записей 
-- из указанной таблицы в текущей базе данных. Созданную хранимую процедуру протестировать.


IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = N'demodb')
CREATE DATABASE demodb 
GO

USE demodb
GO
IF OBJECT_ID(N'dbo.Employee','U') IS NOT NULL 
    DROP TABLE dbo.Employee
GO

CREATE TABLE dbo.Employee
(
      Id int NOT NULL,
      Name nvarchar(20) NOT NULL,
      Salary decimal NOT NULL
);

GO
INSERT INTO dbo.Employee(Id, Name, Salary)
VALUES  (1,N'Ram', 1000),
        (1,N'Ram', 1000),
        (2,N'Joe', 2000),
        (2,N'Joe', 1000),
        (3,N'Mary', 1000),
        (4,N'Julie', 5000),
        (2,N'Joe', 1000),
        (1,N'Ram', 1000)
GO

-- Хранимая процедура удаления дубликатов (второго или следующих экземпляров) записей из таблицы Employee

CREATE PROCEDURE DelAllDuplicateRecords
AS BEGIN
    DECLARE @id int, @name varchar (20), @cnt int, @salary numeric 
    DECLARE GetAllDuplicateRecords 
    CURSOR LOCAL STATIC FOR 
    SELECT COUNT(*), Id, Name, Salary
    FROM dbo.Employee(NOLOCK)
    GROUP BY Id, Name, Salary
    HAVING COUNT(*) > 1
    OPEN GetAllDuplicateRecords
    FETCH NEXT FROM GetAllDuplicateRecords INTO @cnt, @id, @name, @salary 
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @cnt = @cnt-1
        SET ROWCOUNT @cnt
        DELETE FROM Employee WHERE Id= @id and Name= @name and Salary=@salary 
        SET ROWCOUNT 0
        FETCH NEXT FROM GetAllDuplicateRecords INTO @cnt, @id, @name, @salary
    END
    CLOSE  GetAllDuplicateRecords
    DEALLOCATE  GetAllDuplicateRecords
END
GO
-- Тестирование хранимой процедуры
SELECT Id, Name, Salary FROM dbo.Employee 
ORDER BY Id
GO
EXEC DelAllDuplicateRecords
GO
SELECT Id, Name, Salary FROM dbo.Employee 
ORDER BY Id
GO

USE master
DROP DATABASE demodb
