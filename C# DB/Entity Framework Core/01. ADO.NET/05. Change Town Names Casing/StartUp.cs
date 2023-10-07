using _05._Change_Town_Names_Casing;
using Microsoft.Data.SqlClient;

string countryName = Console.ReadLine();

await using SqlConnection sqlConnection = new SqlConnection(Config.SqlConnection);
sqlConnection.Open();

int affectedRows = await ChangeTownNames(countryName, sqlConnection);

if (affectedRows > 1)
{
    Console.WriteLine($"{affectedRows} town names were affected.");
}
else
{
    Console.WriteLine("No town names were affected.");
    return;
}

List<string> towns = await GetTownsNames(countryName, sqlConnection);
Console.WriteLine($"[{string.Join(", ", towns)}]");

static async Task<int> ChangeTownNames(string countryName, SqlConnection sqlConnection)
{
    SqlCommand changeTownsNames = new SqlCommand(
        @"UPDATE Towns 
        SET Name = UPPER(Name) 
    WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", sqlConnection);

    changeTownsNames.Parameters.AddWithValue("@countryName", countryName);
    return await changeTownsNames.ExecuteNonQueryAsync();
}

static async Task<List<string>> GetTownsNames(string countryName, SqlConnection sqlConnection)
{
    List<string> townsList = new List<string>();

    SqlCommand selectTowns = new SqlCommand(
        @"SELECT t.Name 
    FROM Towns as t
        JOIN Countries AS c ON c.Id = t.CountryCode
    WHERE c.Name = @countryName", sqlConnection);

    selectTowns.Parameters.AddWithValue("@countryName", countryName);

    SqlDataReader townsReader = await selectTowns.ExecuteReaderAsync();

    while(townsReader.Read())
    {
        townsList.Add(townsReader["Name"].ToString());
    }

    return townsList;
}

