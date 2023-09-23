SELECT
	curr.CurrencyCode
	,curr.[Description] AS Currency
	,COUNT(c.CountryCode) AS NumberOfCountries
FROM Currencies AS curr
	LEFT JOIN Countries AS c ON curr.CurrencyCode = c.CurrencyCode
GROUP BY curr.CurrencyCode, curr.[Description]
ORDER BY COUNT(c.CountryCode) DESC, curr.[Description]
