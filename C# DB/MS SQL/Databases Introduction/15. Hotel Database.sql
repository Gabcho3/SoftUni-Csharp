CREATE DATABASE [Hotel];
GO

USE [Hotel];

CREATE TABLE [Employees](
	Id INT IDENTITY,
	FisrtName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(20),
	Notes TEXT,

	CONSTRAINT PK_Employees PRIMARY KEY(Id)
);

INSERT INTO [Employees] VALUES
	('George', 'Petrov', 'Receptionist', NULL),
	('Ivanka', 'Todorova', 'Clener', NULL),
	('Petar', 'Ivanov', 'Barman', NULL);


CREATE TABLE [Customers](
	AccountNumber INT IDENTITY,
	FisrtName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	PhoneNumber VARCHAR(12) NOT NULL,
	EmergenyName VARCHAR(20),
	EmergencyNumber VARCHAR(12),
	Notes TEXT,

	CONSTRAINT PK_Customers PRIMARY KEY(AccountNumber)
);

INSERT INTO [Customers] VALUES
	('Konstantin', 'Dimitrov', '088888888', NULL, NULL, NULL),
	('Borislav', 'Uzunov', '031314445', NULL, NULL, NULL),
	('Boris', 'Troyanov', '032131231', NULL, NULL, NULL);


CREATE TABLE [RoomStatus](
	RoomStatus BIT NOT NULL,
	Notes TEXT
);

INSERT INTO [RoomStatus] VALUES
	('True', NULL),
	('False', NULL),
	('True', NULL);


CREATE TABLE [RoomTypes](
	RoomType VARCHAR(10) NOT NULL,
	Notes TEXT

	CONSTRAINT PK_RoomTypes PRIMARY KEY(RoomType)
);

INSERT INTO [RoomTypes] VALUES
	('Small', NULL),
	('Medium', NULL),
	('Big', NULL);


CREATE TABLE [BedTypes](
	BedType VARCHAR(10),
	Notes TEXT

	CONSTRAINT PK_BedTypes PRIMARY KEY(BedType)
);

INSERT INTO [BedTypes] VALUES
	('Single', NULL),
	('Double', NULL),
	('DoubleX2', NULL);


CREATE TABLE [Rooms](
	RoomNumber INT IDENTITY(100, 1), 
	RoomType VARCHAR(10) REFERENCES [RoomTypes]([RoomType]), 
	BedType VARCHAR(10) REFERENCES [BedTypes]([BedType]), 
	Rate DECIMAL(5, 2) NOT NULL, 
	RoomStatus BIT, 
	Notes TEXT,

	CONSTRAINT PK_Rooms PRIMARY KEY(RoomNumber)	
);

INSERT INTO [Rooms] VALUES
	('Small', 'Single', 75.00, 'True', NULL),
	('Medium', 'Double', 95.00, 'False', NULL),
	('Big', 'DoubleX2', 110.00, 'False', NULL);


CREATE TABLE [Payments](
	Id INT IDENTITY,
	EmployeeId INT REFERENCES [Employees]([Id]), 
	PaymentDate DATE NOT NULL, 
	AccountNumber INT REFERENCES [Customers]([AccountNumber]), 
	FirstDateOccupied DATE NOT NULL, 
	LastDateOccupied DATE NOT NULL, 
	TotalDays INT NOT NULL, 
	AmountCharged DECIMAL(6, 2) NOT NULL, 
	TaxRate INT DEFAULT(0.20), 
	TaxAmount DECIMAL(6, 2),
	PaymentTotal DECIMAL(6, 2),
	Notes TEXT,

	CONSTRAINT PK_Payments PRIMARY KEY(Id)
);

INSERT INTO [Payments]
	(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged)
VALUES
	(3, '2023-01-02', 1, '2023-01-01', '2023-01-02', 1, 75.00),
	(3, '2023-02-02', 1, '2023-02-01', '2023-02-02', 1, 95.00),	
	(3, '2023-03-02', 1, '2023-03-01', '2023-03-02', 1, 110.00);


CREATE TABLE [Occupancies](
	Id INT IDENTITY, 
	EmployeeId INT REFERENCES [Employees]([Id]), 
	DateOccupied DATE, 
	AccountNumber INT REFERENCES [Customers]([AccountNumber]), 
	RoomNumber INT REFERENCES [Rooms]([RoomNumber]), 
	RateApplied Decimal(3, 2), 
	PhoneCharge VARCHAR(12), 
	Notes TEXT,

	CONSTRAINT PK_Occupancies PRIMARY KEY(Id)
);

INSERT INTO [Occupancies] VALUES
	(1, '2023-01-01', 1, 100, NULL, '088888888', NULL),
	(2, '2023-02-01', 2, 101, NULL, '031314445', NULL),
	(3, '2023-03-01', 3, 102, NULL, '032131231', NULL);