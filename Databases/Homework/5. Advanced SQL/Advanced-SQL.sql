USE TelerikAcademy
-- Task 1 --
-- Write a SQL query to find the names and salaries of the employees 
-- that take the minimal salary in the company. Use a nested SELECT statement. 
SELECT FirstName + ' ' + LastName AS [Full Name], Salary 
FROM Employees 
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)


-- Task 2 --
-- Write a SQL query to find the names and salaries of the employees 
-- that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName + ' ' + LastName AS [Full Name], Salary 
FROM Employees 
WHERE Salary <=
  (SELECT MIN(Salary) * 1.10 FROM Employees)


-- Task 3 --
-- Write a SQL query to find the full name, salary and department of the employees 
-- that take the minimal salary in their department. Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary
FROM Employees AS e
WHERE Salary =
  (SELECT MIN(Salary) 
   FROM Employees
   WHERE DepartmentID = e.DepartmentID)


-- Task 4 --
-- Write a SQL query to find the average salary in the department #1. 
SELECT AVG(Salary) [Average Salary]
FROM Employees 
WHERE DepartmentID = 1


-- Task 5 --
-- Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(Salary) [Average Salary]
FROM Employees AS e
JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'


-- Task 6 --
-- Write a SQL query to find the number of employees in the "Sales" department. 
SELECT COUNT(*) [Number Of Employees]
FROM Employees AS e
JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'


-- Task 7 --
-- Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) [Number Of Employees]
FROM Employees
WHERE ManagerID IS NOT NULL


-- Task 8 --
-- Write a SQL query to find the number of all employees that have no manager. 
SELECT COUNT(*) [Number Of Employees]
FROM Employees
WHERE ManagerID IS NULL


-- Task 9 --
-- Write a SQL query to find all departments and the average salary for each of them. 
SELECT d.Name, AVG(e.Salary) [Average Salary]
FROM Employees AS e
JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name


-- Task 10 --
-- Write a SQL query to find the count of all employees in each department and for each town. 
SELECT d.Name Department, t.Name Town, COUNT(*) [Number Of Employees]
FROM Employees AS e
JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID
JOIN Addresses AS a
  ON e.AddressID = a.AddressID
JOIN Towns AS t
  ON a.TownID = t.TownID
GROUP BY d.Name, t.Name


-- Task 11 --
-- Write a SQL query to find all managers that have exactly 5 employees. 
-- Display their first name and last name. 
SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
FROM Employees AS e
WHERE 5 =
  (SELECT COUNT(*) 
   FROM Employees
   WHERE ManagerID = e.EmployeeID)


