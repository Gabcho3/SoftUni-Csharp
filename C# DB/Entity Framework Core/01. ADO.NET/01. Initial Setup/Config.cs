using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._Initial_Setup
{
    internal static class Config
    {
        public const string SqlConnection = @"Server=.;Database=MinionsDB;Integrated Security=True;Trust Server Certificate=True";

        public const string GetVillainsNamesAndTheirMinionsQuery = @"
            SELECT
	            v.[Name],
	            COUNT(mv.MinionId) AS MinionsCount
            FROM Villains AS v
	            JOIN MinionsVillains as mv ON v.Id = mv.VillainId
            GROUP BY v.[Name]
            HAVING COUNT(mv.MinionId) > 3
            ORDER BY MinionsCount DESC;";
    }
}
