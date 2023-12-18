DELETE MaintenanceRecords
WHERE TrainId = (
	SELECT Id FROM Trains
	WHERE DepartureTownId = 3
);

DELETE Tickets
WHERE TrainId = (
	SELECT Id FROM Trains
	WHERE DepartureTownId = 3
);

DELETE TrainsRailwayStations
WHERE TrainId = (
	SELECT Id FROM Trains
	WHERE DepartureTownId = 3
);

DELETE Trains
WHERE DepartureTownId = 3;