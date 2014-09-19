USE [Cars]
GO

IF OBJECT_ID ( 'uspCreateAllEmployeesProjects', 'P' ) IS NOT NULL 
    DROP PROCEDURE uspCreateAllEmployeesProjects;
GO
CREATE PROCEDURE uspCreateAllEmployeesProjects
AS
	IF OBJECT_ID ( 'Cache', 'U' ) IS NOT NULL 
		DROP TABLE Cache;
	GO
	CREATE TABLE Cache(
		[Id] [int] NOT NULL,
		[Full Name] [nvarchar](50) NOT NULL,
		[Project Name] [nvarchar](100) NOT NULL,
		[Department Name] [nvarchar](50) NOT NULL,
		[Start Date] [date] NOT NULL,
		[End Date] [date] NOT NULL,
		[Number Of Employees] [int] NOT NULL
	) ON [PRIMARY]
	GO
GO


USE [Cars]
GO

IF OBJECT_ID ( 'uspGetAllEmployeesProjects', 'P' ) IS NOT NULL 
    DROP PROCEDURE uspGetAllEmployeesProjects;
GO
CREATE PROCEDURE uspGetAllEmployeesProjects
AS
	SELECT *
	INTO Cache
	FROM (
		SELECT FirstName + ' ' + LastName AS [Full Name], 
		  p.Name AS [Project Name],
		  d.Name AS [Department Name],
		  ep.StartDate,
		  ep.EndDate,
		  [Number Of Reports] = (
			SELECT COUNT(*) 
			FROM Reports r
			WHERE r.EmployeeId = ep.EmployeeId
			  AND r.ReportTime BETWEEN ep.StartDate and ep.EndDate
		  )
		FROM EmployeesProjects ep
		JOIN Projects p
		  ON ep.ProjectId = p.Id
		JOIN Employees e
		  ON ep.EmployeeId = e.Id
		JOIN Departments d
		  ON e.DepartmentId = d.Id
		ORDER BY ep.EmployeeId, ep.ProjectId
	)
GO


