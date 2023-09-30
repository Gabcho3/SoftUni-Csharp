SELECT
	CONCAT_WS('-', o.[Name], a.[Name]) AS OwnersAnimals,
	o.PhoneNumber,
	ac.CageId
FROM Owners AS o
	JOIN Animals AS a ON o.Id = a.OwnerId
	JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
	JOIN AnimalsCages AS ac ON a.Id = ac.AnimalId
WHERE [at].AnimalType = 'Mammals'
ORDER BY o.[Name], a.[Name] DESC;