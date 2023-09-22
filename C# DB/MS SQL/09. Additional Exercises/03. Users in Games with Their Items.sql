SELECT
	u.Username
	,g.[Name] AS Game
	,COUNT(i.Id) AS [Items Count]
	,SUM(i.Price) AS [Items Price]
FROM Users AS u
	JOIN UsersGames AS ug ON u.Id = ug.UserId
	JOIN Games AS g ON ug.GameId = g.Id
	JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
	JOIN Items AS i ON ugi.ItemId = i.Id
GROUP BY u.Username, g.[Name]
HAVING COUNT(i.Id) >= 10
ORDER BY COUNT(i.Id) DESC, SUM(i.Price) DESC, u.Username
