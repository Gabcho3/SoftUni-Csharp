SELECT
	co.ContinentName
	,SUM(CAST(c.AreaInSqKm AS BIGINT)) AS CountriesArea
	,SUM(CAST(c.[Population] AS BIGINT)) AS CountriesPopulation
FROM Continents AS co
	JOIN Countries AS c ON co.ContinentCode = c.ContinentCode
GROUP BY co.ContinentName
ORDER BY CountriesPopulation DESC