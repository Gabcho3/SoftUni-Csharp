CREATE TABLE [Users] (
	Id INT IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture IMAGE,
	LastLoginTime DATETIME,
	IsDeleated BIT
);

ALTER TABLE [Users]
	ADD CONSTRAINT PK_Users PRIMARY KEY(Id);

INSERT INTO [Users] VALUES
	('user1', 'pass1', NULL, NULL, 'False'),
	('user2', 'pass2', NULL, NULL, 'True'),
	('user3', 'pass3', NULL, NULL, 'True'),
	('user4', 'pass4', NULL, NULL, 'False'),
	('user5', 'pass5', NULL, NULL, 'False');
