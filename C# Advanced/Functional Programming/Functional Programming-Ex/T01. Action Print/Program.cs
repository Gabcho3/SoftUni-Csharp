namespace T01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = arr => Console.WriteLine(string.Join(Environment.NewLine, arr));
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            print(input);
        }
    }
}