DECLARE @idoc int
DECLARE @doc xml
SELECT @doc = c FROM OPENROWSET(BULK '/home/parallels/Desktop/task-12.xml', 
                                SINGLE_BLOB) AS TEMP(c)
EXEC sp_xml_preparedocument @idoc OUTPUT, @doc
SELECT *
FROM OPENXML (@idoc, '/ROOT/Doctors')
WITH (Passenger VARCHAR(85) , Sex VARCHAR(6), Age INT)