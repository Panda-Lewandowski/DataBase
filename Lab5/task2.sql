DECLARE @idoc int
DECLARE @doc xml
SELECT @doc = c FROM OPENROWSET(BULK '/home/parallels/Desktop/doctors.xml', 
                                SINGLE_BLOB) AS TEMP(c)
EXEC sp_xml_preparedocument @idoc OUTPUT, @doc

SELECT *
FROM OPENXML (@idoc, '/Doctors/P')
WITH (Passenger VARCHAR(85) , Sex VARCHAR(6), Age INT)
EXEC sp_xml_removedocument @idoc