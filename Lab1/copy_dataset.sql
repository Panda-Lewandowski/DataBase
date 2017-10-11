BULK INSERT TitanicDB.dbo.P
FROM '/Users/pandas/Documents/University/DataBase/DataBase/Lab1/data/p.txt'
WITH (DATAFILETYPE = 'char', FIELDTERMINATOR = '\t', ROWTERMINATOR = '\n');
GO 

BULK INSERT TitanicDB.dbo.T
FROM '/Users/pandas/Documents/University/DataBase/DataBase/Lab1/data/t.txt'
WITH (DATAFILETYPE = 'char', FIELDTERMINATOR = '\t', ROWTERMINATOR = '\n');
GO 

BULK INSERT TitanicDB.dbo.S
FROM '/Users/pandas/Documents/University/DataBase/DataBase/Lab1/data/s.txt'
WITH (DATAFILETYPE = 'char', FIELDTERMINATOR = '\t', ROWTERMINATOR = '\n');
GO 

BULK INSERT TitanicDB.dbo.PTS
FROM '/Users/pandas/Documents/University/DataBase/DataBase/Lab1/data/p.txt'
WITH (DATAFILETYPE = 'char', FIELDTERMINATOR = '\t', ROWTERMINATOR = '\n');
GO 