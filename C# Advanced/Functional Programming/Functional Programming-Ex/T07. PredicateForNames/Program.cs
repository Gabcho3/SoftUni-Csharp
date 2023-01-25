namespace T07._PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string[], int, List<string>> sortingNames = (names, l) =>
            {
                var result = new List<string>();
                foreach(var name in names)
                {
                    if (name.Length <= l)
                        result.Add(name);
                }

                return result;
            };

            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Console.WriteLine(string.Join(Environment.NewLine, sortingNames(names, length)));
        }
    }
}