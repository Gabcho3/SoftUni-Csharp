CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @Level  VARCHAR(7) = 'Average';

	IF (@Salary < 30000) 
		SET @Level = 'Low'

	ELSE IF(@Salary > 50000)
		SET @Level = 'High'

	RETURN @Level;
END;

--SELECT FirstName, Salary, dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel FROM Employees