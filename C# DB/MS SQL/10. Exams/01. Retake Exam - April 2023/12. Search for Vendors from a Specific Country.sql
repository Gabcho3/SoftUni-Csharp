CREATE PROC usp_SearchByCountry(@country NVARCHAR(10))
AS
BEGIN
	SELECT
		v.[Name] AS Vendor
		,v.NumberVAT AS VAT
		,CONCAT_WS(' ', a.StreetName, a.StreetNumber) AS [Street Info]
		,CONCAT_WS(' ', a.City, a.PostCode) AS [City Info]
	FROM Addresses AS a
		JOIN Countries AS c ON a.CountryId = c.Id
		JOIN Vendors AS v ON a.Id = v.AddressId
	WHERE c.[Name] = @country
	ORDER BY Vendor, a.City
END;
