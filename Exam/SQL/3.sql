-- Создать хранимую процедуру с входным параметром, которая выводит имена и описания 
-- типа объектов (только хранимых процедур и скалярных функций), в тексте которых на языке 
-- SQL встречается строка, задаваемая параметром процедуры. Созданную хранимую процедуру протестировать.

IF OBJECT_ID('dbo.search_procedure','P') IS NOT NULL
      DROP PROCEDURE dbo.search_procedure
GO

-- Создание хранимой процедуры
CREATE PROCEDURE dbo.search_procedure @search_text nvarchar(100)
AS
BEGIN
    DECLARE @sql_string nvarchar(1000)
    SET @sql_string =
    'SELECT DISTINCT o.name AS [Name], o.type_desc AS [Description]
    FROM sys.sql_modules m INNER JOIN sys.objects o ON m.object_id=o.object_id
    WHERE m.definition LIKE ''%'+ @search_text + '%'' AND (o.type=''P'' OR o.type=''FN'')' 
    EXEC( @sql_string)
END 
GO

-- Тестирование хранимой процедуры
EXEC dbo.search_procedure @search_text = N'XML'