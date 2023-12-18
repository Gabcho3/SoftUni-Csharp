CREATE PROCEDURE usp_SearchByTown(@townName VARCHAR(30))
AS
BEGIN
	SELECT 
		p.[Name] AS PassangerName,
		ti.DateOfDeparture,
		tr.HourOfDeparture
	FROM Passengers AS p
		JOIN Tickets AS ti ON p.Id = ti.PassengerId
		JOIN Trains AS tr ON ti.TrainId = tr.Id
		JOIN Towns AS t ON tr.ArrivalTownId = t.Id
	WHERE t.[Name] = @townName
	ORDER BY DateOfDeparture DESC, PassangerName
END;