DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = 'Alex');
DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = 'Edinburgh');
DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId);

DECLARE @Item1Id INT = (SELECT Id FROM Items WHERE [Name] = 'Blackguard');
DECLARE @Item2Id INT = (SELECT Id FROM Items WHERE [Name] = 'Bottomless Potion of Amplification');
DECLARE @Item3Id INT = (SELECT Id FROM Items WHERE [Name] = 'Eye of Etlich (Diablo III)');
DECLARE @Item4Id INT = (SELECT Id FROM Items WHERE [Name] = 'Gem of Efficacious Toxin');
DECLARE @Item5Id INT = (SELECT Id FROM Items WHERE [Name] = 'Golden Gorget of Leoric');
DECLARE @Item6Id INT = (SELECT Id FROM Items WHERE [Name] = 'Hellfire Amulet');

DECLARE @totalPrice DECIMAL(8, 2) =
(
	SELECT SUM(Price)
	FROM Items
	WHERE Id IN (@Item1Id, @Item2Id, @Item3Id, @Item4Id, @Item5Id, @Item6Id)
)

INSERT INTO UserGameItems
VALUES
	(@userGameId, @Item1Id)
	,(@userGameId, @Item2Id)
	,(@userGameId, @Item3Id)
	,(@userGameId, @Item4Id)
	,(@userGameId, @Item5Id)
	,(@userGameId, @Item6Id)

UPDATE UsersGames
SET Cash -= @totalPrice
WHERE Id = @userGameId;

SELECT
	u.Username
	,g.[Name]
	,ug.Cash
	,i.[Name]
FROM Users AS u
	JOIN UsersGames AS ug ON u.Id = ug.UserId
	JOIN Games AS g ON ug.GameId = g.Id
	JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
	JOIN Items AS i ON ugi.ItemId = i.Id
WHERE g.Id = @gameId
ORDER BY i.[Name];