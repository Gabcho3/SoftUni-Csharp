SELECT TOP(20)
	f.Id,
	f.[Start],
	p.FullName,
	a.AirportName,
	f.TicketPrice
FROM FlightDestinations AS f
	JOIN Airports AS a ON f.AirportId = a.Id
	JOIN Passengers AS p ON f.PassengerId = p.Id
WHERE f.[Start] % 2 = 0
ORDER BY f.TicketPrice DESC, a.AirportName;