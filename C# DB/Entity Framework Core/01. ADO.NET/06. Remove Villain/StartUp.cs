using _06._Remove_Villain;
using Microsoft.Data.SqlClient;

int villainId = int.Parse(Console.ReadLine());

await using SqlConnection sqlConnection = new SqlConnection(Config.SqlConnection);
sqlConnection.Open();

SqlCommand getVillainName = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @villainId", sqlConnection);
getVillainName.Parameters.AddWithValue("@villainId", villainId);
string? villainName = (string?)await getVillainName.ExecuteScalarAsync();

if (villainName == null)
{
    Console.WriteLine("No such villain was found.");
    return;
}

SqlCommand selectMinions =
    new SqlCommand(@"SELECT COUNT(MinionId) FROM MinionsVillains WHERE VillainId = @villainId", sqlConnection);
selectMinions.Parameters.AddWithValue("@villainId", villainId);
int? minionsReleased = (int?)await selectMinions.ExecuteScalarAsync();

SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
try
{
    DeleteVillainAndReleaseMinions(villainId, sqlConnection, sqlTransaction);
    await sqlTransaction.CommitAsync();
}
catch (Exception ex)
{
    await sqlTransaction.RollbackAsync();
    return;
}

Console.WriteLine($"{villainName} was deleted.");
Console.WriteLine($"{minionsReleased} minions were released.");

static async void DeleteVillainAndReleaseMinions(int villainId, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
{
    SqlCommand releaseMinions =
        new SqlCommand(@"DELETE FROM MinionsVillains WHERE VillainId = @villainId", sqlConnection, sqlTransaction);
    releaseMinions.Parameters.AddWithValue("@villainId", villainId);
    await releaseMinions.ExecuteNonQueryAsync();

    SqlCommand deleteVillain = new SqlCommand(@"DELETE FROM Villains WHERE Id = @villainId", sqlConnection, sqlTransaction);
    deleteVillain.Parameters.AddWithValue("@villainId", villainId);
    await deleteVillain.ExecuteNonQueryAsync();
}