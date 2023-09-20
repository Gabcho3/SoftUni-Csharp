CREATE PROC  usp_TransferMoney
	@SenderId INT,
	@ReceiverId INT,
	@Amount DECIMAL(18, 4)
AS
BEGIN TRANSACTION
	IF(@Amount < 0) THROW 50001, 'Invalid Amount', 1
	BEGIN TRY
		EXEC usp_DepositMoney @ReceiverId @Amount;
		EXEC usp_WithdrawMoney @SenderId @Amount;
	END TRY
	BEGIN CATCH
		ROLLBACK;
	END CATCH
COMMIT;