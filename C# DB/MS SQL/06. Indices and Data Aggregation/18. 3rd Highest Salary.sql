SELECT	
	DepartmentId,
	MAX(r.Salary)
FROM
(	
	SELECT 
		DepartmentId,
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
	FROM Employees
) AS r
WHERE r.Rank = 3
GROUP BY DepartmentID