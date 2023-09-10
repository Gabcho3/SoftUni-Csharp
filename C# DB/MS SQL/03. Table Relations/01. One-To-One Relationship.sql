CREATE TABLE Passports(
	PassportId INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber CHAR(8)
);

INSERT INTO Passports 
VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2');

CREATE TABLE Persons(
	PersonId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20),
	Salary DECIMAL(7, 2),
	PassportId INT REFERENCES [Passports](PassportId)
);

INSERT INTO Persons
VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101);