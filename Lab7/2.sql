-- Create a new table called 'Doctors' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Doctors', 'U') IS NOT NULL
DROP TABLE dbo.Doctors
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Doctors
(
    Doctor_XML  XML (doctors_xsd) NOT NULL,
    Country  VARCHAR(85) NOT NULL, 
    Passport INT PRIMARY KEY IDENTITY(1,1), 
    Add_on VARCHAR(100)
);
GO