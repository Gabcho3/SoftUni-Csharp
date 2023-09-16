CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Money MONEY)
AS
BEGIN
	SELECT FirstName, LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @Money
	ORDER BY ah.FirstName, ah.LastName;
END;

GO

--EXEC usp_GetHoldersWithBalanceHigherThan 1000;