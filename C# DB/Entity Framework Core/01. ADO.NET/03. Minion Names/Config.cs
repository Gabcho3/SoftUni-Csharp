namespace _03._Minion_Names
{
    internal static class Config
    {
        public const string SqlConnection = @"Server=.;Database=MinionsDB;Integrated Security=True;Trust Server Certificate=True";
        public const string GetVillainsNames = @"SELECT [Name] FROM Villains WHERE Id = @Id";

        public const string GetMinionsOfVillain =
            @"SELECT 
	            ROW_NUMBER() OVER (ORDER BY m.[Name]) AS RowNum,
	            m.[Name], 
	            m.Age
            FROM MinionsVillains AS mv
	            JOIN Minions As m ON mv.MinionId = m.Id
            WHERE mv.VillainId = @Id
            ORDER BY m.[Name];";
    }
}
