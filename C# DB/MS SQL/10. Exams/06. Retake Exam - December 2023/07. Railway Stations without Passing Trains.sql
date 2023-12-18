SELECT 
	t.[Name] As Town,
	rs.[Name] AS RailwayStation
FROM RailwayStations AS rs
	LEFT JOIN TrainsRailwayStations AS trs ON rs.Id = trs.RailwayStationId
	JOIN Towns AS t ON rs.TownId = t.Id
WHERE trs.RailwayStationId IS NULL
ORDER BY Town, RailwayStation;

