CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(1)
		FROM Products AS p
			JOIN ProductsClients AS pc ON p.Id = pc.ProductId
		WHERE p.[Name] = @name
	)
END;
