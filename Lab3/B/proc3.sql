USE TitanicDB
GO
-- Объявляем переменную
DECLARE @TableName varchar(255)
-- Объявляем курсор
DECLARE TableCursor CURSOR FOR
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
-- Открываем курсор и выполняем извлечение первой записи 
OPEN TableCursor
FETCH NEXT FROM TableCursor INTO @TableName
-- Проходим в цикле все записи из множества
WHILE @@FETCH_STATUS = 0
BEGIN
   PRINT @TableName
FETCH NEXT FROM TableCursor INTO @TableName END
-- Убираем за собой «хвосты»
CLOSE TableCursor
DEALLOCATE TableCursor