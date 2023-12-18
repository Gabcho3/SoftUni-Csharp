CREATE FUNCTION udf_TownsWithTrains (@Name VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @arrivalTrains INT = 
	(
		SELECT COUNT(t.Id)
		FROM Towns AS t
			JOIN Trains AS tr ON t.Id = tr.ArrivalTownId
		WHERE t.[Name] = @Name
	);

	DECLARE @departureTrains INT = 
	(
		SELECT COUNT(t.Id)
		FROM Towns AS t
			JOIN Trains AS tr ON t.Id = tr.DepartureTownId
		WHERE t.[Name] = @Name
	);

	RETURN @arrivalTrains + @departureTrains;
END;