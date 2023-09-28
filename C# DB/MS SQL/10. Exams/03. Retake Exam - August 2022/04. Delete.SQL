DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId IN
(
	SELECT BonusPrizeId
	FROM TouristsBonusPrizes AS tb
		JOIN BonusPrizes AS b ON tb.BonusPrizeId = b.Id
	WHERE b.[Name] = 'Sleeping bag'
);


DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag';