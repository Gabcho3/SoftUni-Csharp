CREATE PROC usp_WithdrawMoney 
	@AccountId INT, 
	@MoneyAmount DECIMAL(18, 4)
AS
	IF(@MoneyAmount < 0) THROW 50001, 'Invalid Amount', 1
	UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @AccountId