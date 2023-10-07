using _09._Increase_Age_Stored_Procedure;
using Microsoft.Data.SqlClient;

int minionId = int.Parse(Console.ReadLine());

await using SqlConnection sqlConnection = new SqlConnection(Config.SqlConnection);
sqlConnection.Open();

SqlCommand increaseAgeByOneByProc = new SqlCommand(@"EXEC usp_GetOlder @Id", sqlConnection);
increaseAgeByOneByProc.Parameters.AddWithValue("@Id", minionId);
increaseAgeByOneByProc.ExecuteNonQuery();

SqlCommand selectMinion = new SqlCommand(@"SELECT Name, Age FROM Minions WHERE Id = @Id", sqlConnection);
selectMinion.Parameters.AddWithValue("@Id", minionId);
SqlDataReader minionReader = selectMinion.ExecuteReader();

while (minionReader.Read())
{
    string name = minionReader["Name"].ToString();
    int age = (int)minionReader["Age"];
    Console.WriteLine($"{name} - {age} years old");
}
