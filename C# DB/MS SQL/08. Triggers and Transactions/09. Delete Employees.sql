CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL, 
	LastName VARCHAR(30) NOT NULL, 
	MiddleName VARCHAR(30), 
	JobTitle VARCHAR(30) NOT NULL, 
	DepartmentId INT REFERENCES Departments(DepartmentId) NOT NULL,
	Salary MONEY NOT NULL
);

CREATE TRIGGER tr_AddDeletedEmployeesToTable
ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees
	SELECT
		FirstName, LastName, MiddleName, 
		JobTitle, DepartmentId, Salary
	FROM deleted
END;