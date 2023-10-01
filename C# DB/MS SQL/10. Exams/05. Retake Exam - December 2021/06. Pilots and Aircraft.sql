SELECT 
	p.FirstName,
	p.LastName,
	a.Manufacturer,
	a.Model,
	a.FlightHours
FROM Aircraft AS a
	JOIN PilotsAircraft AS pa ON a.Id = pa.AircraftId
	JOIN Pilots AS p ON pa.PilotId = p.Id
WHERE a.FlightHours IS NOT NULL AND a.FlightHours < 304
ORDER BY a.FlightHours DESC, p.FirstName;