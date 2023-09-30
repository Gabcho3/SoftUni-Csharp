SELECT 
	v.[Name],
	v.PhoneNumber,
	REPLACE(SUBSTRING(v.[Address], 7, LEN(v.[Address])), ' , ', ' ') AS [Address]
FROM Volunteers AS v
	JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
WHERE 
	v.[Address] LIKE '%Sofia%' 
	AND vd.DepartmentName = 'Education program assistant'
ORDER BY v.[Name];