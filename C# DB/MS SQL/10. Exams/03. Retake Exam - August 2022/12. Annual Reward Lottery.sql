CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
	DECLARE @TouristId INT = (SELECT Id FROM Tourists WHERE [Name] = @TouristName);
	DECLARE @VisitedSites INT = 
		(
			SELECT COUNT(st.SiteId)
			FROM Tourists AS t
				JOIN SitesTourists AS st ON t.Id = st.TouristId
			WHERE t.Id = @TouristId
		);

	UPDATE Tourists
		SET Reward = 
		(
			CASE 
				WHEN @VisitedSites >= 100 THEN 'Gold badge'
				WHEN @VisitedSites >= 50 THEN 'Silver badge'
				WHEN @VisitedSites >= 25 THEN 'Bronze badge'
			END
		)
	WHERE Id = @TouristId;

	SELECT 
		[Name],
		Reward
	FROM Tourists
	WHERE Id = @TouristId;
END;