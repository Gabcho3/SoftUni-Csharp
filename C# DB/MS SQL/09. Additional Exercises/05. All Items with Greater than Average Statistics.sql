DECLARE @averageMind DECIMAL(10, 2) = ( SELECT AVG(Mind) FROM [Statistics])
DECLARE @averageLuck DECIMAL(10, 2) = ( SELECT AVG(Luck) FROM [Statistics])
DECLARE @averageSpeed DECIMAL(10, 2) = ( SELECT AVG(Speed) FROM [Statistics])


SELECT 
	i.[Name]
	,i.Price
	,i.MinLevel
	,st.Strength
	,st.Defence
	,st.Speed
	,st.Luck
	,st.Mind
FROM Items AS i
	JOIN [Statistics] AS st ON i.StatisticId = st.Id
WHERE 
	st.Mind > @averageMind
	AND st.Luck > @averageLuck
	AND st.Speed > @averageSpeed
ORDER BY i.[Name];