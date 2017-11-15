SELECT DISTINCT PTS.PassengerId, P.Passenger, 
            P.Sex, P.Age, PTS.Survival
FROM P JOIN PTS ON P.Passenger = PTS.Passenger
WHERE P.Passenger LIKE '%Dr.%'
FOR XML RAW, ELEMENTS 