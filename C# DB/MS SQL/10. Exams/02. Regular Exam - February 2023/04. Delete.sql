DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN
(
	SELECT BoardgameId
	FROM CreatorsBoardgames AS cb
	JOIN Boardgames AS b ON cb.BoardgameId = b.Id
	JOIN Publishers AS p ON b.PublisherId = p.Id
	JOIN Addresses AS a ON p.AddressId = a.Id
	WHERE a.Town LIKE 'L%'
)


DELETE FROM Boardgames
WHERE PublisherId IN
(
	SELECT PublisherId
	FROM Boardgames AS b
	JOIN Publishers AS p ON b.PublisherId = p.Id
	JOIN Addresses AS a ON p.AddressId = a.Id
	WHERE a.Town LIKE 'L%'
);

DELETE FROM Publishers
WHERE AddressId IN
(
	SELECT p.AddressId
	FROM Publishers AS p
	JOIN Addresses AS a ON p.AddressId = a.Id
	WHERE a.Town LIKE 'L%'
);

DELETE FROM Addresses
WHERE Town LIKE 'L%';