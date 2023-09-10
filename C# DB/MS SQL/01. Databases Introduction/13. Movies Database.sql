CREATE DATABASE [Movies];

GO
USE [Movies];

CREATE TABLE [Directors](
	[Id] INT IDENTITY,
	[DirectorName] VARCHAR(40) NOT NULL,
	[Notes] TEXT

	CONSTRAINT PK_Directors PRIMARY KEY(Id)
);

CREATE TABLE [Genres] (
	[Id] INT IDENTITY,
	[GenreName] VARCHAR(40) NOT NULL,
	[Notes] TEXT

	CONSTRAINT PK_Genres PRIMARY KEY(Id)
);

CREATE TABLE [Categories] (
	[Id] INT IDENTITY,
	[CategoryName] VARCHAR(40) NOT NULL,
	[Notes] TEXT

	CONSTRAINT PK_Categories PRIMARY KEY(Id)
);

CREATE TABLE [Movies] (
	[Id] INT IDENTITY,
	[Title] VARCHAR(40) NOT NULL,
	[DirectorId] INT REFERENCES [Directors]([Id]),
	[CopyrightYear] INT NOT NULL,
	[Length] INT NOT NULL,
	[GenreId] INT REFERENCES [Genres]([Id]),
	[CategoryId] INT REFERENCES [Categories]([Id]),
	[Rating] DECIMAL(2, 1),
	[Notes] TEXT,

	CONSTRAINT PK_Movies PRIMARY KEY(Id)
);

GO

INSERT INTO Directors (DirectorName, Notes)
VALUES 
('John Smith', 'Experienced director with a track record of successful films.'),
('Jane Doe', 'Up-and-coming director known for innovative storytelling.'),
('Michael Johnson', 'Director with a passion for action-packed blockbusters.'),
('Emily Wong', 'Award-winning director known for her thought-provoking dramas.'),
('Robert Davis', 'Veteran director specializing in historical documentaries.');

INSERT INTO Genres (GenreName, Notes)
VALUES ('Action', 'Genre known for its fast-paced and thrilling content.'),
('Drama', 'Genre focusing on character-driven narratives and emotions.'),
('Comedy', 'Genre intended to make the audience laugh and entertain.'),
('Science Fiction', 'Genre exploring futuristic and speculative concepts.'),
('Horror', 'Genre designed to evoke fear and suspense.');

INSERT INTO Categories (CategoryName, Notes)
VALUES ('Action', 'Category for high-energy, adrenaline-pumping movies.'),
('Romance', 'Category centered around love and romantic relationships.'),
('Adventure', 'Category featuring exciting journeys and exploration.'),
('Fantasy', 'Category involving magical and otherworldly elements.'),
('Documentary', 'Category for non-fiction, factual films.');

INSERT INTO Movies VALUES 
('The Action Hero', 1, 2020, 120, 2, 3, 9.3, 'A thrilling action movie.'),
('Love in Paris', 2, 2019, 95, 3, 2, 8.2, 'A heartwarming romantic comedy.'),
('Journey to the Unknown', 3, 2022, 150, 1, 3, 4.5, 'An epic adventure film.'),
('The Wizard Quest', 4, 2021, 130, 3, 1, 7.5,'A fantasy movie with magical elements.'),
('Planet Earth: A Documentary', 5, 2018, 180, 1, 2, 6.9, 'A nature and wildlife documentary.');
