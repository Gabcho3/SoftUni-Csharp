UPDATE Invoices
	SET DueDate = '2023-04-01'
WHERE MONTH(IssueDate) = 11 AND YEAR(IssueDate) = 2022;

UPDATE Clients
	SET AddressId = 3
WHERE [Name] LIKE '%CO%';