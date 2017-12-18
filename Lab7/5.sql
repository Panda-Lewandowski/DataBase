SELECT * from Doctors


SELECT * FROM Doctors
WHERE Doctor_XML.exist('/Passenger[@PassengerId="399"]')=1


SELECT Doctor_XML.value('(/Passenger/Name)[1]', 'varchar(80)') AS Name,
        Doctor_XML.value('(/Passenger/Age)[1]', 'int') as Age, Passport
FROM Doctors
WHERE Country='Great Britain'

SELECT Doctor_XML.query('(/Passenger/Name)') AS Name,
        Doctor_XML.query('(/Passenger/Age)') as Age, Passport
FROM Doctors
WHERE Country='Great Britain'


SELECT *
FROM Doctors
CROSS APPLY Doctor_XML.nodes('/Passenger')