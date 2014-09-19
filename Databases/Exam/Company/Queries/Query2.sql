USE Company
GO

SELECT d.Name, COUNT(*) AS [Number of Employees]
FROM Employees e
JOIN Departments d
  ON e.DepartmentId = d.Id
GROUP BY d.Name
ORDER BY [Number of Employees] DESC
