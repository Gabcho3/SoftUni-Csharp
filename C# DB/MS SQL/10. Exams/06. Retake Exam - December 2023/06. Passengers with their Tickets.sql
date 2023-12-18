SELECT 
	p.[Name] AS PassengerName,
	t.Price AS TicketPrice,
	t.DateOfDeparture,
	t.TrainId
FROM Tickets AS t
	JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY TicketPrice DESC, PassengerName;