CREATE PROC usp_CalculateFutureValueForAccount
	@AccountId INT,
	@InterestRate FLOAT
AS
BEGIN
	SELECT
		a.Id AS AccountId
		,ah.FirstName AS [First Name]
		,ah.LastName AS [Last Name]
		,a.Balance AS [Current Balance]
		, dbo.ufn_CalculateFutureValue (a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @AccountId

END;

GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1;