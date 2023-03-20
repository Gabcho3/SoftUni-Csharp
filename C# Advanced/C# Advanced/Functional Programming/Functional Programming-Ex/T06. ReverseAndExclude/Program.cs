namespace T06._ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> reverse = i => i.Reverse().ToArray();
            Func<int, int, bool> remove = (i, n) => i % n != 0;

            int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divideBy = int.Parse(Console.ReadLine());

            ints = ints.Where(x => remove(x, divideBy)).ToArray();

            Console.WriteLine(string.Join(" ", reverse(ints)));
        }
    }
}