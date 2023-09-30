CREATE FUNCTION udf_GetVolunteersCountFromADepartment 
	(@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(v.Id)
		FROM VolunteersDepartments AS vd
			JOIN Volunteers AS v ON vd.Id = v.DepartmentId
		WHERE vd.DepartmentName = @VolunteersDepartment
	)
END;
