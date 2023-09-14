SELECT * INTO [NewTable]
FROM Employees
WHERE Salary > 30000;

DELETE FROM [NewTable]
WHERE ManagerID = 42;

UPDATE NewTable
	SET Salary = Salary + 5000
	WHERE DepartmentID = 1;

SELECT 
	DepartmentId,
	AVG(Salary)
FROM [NewTable]
GROUP BY DepartmentID;
	