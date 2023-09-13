SELECT TOP(5)
	e.EmployeeId
	,e.JobTitle
	,e.AddressID
	,a.AddressText
FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID;