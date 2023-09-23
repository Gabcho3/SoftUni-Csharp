SELECT
	p.Id
	,p.[Name]
	,p.Price
	,c.[Name] AS [Category Name]
FROM Products AS p
	JOIN Categories AS c ON p.CategoryId = c.Id
WHERE c.[Name] IN ('ADR', 'Others')
ORDER BY p.Price DESC