-- Task 12 --
-- Write a SQL query to find all employees along with their managers. 
-- For employees that do not have manager display the value "(no manager)". 
SELECT e.*, COALESCE(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager
FROM Employees AS e
LEFT JOIN Employees AS m
  ON e.ManagerID = m.EmployeeID


-- Task 13 --
-- Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
-- Use the built-in LEN(str) function. 
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LEN(LastName) = 5


-- Task 14 --
-- Write a SQL query to display the current date and time in the following format 
-- "day.month.year hour:minutes:seconds:milliseconds". 
-- Search in Google to find how to format dates in SQL Server. 
SELECT CONVERT(nvarchar, GETDATE(), 104) + ' ' + CONVERT(nvarchar, GETDATE(), 114)


-- Task 15 --
-- Write a SQL statement to create a table Users. 
-- Users should have username, password, full name and last login time. 
-- Choose appropriate data types for the table fields. 
-- Define a primary key column with a primary key constraint. 
-- Define the primary key column as identity to facilitate inserting records. 
-- Define unique constraint to avoid repeating usernames. 
-- Define a check constraint to ensure the password is at least 5 characters long. 
IF OBJECT_ID('Users','U') IS NOT NULL
   DROP TABLE Users
GO
CREATE TABLE Users (
  UserId int IDENTITY PRIMARY KEY,
  Username nvarchar(50) NOT NULL UNIQUE,
  Passwd nvarchar(50) CHECK (LEN(Passwd) >= 5),
  Name nvarchar(100) NOT NULL,
  LastLogin datetime
)
GO


-- Task 16 --
-- Write a SQL statement to create a view that displays the users from the Users table 
-- that have been in the system today. Test if the view works correctly. 
INSERT INTO Users VALUES
  ('pesho', 'pesho', 'Pesho', GETDATE()),
  ('gosho', 'gosho', 'Gosho', '2014-08-21 10:04:52'),
  ('vanko1', 'vanko', 'Vanko1', GETDATE()),
  ('katitu', 'katitu', 'Katya', GETDATE()),
  ('mariyka', 'mariyka', 'Mara', GETDATE()),
  ('da_devil', 'thepickofdestiny', 'Mr. Diabolos', GETDATE())
GO
IF OBJECT_ID('UsersLoggedToday','V') IS NOT NULL
   DROP VIEW UsersLoggedToday
GO
CREATE VIEW UsersLoggedToday AS
SELECT *
FROM Users
WHERE DATEDIFF(day, LastLogin, GETDATE()) = 0
GO
SELECT * FROM UsersLoggedToday


-- Task 17 --
-- Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
-- Define primary key and identity column. 
IF OBJECT_ID('Groups','U') IS NOT NULL
   DROP TABLE Groups;
CREATE TABLE Groups (
  GroupId int IDENTITY PRIMARY KEY,
  Name nvarchar(50) NOT NULL UNIQUE
);


-- Task 18 --
-- Write a SQL statement to add a column GroupID to the table Users. 
-- Fill some data in this new column and as well in the Groups table. 
-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables. 
ALTER TABLE Users
ADD GroupID int FOREIGN KEY REFERENCES Groups(GroupId)
GO
INSERT INTO Groups VALUES
  ('public'), ('sysadmin'), ('dbcreator'), ('bulkadmin')
GO
UPDATE Users
SET GroupID = UserId % (SELECT COUNT(*) FROM Groups) + 1 -- sets GroupIDs based on UserId


-- Task 19 --
-- Write SQL statements to insert several records in the Users and Groups tables. 
INSERT INTO Groups VALUES
  ('diskadmin'), ('securityadmin'), ('setupadmin')
GO
INSERT INTO Users VALUES
  ('catherine', 'catherine', 'Catherine', GETDATE(), NULL),
  ('leprechaun', 'thepotofgoldismine', 'Mr. Leprechaun', '2009-08-25 17:51:13', NULL)
GO


-- Task 20 --
-- Write SQL statements to update some of the records in the Users and Groups tables. 
UPDATE Users
SET GroupID = 7
WHERE GroupID = 6

UPDATE Groups
SET Name = 'serveradmin'
WHERE GroupId = 6


-- Task 21 --
-- Write SQL statements to delete some of the records from the Users and Groups tables. 
DELETE FROM Users
WHERE GroupID = 4

DELETE FROM Groups
WHERE GroupId = 4


-- Task 22 --
-- Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
-- Combine the first and last names as a full name. For username use the first 
-- letter of the first name + the last name (in lowercase). 
-- Use the same for the password, and NULL for last login time. 
INSERT INTO Users (Name, Username, Passwd, LastLogin)
SELECT FirstName + ' ' + LastName,
  LOWER(FirstName + LastName),
  LOWER(FirstName + LastName),
  NULL
FROM Employees


-- Task 23 --
-- Write a SQL statement that changes the password to NULL for all users 
-- that have not been in the system since 10.03.2010.
UPDATE Users 
SET Passwd = NULL
WHERE LastLogin < '2010-03-10'


-- Task 24 --
-- Write a SQL statement that deletes all users without passwords (NULL password). 
DELETE
FROM Users
WHERE Passwd IS NULL


-- Task 25 --
-- Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name, e.JobTitle, AVG(e.Salary) AS AverageSalary
FROM Employees AS e
INNER JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle


-- Task 26 --
-- Write a SQL query to display the minimal employee salary by department 
-- and job title along with the name of some of the employees that take it. 
SELECT emp.Salary AS MinimalSalary, dep.Name, emp.JobTitle, emp.FirstName + ' ' + emp.LastName AS FullName
FROM Employees emp
INNER JOIN Departments AS dep
  ON emp.DepartmentID = dep.DepartmentID
WHERE Salary = (
	SELECT MIN(e.Salary) AS MinimalSalary
	FROM Employees AS e
	INNER JOIN Departments AS d
	  ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, e.JobTitle
	HAVING emp.JobTitle = e.JobTitle AND dep.Name = d.Name)
ORDER BY JobTitle


-- Task 27 --
-- Write a SQL query to display the town where maximal number of employees work. 
SELECT TOP 1 t.Name, COUNT(*) AS NumberOfEmployees
FROM Employees e
INNER JOIN Addresses a
  ON e.AddressID = a.AddressID
INNER JOIN Towns t
  ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY NumberOfEmployees DESC


-- Task 28 --
-- Write a SQL query to display the number of managers from each town. 
SELECT t.Name, COUNT(*) AS NumberOfManagers
FROM Employees m
INNER JOIN Addresses a
  ON m.AddressID = a.AddressID
INNER JOIN Towns t
  ON a.TownID = t.TownID
WHERE m.EmployeeID IN (
  SELECT ManagerID
  FROM Employees)
GROUP BY t.Name


-- Task 29 --
-- Write a SQL to create table WorkHours to store work reports for each employee 
-- (employee id, date, task, hours, comments). Don't forget to define identity, 
-- primary key and appropriate foreign key. 
-- Issue few SQL statements to insert, update and delete of some data in the table. 
-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
-- For each change keep the old record data, the new record data and the command (insert / update / delete).
IF OBJECT_ID('WorkHours','U') IS NOT NULL
   DROP TABLE WorkHours
GO
CREATE TABLE WorkHours (
  Id int IDENTITY PRIMARY KEY,
  EmployeeId int FOREIGN KEY REFERENCES Employees(EmployeeID),
  WorkDate date,
  Task nvarchar(255),
  WorkHours tinyint,
  Comments nvarchar(MAX)
)
GO

IF OBJECT_ID('WorkHoursLogs','U') IS NOT NULL
   DROP TABLE WorkHoursLogs
GO
CREATE TABLE WorkHoursLogs (
  Id int IDENTITY PRIMARY KEY,
  OldWorkHoursId int,
  OldEmployeeId int FOREIGN KEY REFERENCES Employees(EmployeeID),
  OldWorkDate date,
  OldTask nvarchar(255),
  OldWorkHours tinyint,
  OldComments nvarchar(MAX),
  NewWorkHoursId int,
  NewEmployeeId int FOREIGN KEY REFERENCES Employees(EmployeeID),
  NewWorkDate date,
  NewTask nvarchar(255),
  NewWorkHours tinyint,
  NewComments nvarchar(MAX),
  Command nchar(6) CHECK (Command IN ('insert', 'update', 'delete'))
)
GO

IF OBJECT_ID ('WorkHoursLogTrigger', 'TR') IS NOT NULL
   DROP TRIGGER WorkHoursLogTrigger
GO
CREATE TRIGGER WorkHoursLogTrigger
ON WorkHours
AFTER INSERT, UPDATE, DELETE 
AS
BEGIN
  DECLARE @Action as char(1);
  SET @Action = (CASE WHEN EXISTS(SELECT * FROM INSERTED)
                         AND EXISTS(SELECT * FROM DELETED)
                        THEN 'U'  -- Set Action to Updated.
                        WHEN EXISTS(SELECT * FROM INSERTED)
                        THEN 'I'  -- Set Action to Insert.
                        WHEN EXISTS(SELECT * FROM DELETED)
                        THEN 'D'  -- Set Action to Deleted.
                        ELSE NULL -- Skip. It may have been a "failed delete".   
                    END)
  INSERT INTO WorkHoursLogs
  SELECT *, 'insert'
  FROM deleted d
  LEFT JOIN inserted i
    ON d.Id = i.Id
END
GO


INSERT INTO WorkHours VALUES
  (3, GETDATE(), 'Next quarter income forecast', 5, 'Forecast is optimistic'),
  (21, GETDATE(), 'Aquire new leads', 7, 'Aquired 5 new leads')

UPDATE WorkHours
SET Comments = 'Aquired 7 new leads'
WHERE Id = 2

DELETE
FROM WorkHours
WHERE Id = 1

SELECT *
FROM WorkHoursLogs


-- Task 30 --
-- Start a database transaction, delete all employees from the 'Sales' department 
-- along with all dependent records from the pother tables. At the end rollback the transaction. 



-- Task 31 --
-- Start a database transaction and drop the table EmployeesProjects. 
-- Now how you could restore back the lost table data? 


-- Task 32 --
-- Find how to use temporary tables in SQL Server. Using temporary tables backup all records 
-- from EmployeesProjects and restore them back after dropping and re-creating the table. 


