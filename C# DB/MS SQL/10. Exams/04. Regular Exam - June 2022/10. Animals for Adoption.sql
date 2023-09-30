SELECT
	a.[Name],
	YEAR(a.BirthDate) AS BirthYear,
	[at].AnimalType
FROM Animals AS a
	JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
WHERE
	a.OwnerId IS NULL
	AND YEAR(a.BirthDate) > 2017
	AND [at].AnimalType != 'Birds'
ORDER BY a.[Name];