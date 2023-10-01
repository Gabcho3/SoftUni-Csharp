CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS 
BEGIN
	RETURN
	(
		SELECT COUNT(f.Id)
		FROM Passengers AS p
			JOIN FlightDestinations AS f ON p.Id = f.PassengerId
		WHERE p.Email = @email
	)
END;