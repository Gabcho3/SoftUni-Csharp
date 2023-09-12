CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Birthdate DATE NOT NULL
);

--Records made by ChatGPT
INSERT INTO People([Name], Birthdate)
VALUES
    ('John Smith', '1990-05-15'),
    ('Jane Doe', '1985-12-10'),
    ('Michael Johnson', '1992-08-25'),
    ('Emily Wilson', '1988-03-20'),
    ('Robert Brown', '1995-07-02'),
    ('Susan Davis', '1998-01-08'),
    ('David Lee', '1982-11-12'),
    ('Jennifer White', '1993-09-30'),
    ('William Clark', '1987-04-05'),
    ('Linda Harris', '1997-06-18'),
    ('James Taylor', '1991-02-14'),
    ('Karen Anderson', '1986-10-22'),
    ('Richard Martinez', '1996-12-03'),
    ('Patricia Hall', '1983-07-28'),
    ('Charles Jackson', '1989-09-08'),
    ('Margaret Garcia', '1994-04-17'),
    ('Thomas Adams', '1984-06-23'),
    ('Nancy Miller', '1999-10-11'),
    ('Daniel Wilson', '1981-03-05'),
    ('Elizabeth Turner', '1990-08-07'),
    ('Matthew Harris', '1987-11-28'),
    ('Jessica Thompson', '1995-01-19'),
    ('Kevin Martinez', '1982-05-14'),
    ('Dorothy Baker', '1997-02-01'),
    ('Joseph Allen', '1993-04-30'),
    ('Sandra Young', '1986-09-09'),
    ('George Scott', '1998-07-12'),
    ('Mary Adams', '1984-12-25'),
    ('Christopher Davis', '1991-06-03'),
    ('Lisa Wilson', '1988-10-16');

SELECT 
	[Name],
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People
