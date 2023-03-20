using System.Data;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for(int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);

                people.Add(new Person(name, age));
            }

            Console.WriteLine(string.Join(Environment.NewLine, 
                people.OrderBy(x => x.Name)
                .Where(x => x.Age > 30)
                .ToList()));
        }
    }
}