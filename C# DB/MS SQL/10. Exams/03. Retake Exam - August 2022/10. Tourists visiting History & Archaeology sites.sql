SELECT
	SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name], 1) + 1, LEN(t.[Name])) AS LastName,
	t.Nationality,
	t.Age,
	t.PhoneNumber
FROM Tourists AS t
	JOIN SitesTourists AS st ON t.Id = st.TouristId
	JOIN Sites AS s ON st.SiteId = s.Id
	JOIN Categories AS c ON s.CategoryId = c.Id
WHERE c.[Name] = 'History and archaeology'
GROUP BY t.[Name], t.Age, t.Nationality, t.PhoneNumber
ORDER BY LastName;
