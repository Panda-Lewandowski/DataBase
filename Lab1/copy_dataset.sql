BULK INSERT TitanicDB.dbo.P
FROM '/home/parallels/Desktop/p.csv'
WITH (DATAFILETYPE = 'char', FIRSTROW = 2, FIELDTERMINATOR = ',', ROWTERMINATOR = '0x0a');
GO 

BULK INSERT TitanicDB.dbo.S
FROM '/home/parallels/Desktop/s.csv'
WITH (DATAFILETYPE = 'char', FIRSTROW = 2, FIELDTERMINATOR = ',', ROWTERMINATOR = '0x0a');
GO 

BULK INSERT TitanicDB.dbo.T
FROM '/home/parallels/Desktop/t.csv'
WITH (DATAFILETYPE = 'char', FIRSTROW = 2, FIELDTERMINATOR = ',', ROWTERMINATOR = '0x0a');
GO 

BULK INSERT TitanicDB.dbo.PTS
FROM '/home/parallels/Desktop/pts.csv'
WITH (DATAFILETYPE = 'char', FIRSTROW = 2, FIELDTERMINATOR = ',', ROWTERMINATOR = '0x0a');
GO 
