SELECT TOP(10)
	e.FirstName
    ,e.LastName
    ,e.DepartmentID
FROM Employees AS e
JOIN
(
	SELECT 
		DepartmentId,
		AVG(Salary) AS [AvgSalary]
	FROM Employees
	GROUP BY DepartmentID
) AS AvgTable
	ON e.DepartmentID = AvgTable.DepartmentID
WHERE e.Salary > AvgSalary
ORDER BY e.DepartmentID;