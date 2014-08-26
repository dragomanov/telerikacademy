-- ���� 1 --
-- Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
-- and Accounts(Id(PK), PersonId(FK), Balance). 
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons.

CREATE TABLE Persons (
  PersonId int IDENTITY PRIMARY KEY,
  FirstName nvarchar(20),
  LastName nvarchar(20),
  SSN nvarchar(10) CHECK (LEN(SSN) = 10)
)

CREATE TABLE Accounts (
  AccountId int IDENTITY PRIMARY KEY,
  PersonId int FOREIGN KEY REFERENCES Persons(PersonId),
  Balance money
)

INSERT INTO Persons VALUES 
  ('Ivan', 'Ivanov', '1234567890'),
  ('Petar', 'Petrov', '1234567000')

INSERT INTO Accounts VALUES 
  (5, 1000.54),
  (6, 225.99)

GO

CREATE PROCEDURE uspPersonsFullNames
AS
  SELECT FirstName + ' ' + LastName
  FROM Persons
GO

EXEC uspPersonsFullNames
GO


-- Task 2 --
-- Create a stored procedure that accepts a number as a parameter and returns 
-- all persons who have more money in their accounts than the supplied number.

CREATE PROCEDURE uspBalanceHigherThan @balance money
AS
  SELECT * FROM Persons pers
  JOIN Accounts acc
    ON pers.PersonId = acc.PersonId
  WHERE acc.Balance > @balance
GO

EXEC uspBalanceHigherThan 300
GO


-- Task 3 --
-- Create a function that accepts as parameters � sum, yearly interest 
-- rate and number of months. It should calculate and return the new sum. 
-- Write a SELECT to test whether the function works as expected.

CREATE PROCEDURE uspPersonInterest @sum money, @yearlyInterest float, @months int
AS
  SELECT @sum * @yearlyInterest / 12 * @months

EXEC uspPersonInterest @sum = 100, @yearlyInterest = 1.10, @months = 1
GO


-- Task 4 --
-- Create a stored procedure that uses the function from the previous example 
-- to give an interest to a person's account for one month. 
-- It should take the AccountId and the interest rate as parameters.

CREATE PROCEDURE uspMonthInterest @accountId int, @interest float
AS
  DECLARE @accBalance money
  SELECT @accBalance = acc.Balance
  FROM Accounts acc
  WHERE @accountId = acc.AccountId

EXEC uspPersonInterest @sum = @accBalance, @yearlyInterest = @interest, @months = 1

EXEC uspMonthInterest @accountId = 1, @interest = 1.10

GO


-- Task 5 --
-- Add two more stored procedures WithdrawMoney( AccountId, money) 
-- and DepositMoney (AccountId, money) that operate in transactions.

CREATE PROCEDURE uspWithdrawMoney @accountId int, @money money
AS
  BEGIN TRAN
    UPDATE Accounts
    SET Balance -= @money
    WHERE AccountId = @accountId
  COMMIT
GO

CREATE PROCEDURE uspDepositMoney @accountId int, @money money
AS
  BEGIN TRAN
    UPDATE Accounts
    SET Balance += @money
    WHERE AccountId = @accountId
  COMMIT
GO

EXEC uspWithdrawMoney @accountId = 1, @money = 100
EXEC uspDepositMoney @accountId = 1, @money = 100


-- Task 6 --
-- Create another table � Logs(LogID, AccountID, OldSum, NewSum). 
-- Add a trigger to the Accounts table that enters a new entry 
-- into the Logs table every time the sum on an account changes.

CREATE TABLE Logs (
  LogId int PRIMARY KEY IDENTITY,
  AccountId int FOREIGN KEY REFERENCES Accounts(AccountId),
  OldSum money,
  NewSum money
)
GO

CREATE TRIGGER LogTransaction
ON Accounts
AFTER UPDATE
AS
  IF EXISTS(SELECT * FROM DELETED)
  BEGIN
  
    DECLARE @personId int, @balanceBefore money, @balanceAfter money
    SELECT @personId = del.AccountId, @balanceBefore = del.Balance FROM deleted del
    SELECT @balanceAfter = ins.Balance FROM inserted ins
    
    INSERT INTO Logs
    VALUES (@personId, @balanceBefore, @balanceAfter)
  END
GO

EXEC uspWithdrawMoney 1, 100
GO

