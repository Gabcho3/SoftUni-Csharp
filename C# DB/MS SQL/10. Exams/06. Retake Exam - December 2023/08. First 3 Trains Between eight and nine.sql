SELECT TOP 3
	tr.Id,
	tr.HourOfDeparture,
	t.Price AS TicketPrice,
	towns.[Name] AS Destination 
FROM Trains AS tr
	JOIN Tickets AS t ON tr.Id = t.TrainId
	JOIN Towns AS towns ON tr.ArrivalTownId = towns.Id
WHERE 
	DATEPART(HOUR, tr.HourOfDeparture) = 8
	AND t.Price > 50
ORDER BY TicketPrice, HourOfDeparture;