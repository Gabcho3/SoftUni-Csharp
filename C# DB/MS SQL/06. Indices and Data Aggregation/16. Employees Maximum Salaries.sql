SELECT 
	DepartmentId
	, Max(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING Max(Salary) NOT BETWEEN 30000 AND 70000;