ALTER TABLE [Users]
	ADD DEFAULT GETDATE() FOR LastLoginTime;

INSERT INTO [Users] (Username, Password) VALUES('user6', 'pass6');