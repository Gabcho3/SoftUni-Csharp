DELETE FROM Invoices
WHERE ClientId IN
(
	SELECT ClientId FROM Clients
	WHERE NumberVAT LIKE 'IT%'
)

DELETE FROM ProductsClients
WHERE ClientId IN
(
	SELECT ClientId FROM Clients
	WHERE NumberVAT LIKE 'IT%'
)

DELETE FROM Clients
WHERE NumberVAT LIKE 'IT%';