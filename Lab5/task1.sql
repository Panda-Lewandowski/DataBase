SELECT DISTINCT P.Passenger, P.Sex, P.Age 
FROM P JOIN PTS ON P.Passenger = PTS.Passenger
WHERE P.Passenger LIKE '%Dr.%'
FOR XML AUTO, ROOT('Doctors')