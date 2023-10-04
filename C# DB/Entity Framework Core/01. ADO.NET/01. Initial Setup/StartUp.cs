using System.Text;
using _01._Initial_Setup;
using Microsoft.Data.SqlClient;

await using SqlConnection sqlConnection = 
    new SqlConnection(Config.SqlConnection);

await sqlConnection.OpenAsync();
SqlCommand sqlCommand = new SqlCommand(Config.GetVillainsNamesAndTheirMinionsQuery, sqlConnection);

SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
StringBuilder sb = new StringBuilder();
while (reader.Read())
{
    string villainName = (string)reader["Name"];
    int minionsCount = (int)reader["MinionsCount"];
    sb.Append(villainName + " - " + minionsCount);
}

Console.WriteLine(sb.ToString().TrimEnd());