-- Task 7 --
-- Define a function in the database TelerikAcademy that returns 
-- all Employee's names (first or middle or last name) 
-- and all town's names that are comprised of given set of letters. 
-- Example 'oistmiahf' will return 'Sofia', 'Smith', � but not 'Rob' and 'Guy'.

CREATE FUNCTION CheckIfHasLetters (@word nvarchar(20), @letters nvarchar(20))
RETURNS BIT
AS
  BEGIN
  
  DECLARE @lettersLen int = LEN(@letters),
  @matches int = 0,
  @currentChar nvarchar(1)
  
  WHILE(@lettersLen > 0)
  BEGIN
  	SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
  	IF(CHARINDEX(@currentChar, @word, 0) > 0)
  	  BEGIN
  	  	SET @matches += 1
  	  	SET @lettersLen -= 1
  	  END
  	ELSE
  		SET @lettersLen -= 1
  END

  IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
  	RETURN 1
  
  RETURN 0
  END
GO

CREATE FUNCTION NamesAndTowns(@letters nvarchar(20))
RETURNS @ResultTable TABLE (
  Name varchar(50) NOT NULL
)
AS
  BEGIN
  
  INSERT INTO @ResultTable
  SELECT LastName FROM Employees
  
  INSERT INTO @ResultTable
  SELECT FirstName FROM Employees
  
  INSERT INTO @ResultTable
  SELECT towns.Name FROM Towns towns
  
  DELETE FROM @ResultTable
  WHERE dbo.CheckIfHasLetters(Name, @letters) = 0
  
  RETURN
  END
GO

SELECT * FROM dbo.NamesAndTowns('oistmiahf')
GO


-- ���� 8 --
-- Using database cursor write a T-SQL script that scans all employees and their addresses
-- and prints all pairs of employees that live in the same town.

CREATE PROCEDURE uspEmployeesInTown @results CURSOR VARYING OUTPUT
AS
	BEGIN

	SET @results = CURSOR FOR

	SELECT emp.LastName, towns.Name 
	FROM Employees emp
	JOIN Addresses addr
	  ON emp.AddressID = addr.AddressID
	JOIN Towns towns
	  ON addr.TownID = towns.TownID
	GROUP BY towns.TownID, towns.Name, emp.LastName

	OPEN @results
	END
GO

DECLARE @employeesInTowns CURSOR
DECLARE @LastName varchar(20), @TownName varchar(20)

EXEC uspEmployeesInTown @results = @employeesInTowns OUTPUT

-----------------------
-- If no messages are shown, debug it and click on the messages tab
-- sometimes they get bugged and don't show when code is run normally
-- probably because they are too much.
-- Alternatively replace PRINT with SELECT, but the result won't be pretty.
-----------------------
WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT @LastName + ' ' + @TownName
	FETCH NEXT FROM @employeesInTowns
	INTO @LastName, @TownName
END

CLOSE @employeesInTowns
DEALLOCATE @employeesInTowns


-- Task 9 --
-- * Write a T-SQL script that shows for each town a list of all employees that live in it. 
-- Sample output:
--		Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
--		Ottawa -> Jose Saraiva
		
SELECT Towns.Name AS Town,
dbo.STRCONCAT(emp.FirstName + ' ' + emp.LastName) AS Employees  
FROM Towns
JOIN Addresses AS addr
ON Towns.TownID = addr.TownID
JOIN Employees AS emp
ON emp.AddressID = addr.AddressID
GROUP BY Towns.Name
 ORDER BY Towns.Name


-- Task 10 --	
-- Define a .NET aggregate function StrConcat that takes as input a sequence of strings 
-- and return a single string that consists of the input strings separated by ','. 
-- For example the following SQL statement should return a single string:
--		SELECT StrConcat(FirstName + ' ' + LastName)
--		FROM Employees

-- Enable CLR for SQL Server
EXEC sp_configure 'clr enabled', '1'
GO
RECONFIGURE
GO

-- Compile the solution in CLRFunctions
-- Go to TelerikAcademy -> Programmability -> Assemblies
-- Right click Assemblies -> New Assembly
-- Browse path to CLRFunctions\ConcatenationFunction\bin\Release and choose the DLL file there
-- this path is in my homework directory, after this is done - proceed with the next batch

CREATE AGGREGATE STRCONCAT (@input nvarchar(200))
RETURNS nvarchar(max)
EXTERNAL NAME ConcatenationFunction.Concat;
GO

SELECT dbo.STRCONCAT(FirstName + ' ' + LastName) FROM Employees
