USE Company
GO

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
