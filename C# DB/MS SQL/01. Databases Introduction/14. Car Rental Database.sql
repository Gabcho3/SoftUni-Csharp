Create DATABASE [CarRental];

GO
USE [CarRental];

CREATE TABLE [Categories](
	[Id] INT IDENTITY, 
	[CategoryName] VARCHAR(20) NOT NULL, 
	[DailyRate] DECIMAL(5, 2) NOT NULL,
	[WeeklyRate] DECIMAL(6, 2) NOT NULL, 
	[MonthlyRate] DECIMAL(7, 2) NOT NULL, 
	[WeekendRate] DECIMAL(5, 2),

	CONSTRAINT PK_Categories PRIMARY KEY(Id)
);

INSERT INTO [Categories] VALUES
	('Sports Car', 100.00, 700.00, 10000.00, 120.00),
	('Coupe', 82.00, 640.00, 3000.00, NULL),
	('Sedan', 70.00, 400.00, 2500.00, NULL);



CREATE TABLE [Cars](
	Id INT IDENTITY,
	PlateNumber CHAR(8) NOT NULL,
	Manufacturer VARCHAR(20) NOT NULL,
	Model VARCHAR(20) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT REFERENCES [Categories]([Id]),
	Doors INT,
	Picture BINARY,
	Condition TEXT,
	Available BIT NOT NULL

	CONSTRAINT PK_Cars PRIMARY KEY(Id)
);

INSERT INTO [Cars] VALUES
	('CB1234PK', 'BMW', 'M2', 2023, 2, 4, NULL, NULL, 'True'),
	('EA9999CA', 'AUDI', 'R8', 2022, 1, 4, NULL, NULL, 'False'),
	('CA3291XS', 'Toyota', 'Corolla', 2017, 3, 4, NULL, NULL, 'True');



CREATE TABLE [Employees](
	[Id] INT IDENTITY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Title] VARCHAR(20),
	[Notes] TEXT,

	CONSTRAINT PK_Employees PRIMARY KEY(Id)
);

INSERT INTO [Employees] VALUES
	('George', 'Ivanov', NULL, NULL),
	('Ivan', 'Georgiev', NULL, NULL),
	('Gancho', 'Ganchev', NULL, NULL);



CREATE TABLE [Customers](
	[Id] INT IDENTITY,
	[DriverLicenceNumber] VARCHAR(10) NOT NULL,
	[FullName] VARCHAR(70) NOT NULL,
	[Address] TEXT,
	[City] TEXT NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] TEXT,

	CONSTRAINT PK_Customers PRIMARY KEY(Id)
);

INSERT INTO [Customers] VALUES
	('124d42', 'Ivan Ivanov Dimitrov', NULL, 'Plovdiv', '1619', NULL),
	('124d42', 'Grozdan Momchilov Todorov', NULL, 'Varna', '1788', NULL),
	('6D4E66', 'Dimitar Georgiev Ivanov', NULL, 'Sofia', '1600', NULL);



CREATE TABLE [RentalOrders](

	Id INT IDENTITY,
	EmployeeId INT REFERENCES [Employees]([Id]),
	CustomerId INT REFERENCES [Customers]([Id]),
	CarId INT REFERENCES [Cars]([Id]),
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(5, 2) NOT NULL,
	TaxRate DECIMAL(7, 2) NOT NULL,
	OrderStatus BIT NOT NULL,
	Notes TEXT,

	CONSTRAINT PK_RentalOrders PRIMARY KEY(Id)
);

INSERT INTO [RentalOrders] VALUES
	(1, 2, 3, 50, 0, 200, 200, '2023-02-05', '2023-02-06', 1, 10.02, 70.00 , 'True', NULL),
	(3, 1, 1, 43, 100, 300, 200, '2023-07-01', '2023-07-07', 7, 20.02, 700.00 , 'True', NULL),
	(2, 3, 2, 60, 90, 120, 30, '2023-09-02', '2023-09-03', 1, 12.02,  82.00, 'True', NULL);
