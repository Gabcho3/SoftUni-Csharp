SELECT TOP(1)
	MIN(a.AvgSalary) AS MinAverageSalary
FROM
(
	SELECT	
		AVG(Salary) AS AvgSalary
	FROM Employees
	GROUP BY DepartmentID
) AS a