SELECT Doctor_XML.query('
    for $b in /Passenger
	return (<Doctor id="{sql:column("Passport")}"></Doctor>)')
FROM Doctors

Declare @a varchar(40)
SET @a = 'Association of doctors of the world'
SELECT Doctor_XML.query('
    for $b in /Passenger
	return (<Doctor org="{sql:variable("@a")}" id="{sql:column("Passport")}"></Doctor>)')
FROM Doctors


