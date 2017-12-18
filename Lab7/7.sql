DECLARE @myDoc xml       
SET @myDoc = 
'<Passenger PassengerId="318">
  <Survival>0</Survival>
  <Name>Moraweck Dr. Ernest</Name>
  <Sex>male</Sex>
  <Age>54</Age>
  <!-- love coffee -->
</Passenger>'

SELECT @myDoc

SET @myDoc.modify('       
insert <University>MIT</University> 
into (/Passenger)[1]')

SELECT @myDoc

SET @myDoc.modify('       
insert <WrongInfo>Bla</WrongInfo> 
into (/Passenger)[1]')

SELECT @myDoc

SET @myDoc.modify('
  delete /Passenger/WrongInfo
')

SELECT @myDoc

SET @myDoc.modify('
  replace value of (/Passenger/University/text())[1]
  with     "Oxford"
')
SELECT @myDoc


