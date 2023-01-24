namespace T02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> addAndprint = names =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine("Sir " + name);
                }
            };
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            addAndprint(names);
        }
    }
}