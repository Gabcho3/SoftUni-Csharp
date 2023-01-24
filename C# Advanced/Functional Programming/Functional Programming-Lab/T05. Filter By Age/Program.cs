using System.Net.WebSockets;

namespace T05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            Func<Person, string, int, bool> ageFilter = (p, c, a) => c == "older" ? p.Age >= a : p.Age < a; //p -> person, c -> condition, a -> age
            Func<Person, string[], string> formater = (p, arr) =>
            {
                string output = string.Empty;
                if (arr.Length == 1)
                {
                    if (arr[0] == "name")
                        output = "{0}";

                    else
                        output = "{1}";
                }

                else
                {
                    output = "{0} - {1}";
                }

                return string.Format(output, p.Name, p.Age);
            };

            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person() { Name = data[0], Age = int.Parse(data[1]) });
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine().Split();

            Console.WriteLine(string.Join(Environment.NewLine, 
                people.Where(p => ageFilter(p, condition, age))
                .Select(p => formater(p, format))));
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}