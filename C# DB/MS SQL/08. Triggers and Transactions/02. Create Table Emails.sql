CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT REFERENCES Accounts(Id),
	[Subject] TEXT NOT NULL,
	Body TEXT NOT NULL
);

CREATE TRIGGER tr_AddEmailOnNewLog
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT 
		i.AccountId
		,CONCAT('Balance change for account: ', i.AccountId)
		,CONCAT('On ', GETDATE(), ' your balance was changed from ', i.OldSum, ' to ',  i.NewSum)
	FROM inserted AS i
	WHERE i.OldSum != i.NewSum