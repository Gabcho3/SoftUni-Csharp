SELECT 
	DateOfDeparture,
	Price AS TicketPrice
FROM Tickets
ORDER BY TicketPrice, DateOfDeparture DESC;