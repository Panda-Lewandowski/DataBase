CREATE TRIGGER DenyInsert 
ON P
INSTEAD OF INSERT
AS
BEGIN
    RAISERROR('This is uneditable table.',10,1);
END;