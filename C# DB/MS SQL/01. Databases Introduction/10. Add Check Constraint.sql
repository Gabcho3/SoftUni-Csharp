ALTER TABLE [Users]
	ADD CONSTRAINT CHK_User_Password
	CHECK(LEN(Password) >= 5);