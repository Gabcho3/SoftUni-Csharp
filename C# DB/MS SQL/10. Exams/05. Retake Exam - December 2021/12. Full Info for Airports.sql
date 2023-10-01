CREATE PROC  usp_SearchByAirportName(@aiportName VARCHAR(70))
AS
BEGIN
	SELECT
		ai.AirportName,
		p.FullName,
		CASE 
			WHEN f.TicketPrice <= 400 THEN 'Low'
			WHEN f.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
			ELSE 'High'
		END AS LevelOfTickerPrice,
		a.Manufacturer,
		a.Condition,
		[at].TypeName
	FROM  Airports AS ai
		JOIN FlightDestinations AS f ON ai.Id = f.AirportId
		JOIN Passengers AS p ON f.PassengerId = p.Id
		JOIN Aircraft AS a ON f.AircraftId = a.Id
		JOIN AircraftTypes AS [at] ON a.TypeId = [at].Id
	WHERE ai.AirportName = @aiportName
	ORDER BY a.Manufacturer, p.FullName
END;