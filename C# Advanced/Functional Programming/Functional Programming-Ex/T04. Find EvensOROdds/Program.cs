namespace T04._Find_EvensOROdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> odd = n => n % 2 != 0;
            Predicate<int> even = n => n % 2 == 0;

            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool isOdd = Console.ReadLine() == "odd";

            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            if (isOdd)
            {
                numbers = numbers.FindAll(odd);
            }

            else
            {
                numbers = numbers.FindAll(even);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}