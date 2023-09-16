CREATE FUNCTION ufn_CalculateFutureValue(
		@Sum DECIMAL(15, 4),
		@Interest FLOAT,
		@Years INT
) RETURNS DECIMAL(18, 4)
AS
BEGIN
	RETURN @Sum * POWER(1 + @Interest, @Years)
END;

GO

--SELECT dbo.ufn_CalculateFutureValue (1000, 0.10, 5)
--1610.5100
