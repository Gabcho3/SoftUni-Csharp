SELECT CountryName, IsoCode 
FROM Countries
WHERE CountryName LIKE REPLICATE(CONCAT_WS('a', '%', '') + '%', 3)
ORDER BY IsoCode;