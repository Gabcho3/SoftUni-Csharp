CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN
		(
			SELECT COUNT(cb.BoardgameId)
			FROM Creators AS c
				JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
			WHERE c.FirstName = @name
		)
END;