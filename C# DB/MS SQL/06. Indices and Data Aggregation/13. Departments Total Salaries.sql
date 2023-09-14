Select 
	DepartmentId,
	SUM(Salary)
FROM Employees
GROUP BY DepartmentID;