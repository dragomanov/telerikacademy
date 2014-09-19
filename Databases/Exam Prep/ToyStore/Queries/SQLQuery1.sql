USE ToyStore
GO

SELECT Name, Price
FROM Toys
WHERE Name = 'puzzle' AND Price > 10
ORDER BY Price
