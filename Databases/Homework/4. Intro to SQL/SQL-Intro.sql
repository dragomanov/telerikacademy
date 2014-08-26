-- Task 1 --
/*  What is SQL? What is DML? What is DDL? Recite the most important SQL commands.

	SQL or Structured Query Language is a declarative language for manipulation of relational data.
	It consists of the Data Definition Language (DDL) and Data Manipulation Language (DML).
	DDL defines how data will be stored via statements like CREATE, DROP and ALTER.
	DML manipulates the stored data through INSERT, SELECT, UPDATE and DELETE statements.
*/


-- Task 2 --
/*	What is Transact-SQL (T-SQL)?

	Transact SQL (T-SQL) is an extension to the standard SQL language and is used in MS SQL Server.
	It is used to create stored procedures, triggers, constraints etc., and supports conditional statements 
	and loops.
*/


-- Task 3 --
/*	Start SQL Management Studio and connect to the database TelerikAcademy. 
	Examine the major tables in the "TelerikAcademy" database.

	The database contains the tables Addresses, Departments, Employees, EmployeeProjects, Projects and Towns.
	Most of them contain a PK, a name and a FK.
*/


USE TelerikAcademy
-- Task 4 --
-- Write a SQL query to find all information about all departments (use "TelerikAcademy" database). --
SELECT * FROM Departments


-- Task 5 --
-- Write a SQL query to find all department names. --
SELECT Name 
FROM Departments


-- Task 6 --
-- Write a SQL query to find the salary of each employee. --
SELECT Salary 
FROM Employees


-- Task 7 --
-- Write a SQL to find the full name of each employee. --
SELECT FirstName + ' ' + LastName AS [Full Name] 
FROM Employees


-- Task 8 --
/*  Write a SQL query to find the email addresses of each employee (by his first and last name). 
	Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
	The produced column should be named "Full Email Addresses". 
*/
SELECT FirstName + '.' + LastName + '@' + 'telerik.com' [Full Email Addresses] 
FROM Employees


-- Task 9 --
-- Write a SQL query to find all different employee salaries. --
SELECT DISTINCT Salary 
FROM Employees


-- Task 10 --
-- Write a SQL query to find all information about the employees whose job title is “Sales Representative“. --
SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative'


-- Task 11 --
-- Write a SQL query to find the names of all employees whose first name starts with "SA". --
SELECT FirstName + ' ' + LastName AS [Full Name] 
FROM Employees
WHERE FirstName LIKE 'SA%'


-- Task 12 --
-- Write a SQL query to find the names of all employees whose last name contains "ei". --
SELECT FirstName + ' ' + LastName AS [Full Name] 
FROM Employees
WHERE LastName LIKE '%ei%'


-- Task 13 --
-- Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. --
SELECT Salary 
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000


-- Task 14 --
--  Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. --
SELECT FirstName + ' ' + LastName AS [Full Name] 
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)


-- Task 15 --
-- Write a SQL query to find all employees that do not have manager. --
SELECT * 
FROM Employees
WHERE ManagerID IS NULL


-- Task 16 --
/*	Write a SQL query to find all employees that have salary more than 50000. 
	Order them in decreasing order by salary.
*/
SELECT *
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC


-- Task 17 --
-- Write a SQL query to find the top 5 best paid employees. --
SELECT TOP 5 *
FROM Employees
ORDER BY Salary DESC


-- Task 18 --
-- Write a SQL query to find all employees along with their address. Use inner join with ON clause. --
SELECT *
FROM Employees AS e
INNER JOIN Addresses AS a 
  ON e.AddressID = a.AddressID


-- Task 19 --
-- Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). --
SELECT *
FROM Employees AS e, Addresses AS a
WHERE e.AddressID = a.AddressID


-- Task 20 --
-- Write a SQL query to find all employees along with their manager. --
SELECT *
FROM Employees AS e
INNER JOIN Employees AS m
  ON e.ManagerID = m.EmployeeID


-- Task 21 --
/*	Write a SQL query to find all employees, along with their manager and their address. 
	Join the 3 tables: Employees e, Employees m and Addresses a.
*/
SELECT *
FROM Employees AS e
INNER JOIN Addresses AS a
  ON e.AddressID = a.AddressID
LEFT JOIN Employees AS m
  ON e.ManagerID = m.EmployeeID


-- Task 22 --
-- Write a SQL query to find all departments and all town names as a single list. Use UNION. --
SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

-- Task 23 --
/*	Write a SQL query to find all the employees and the manager for each of them 
	along with the employees that do not have manager. Use right outer join. 
	Rewrite the query to use left outer join.
*/
SELECT *
FROM Employees AS e
RIGHT JOIN Employees AS m
  ON m.ManagerID = e.EmployeeID
SELECT *
FROM Employees AS e
LEFT JOIN Employees AS m
  ON e.ManagerID = m.EmployeeID

-- Task 24 --
/*	Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" 
	whose hire year is between 1995 and 2005. 
*/
SELECT FirstName + ' ' + LastName AS [Full Name], *
FROM Employees e
INNER JOIN Departments d
  ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance')
  AND e.HireDate BETWEEN '1995' AND '2005'
