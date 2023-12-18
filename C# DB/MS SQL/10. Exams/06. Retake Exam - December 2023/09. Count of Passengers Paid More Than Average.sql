SELECT 
	t.[Name] AS TownName,
	COUNT(p.[Name]) AS PassengersCount
FROM Towns AS t
	JOIN Trains AS tr ON t.Id = tr.ArrivalTownId
	JOIN Tickets AS ti ON tr.Id = ti.TrainId
	JOIN Passengers AS p ON ti.PassengerId = p.Id
WHERE ti.Price > 77
GROUP BY T.[Name]
ORDER BY TownName;