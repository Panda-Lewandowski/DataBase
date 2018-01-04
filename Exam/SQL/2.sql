-- Создать хранимую процедуру, которая, не уничтожая базу данных, уничтожает все 
-- те таблицы текущей базы данных в схеме 'dbo', имена которых начинаются с префикса, 
-- указываемого параметром процедуры. Созданную хранимую процедуру протестировать.

CREATE PROCEDURE usp_02 @param VARCHAR(150) AS
BEGIN
    DECLARE @tname VARCHAR(150)
    DECLARE @strsql VARCHAR(300)
    SELECT @tname = (SELECT TOP 1 [name] 
    FROM sys.objects 
    WHERE [type] = 'U' and [name] like @param + '%' 
    ORDER BY[name]) 

    WHILE @tname IS NOT NULL
    BEGIN
        SELECT @strsql ='DROP TABLE [dbo].['+ RTRIM(@tname) +']'; 
        EXEC (@strsql);
        PRINT'Dropped Table : '+ @tname ; 
        SELECT @tname= ( SELECT TOP 1 [name]
        FROM sys.objects 
        WHERE [type] ='U' AND [name] LIKE @param +'%' AND [name] > @tname 
        ORDER BY[name ]);
    END; 
END;
GO

CREATE TABLE TableNameXXX (c1 int);
GO 
CREATE TABLE TableNameYYY (c1 float); 
GO 
CREATE TABLE TableNameZZZ (c1 char(2));
 GO
EXEC usp_02 @param ='TableName';
GO


