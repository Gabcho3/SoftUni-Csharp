using _07._Increase_Minion_Age;
using Microsoft.Data.SqlClient;

int[] ids = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

await using SqlConnection sqlConnection = new SqlConnection(Config.SqlConnection);
sqlConnection.Open();

IncreaseMinionsAgeByOne(sqlConnection, ids);
PrintAllMinions(sqlConnection);
static void IncreaseMinionsAgeByOne(SqlConnection sqlConnection, int[] ids)
{
    SqlCommand increaseAgeByOne = new SqlCommand(@"
    UPDATE Minions
        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
    WHERE Id = @Id", sqlConnection);

    foreach (int id in ids)
    {
        increaseAgeByOne.Parameters.AddWithValue("@Id", id);
        increaseAgeByOne.ExecuteNonQuery();
        increaseAgeByOne.Parameters.Clear();
    }
}

static void PrintAllMinions(SqlConnection sqlConnection)
{
    SqlCommand getAllMinions = new SqlCommand(@"SELECT Name, Age FROM Minions", sqlConnection);
    SqlDataReader minionsReader = getAllMinions.ExecuteReader();

    while (minionsReader.Read())
    {
        string name = (string)minionsReader["Name"];
        int age = (int)minionsReader["Age"];

        Console.WriteLine(name + ' ' + age);
    }
}