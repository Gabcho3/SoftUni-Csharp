CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL
);

INSERT INTO Students
VALUES
	('Mila'), ('Toni'), ('Ron');

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(20) NOT NULL
);

INSERT INTO Exams
VALUES
	('SpringMVC'), ('Neo4j'), ('Oracle 11g');

CREATE TABLE StudentsExams(
	StudentID INT REFERENCES Students(StudentID),
	ExamID INT REFERENCES Exams(ExamID)

	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
);

INSERT INTO StudentsExams
VALUES
	(1, 101), (1, 102), (2, 101), 
	(3, 103), (2, 102), (2, 103);