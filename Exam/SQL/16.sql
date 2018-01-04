-- Создать хранимую процедуру с входным параметром – имя таблицы, которая 
-- выводит сведения об индексах указанной таблицы в текущей базе данных. 
-- Созданную хранимую процедуру протестировать.

IF OBJECT_ID('dbo.Metadata','P') IS NOT NULL
    DROP PROCEDURE dbo.Metadata
GO
CREATE PROCEDURE dbo.Metadata @nametable varchar(10)
AS
if(OBJECT_ID(@nametable) is null)
    print'Invalid table!'
else
begin
SELECT sm.object_id AS TableID, OBJECT_NAME(sm.object_id) AS TableName 
 FROM sys.dm_db_index_physical_stats(DB_ID(),OBJECT_ID(@nametable),null,null,null) as sm 
end;
GO
EXEC dbo.Metadata'dbo.PTS'
GO