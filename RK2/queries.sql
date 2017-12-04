use Family;

-- Получить все сведения о персонах, чья мать более одного раза вступала в брак.

select 
	Child.*
from
	Person as Child inner join Marriage
	on
		Child.MotherID = Marriage.WifeID
where
	Child.FatherID != Marriage.HusbandID
;



-- Получить все сведения о ныне здравствующих персонах, 
-- которые являются детьми ныне здравствующих отцов, но не находящихся в разводе.

select
	Child.*
from
	(select PersonID as ID from Person where Gender = 'M' and DateOfDeath is null) as Mans,
	Person as Child inner join Marriage
	on
		Child.FatherID = Marriage.HusbandID
where
	Child.DateOfDeath is null
	and
	Marriage.DateOfDivorce is null
	and
	Child.FatherID in (Mans.ID)
group by
	Child.PersonID, Child.LastName, 
	Child.FirstName, Child.SrJr, Child.MaidenName, 
	Child.Gender, Child.FatherID, Child.MotherID, 
	Child.DateOfBirth, Child.DateOfDeath
;




-- Кто из женщин прожил дольше всех и здравствует до настоящего времени? 
-- Список должен включать: 
-- | PersonID | FirstName | LastName | Возраст |

select
	Woman.PersonID,
	Woman.FirstName,
	Woman.LastName,
	MaxAge.Age
from
	(
		select max(datediff(yy, DateOfBirth, getdate())) as Age 
		from Person 
		where Gender = 'F' and DateOfDeath is null
	) as MaxAge,
	Person as Woman
where
	Woman.Gender = 'F'
	and
	Woman.DateOfDeath is null
	and
	datediff(yy, Woman.DateOfBirth, getdate()) = MaxAge.Age
;