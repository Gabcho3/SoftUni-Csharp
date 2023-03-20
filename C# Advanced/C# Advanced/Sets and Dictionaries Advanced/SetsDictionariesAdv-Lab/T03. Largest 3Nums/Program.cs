namespace T03. Largest 3Nums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToList();

            if(ints.Count < 3)
            {
                Console.WriteLine(string.Join(" ", ints));
            }

            else
            {
                ints.RemoveRange(3, ints.Count - 3);
                Console.WriteLine(string.Join(" ", ints));
            }
        }
    }
}
