using _06._Print_All_Minions_Names;
using Microsoft.Data.SqlClient;

await using SqlConnection sqlConnection = new SqlConnection(Config.SqlConnection);
sqlConnection.Open();

SqlCommand getAllMinionsCount = new SqlCommand(@"SELECT COUNT(Id) FROM Minions", sqlConnection);
int firstMinionsCount = (int)Math.Round((int)await getAllMinionsCount.ExecuteScalarAsync() / 2.0);
int secondMinionsCount = firstMinionsCount - 1;

SqlCommand getFirstMinionsNames = new SqlCommand(@"SELECT TOP(@count) Name FROM Minions", sqlConnection);
getFirstMinionsNames.Parameters.AddWithValue("@count", firstMinionsCount);
SqlDataReader firstMinionsReader = await getFirstMinionsNames.ExecuteReaderAsync();

SqlCommand getSecondMinionsNames = new SqlCommand(@"SELECT TOP(@count) Name FROM Minions ORDER BY Id DESC", sqlConnection);
getSecondMinionsNames.Parameters.AddWithValue("@count", secondMinionsCount);
SqlDataReader secondMinionsReader = await getSecondMinionsNames.ExecuteReaderAsync();

while (firstMinionsReader.Read())
{
    string firstName = (string)firstMinionsReader["Name"];
    string secondName = string.Empty;

    if (secondMinionsReader.Read())
    {
        secondName = (string)secondMinionsReader["Name"];
    }

    Console.WriteLine(firstName + Environment.NewLine + secondName);
}