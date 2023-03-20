namespace T03._Count_Uppercase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isStartingWithUpper = w => char.IsUpper(w[0]);
            Console.WriteLine(string.Join(Environment.NewLine
                ,Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isStartingWithUpper(w))
                .ToArray()));
        }
    }
}