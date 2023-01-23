using System.Reflection;

namespace T02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> sum = arr => new int[2] { arr.Count(), arr.Sum() };
            Console.WriteLine(string.Join(Environment.NewLine, 
                sum(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray())));
        }
    }
}