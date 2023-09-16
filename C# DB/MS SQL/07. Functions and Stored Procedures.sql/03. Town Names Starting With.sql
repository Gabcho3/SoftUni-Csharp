CREATE PROC usp_GetTownsStartingWith 
	@String VARCHAR(20)
AS
BEGIN
	SELECT [Name] AS Town 
	FROM Towns
	WHERE SUBSTRING([Name], 1, LEN(@String)) = @String
END;