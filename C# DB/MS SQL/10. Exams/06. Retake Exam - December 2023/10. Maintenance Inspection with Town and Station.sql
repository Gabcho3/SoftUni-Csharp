SELECT
	tr.Id AS TrainId,
	t.[Name] AS DepartureTown,
	mr.Details AS Details
FROM MaintenanceRecords AS mr
	JOIN Trains AS tr ON mr.TrainId = tr.Id
	JOIN Towns AS t ON tr.DepartureTownId = t.Id
WHERE mr.Details LIKE '%inspection%'
ORDER BY TrainId;