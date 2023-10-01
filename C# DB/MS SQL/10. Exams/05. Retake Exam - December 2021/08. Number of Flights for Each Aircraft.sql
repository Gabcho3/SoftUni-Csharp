SELECT 
	a.Id AS AircraftId,
	a.Manufacturer,
	a.FlightHours,
	COUNT(f.Id) AS FlightDestinationsCount,
	ROUND(AVG(f.TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
	JOIN FlightDestinations AS f ON a.Id = f.AircraftId
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(f.Id) >= 2
ORDER BY FlightDestinationsCount DESC, a.Id;
