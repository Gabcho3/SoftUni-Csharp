SELECT
	c.[Name] AS Client
	,FLOOR(AVG(p.Price)) AS [Average Price]
FROM Clients AS c
	RIGHT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
	JOIN Products AS p ON pc.ProductId = p.Id
WHERE p.VendorId IN (SELECT Id FROM Vendors WHERE NumberVAT LIKE '%FR%')
GROUP BY c.[Name]
ORDER BY [Average Price], c.[Name] DESC