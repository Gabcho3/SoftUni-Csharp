using _04._Minion_Names;
using Microsoft.Data.SqlClient;

string[] minnionInfo = Console.ReadLine().Split(' ').Skip(1).ToArray();
string minionName = minnionInfo[0];
int age = int.Parse(minnionInfo[1]);
string townName = minnionInfo[2];
string villainName = Console.ReadLine().Split(' ')[1];

await using SqlConnection sqlConnection = new SqlConnection(Config.SqlConnection);
await sqlConnection.OpenAsync();
    
int villainId = AddVillainIfNeeded();
int townId = AddTownIfNeeded();
AddMinion();

int AddVillainIfNeeded()
{
    SqlCommand findVillainId = new SqlCommand(@"SELECT Id FROM Villains WHERE Name = @Name", sqlConnection);
    findVillainId.Parameters.AddWithValue("@Name", villainName);
    object? id = findVillainId.ExecuteScalar();

    if (id == null)
    {
        SqlCommand addNewVillain = new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", sqlConnection);
        addNewVillain.Parameters.AddWithValue("@villainName", villainName);
        addNewVillain.ExecuteNonQueryAsync();
        Console.WriteLine($"Villain {villainName} was added to the database.");
    }
    return (int)findVillainId.ExecuteScalar();
}

int AddTownIfNeeded()
{
    SqlCommand findTownId = new SqlCommand(@"SELECT Id FROM Towns WHERE Name = @townName", sqlConnection);
    findTownId.Parameters.AddWithValue("@townName", townName);
    object? id = findTownId.ExecuteScalar();

    if (id == null)
    {
        SqlCommand addNewTown = new SqlCommand(@"INSERT INTO Towns (Name) VALUES (@townName)", sqlConnection);
        addNewTown.Parameters.AddWithValue("@townName", townName);
        addNewTown.ExecuteNonQueryAsync();
        Console.WriteLine($"Town {townName} was added to the database.");
    }
    return (int)findTownId.ExecuteScalar();
}

void AddMinion()
{
    SqlCommand insertMinion = new SqlCommand(@"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)", sqlConnection);
    insertMinion.Parameters.AddWithValue("@name", minionName);
    insertMinion.Parameters.AddWithValue("@age", age);
    insertMinion.Parameters.AddWithValue("@townId", townId);
    insertMinion.ExecuteNonQueryAsync();

    SqlCommand findMinionId = new SqlCommand(@"SELECT Id FROM Minions WHERE Name = @Name", sqlConnection);
    findMinionId.Parameters.AddWithValue("@Name", minionName);
    int minionId = (int)findMinionId.ExecuteScalar();
    

    SqlCommand addMinnionToVillain = new SqlCommand(@"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", sqlConnection);
    addMinnionToVillain.Parameters.AddWithValue("@minionId", minionId);
    addMinnionToVillain.Parameters.AddWithValue("@villainId", villainId);
    addMinnionToVillain.ExecuteNonQueryAsync();

    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
}