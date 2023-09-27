CREATE DATABASE NationalTouristSitesOfBulgaria
GO
USE NationalTouristSitesOfBulgaria;

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE Locations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Municipality VARCHAR(50),
	Province VARCHAR(50)
);

CREATE TABLE Sites(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	LocationId INT REFERENCES Locations(Id) NOT NULL,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	Establishment VARCHAR(15)
);

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Reward VARCHAR(20),

	CONSTRAINT Ch_Age_Between_0_100 CHECK (Age >= 0 AND Age <= 120)
);

CREATE TABLE SitesTourists(
	TouristId INT REFERENCES Tourists(Id) NOT NULL,
	SiteId INT REFERENCES Sites(Id) NOT NULL,

	CONSTRAINT PK_Sites_Tourists 
		PRIMARY KEY(TouristId, SiteId)
);

CREATE TABLE BonusPrizes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE TouristsBonusPrizes(
	TouristId INT REFERENCES Tourists(Id) NOT NULL,
	BonusPrizeId INT REFERENCES BonusPrizes(Id) NOT NULL,

	CONSTRAINT PK_Tourists_BonusPrizes 
		PRIMARY KEY(TouristId, BonusPrizeId)
);