-- Create a new database called 'TitanicDB'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'TitanicDB'
) 

CREATE DATABASE TitanicDB
GO

USE TitanicDB
GO

-- Create a new table called 'T' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.T', 'U') IS NOT NULL
DROP TABLE dbo.T
GO
-- Create the table in the specified schema
CREATE TABLE dbo.T
(
    TicketId INT NOT NULL, 
    Passenger VARCHAR(85) NOT NULL,
    Fare FLOAT,
    Num INT, 
    Class CHAR,
    Embarked CHAR
);
GO

-- Create a new table called 'S' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.S', 'U') IS NOT NULL
DROP TABLE dbo.S                
GO
-- Create the table in the specified schema
CREATE TABLE dbo.S
(
    PassengerId INT NOT NULL,
    Parch INT,
    SibSp INT
);
GO

-- Create a new table called 'P' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.P', 'U') IS NOT NULL
DROP TABLE dbo.P
GO
-- Create the table in the specified schema
CREATE TABLE dbo.P
(
    Passenger VARCHAR(85) NOT NULL, 
    Sex VARCHAR(6), 
    Age INT
);
GO

-- Create a new table called 'PTS' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.PTS', 'U') IS NOT NULL
DROP TABLE dbo.PTS
GO
-- Create the table in the specified schema
CREATE TABLE dbo.PTS
(
    PassengerId  INT NOT NULL,
    Passenger VARCHAR(85) NOT NULL, 
    TicketId INT NOT NULL, 
    Survival BIT
);
GO


