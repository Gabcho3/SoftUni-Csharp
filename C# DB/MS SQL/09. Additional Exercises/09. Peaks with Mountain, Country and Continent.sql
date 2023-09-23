SELECT 
	p.PeakName
	,m.MountainRange
	,c.CountryName
	,co.ContinentName
FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
	JOIN Countries AS c ON mc.CountryCode = c.CountryCode
	JOIN Continents as co ON c.ContinentCode = cO.ContinentCode
ORDER BY p.PeakName, c.CountryName
