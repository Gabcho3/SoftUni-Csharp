namespace T03._CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> findSmallest = nums => //OR -> nums => nums.Min
            {
                int minValue = int.MaxValue;

                foreach(int num in nums)
                {
                    if (num < minValue)
                        minValue = num;
                }

                return minValue;
            };
            int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(findSmallest(ints));
        }
    }
}