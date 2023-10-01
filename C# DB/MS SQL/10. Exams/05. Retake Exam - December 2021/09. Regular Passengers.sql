SELECT
	p.FullName,
	COUNT(a.Id),
	SUM(f.TicketPrice)
FROM Passengers AS p
	JOIN FlightDestinations AS f ON p.Id = f.PassengerId
	JOIN Aircraft AS a ON f.AircraftId = a.Id
GROUP BY p.FullName
HAVING COUNT(a.Id) > 1 AND p.FullName LIKE '_a%'
ORDER BY p.FullName;