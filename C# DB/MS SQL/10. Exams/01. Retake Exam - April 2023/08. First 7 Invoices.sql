SELECT TOP(7)
	Number
	,Amount
	,c.[Name]
FROM Invoices AS i
	JOIN Clients AS c ON i.ClientId = c.Id
WHERE 
	IssueDate < '2023-01-01'
	AND Currency = 'EUR'
	OR Amount > 500
	AND c.NumberVAT LIKE 'DE%'
ORDER BY i.Number, i.Amount DESC