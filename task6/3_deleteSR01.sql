USE MyDB;
GO

DELETE FROM STUDENTS
WHERE GROUP_ID IN (SELECT GROUP_ID FROM GROUPS WHERE NAMEGROUP = 'SR-01');
GO