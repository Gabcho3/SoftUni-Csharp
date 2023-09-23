SELECT 
	i.[Name] AS Item
	,i.Price
	,i.MinLevel
	,gt.[Name] AS [Forbidden Game Type]
FROM Items AS i
	LEFT JOIN GameTypeForbiddenItems AS fi ON i.Id = fi.ItemId
	LEFT JOIN GameTypes AS gt ON fi.GameTypeId = gt.Id
ORDER BY gt.[Name] DESC, i.[Name]