namespace T04._Generic_Swap_Method_Integer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> items = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int integer = int.Parse(Console.ReadLine());
                items.Add(integer);
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            items = Swap(items, indexes[0], indexes[1]);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        public static List<T> Swap<T>(List<T> items, int index1, int index2)
        {
            T item1 = items[index1];
            items[index1] = items[index2];
            items[index2] = item1;

            return items;
        }
    }
}