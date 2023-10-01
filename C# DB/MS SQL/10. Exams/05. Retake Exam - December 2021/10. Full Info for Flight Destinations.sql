SELECT 
	ai.AirportName,
	f.[Start] AS DayTime,
	f.TicketPrice,
	p.FullName,
	a.Manufacturer,
	a.Model
FROM Airports AS ai
	JOIN FlightDestinations AS f ON ai.Id = f.AirportId
	JOIN Passengers AS p ON f.PassengerId = p.Id
	JOIN Aircraft AS a ON f.AircraftId = a.Id
WHERE 
	DATEPART(HOUR, f.[Start]) BETWEEN 6 AND 20
	AND f.TicketPrice > 2500
ORDER BY a.Model;
