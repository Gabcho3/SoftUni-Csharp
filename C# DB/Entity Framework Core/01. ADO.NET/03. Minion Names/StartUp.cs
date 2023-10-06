using System.Text;
using _03._Minion_Names;
using Microsoft.Data.SqlClient;

await using SqlConnection sqlConnection =
    new SqlConnection(Config.SqlConnection);

await sqlConnection.OpenAsync();
int id = int.Parse(Console.ReadLine());

string result = await GetMinionsOfVillain(sqlConnection, id);
Console.WriteLine(result);

static async Task<string> GetMinionsOfVillain(SqlConnection sqlConnection, int id)
{
    StringBuilder sb = new StringBuilder();

    SqlCommand villainNames = new SqlCommand(@Config.GetVillainsNames, sqlConnection);
    SqlCommand villainMinions = new SqlCommand(Config.GetMinionsOfVillain, sqlConnection);

    villainNames.Parameters.AddWithValue("@Id", id);
    villainMinions.Parameters.AddWithValue("@Id", id);

    object villainName = await villainNames.ExecuteScalarAsync();
    if (villainName == null)
    {
        return $"No villain with ID {id} exists in the database.";
    }
    sb.AppendLine("Villain: " + (string)villainName);

    SqlDataReader minionsReader = await villainMinions.ExecuteReaderAsync();

    if (!minionsReader.HasRows)
    {
        sb.AppendLine("(no minions)");
    }
    else
    {
        while (minionsReader.Read())
        {
            long rowNum = (long)minionsReader["RowNum"];
            string minionName = minionsReader["Name"].ToString();
            int age = (int)minionsReader["Age"];

            sb.AppendLine($"{rowNum}. {minionName} {age}");
        }
    }
    return sb.ToString().TrimEnd();
}