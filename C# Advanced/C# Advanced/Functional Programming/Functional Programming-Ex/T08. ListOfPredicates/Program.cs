namespace T08._ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, List<int>> numsInRange = r =>
            {
                var nums = new List<int>();
                for(int i = 1; i <= r; i++)
                {
                    nums.Add(i);
                }
                return nums;
            };

            Func<int, int[], bool> findNums = (n, d) =>
            {
                bool isDivisible = false;
                foreach(var divider in d)
                {
                    if (n % divider == 0)
                        isDivisible = true;

                    else
                    {
                        isDivisible = false;
                        break;
                    }
                }

                return isDivisible;
            };

            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> nums = numsInRange(range);
            Console.WriteLine(string.Join(" ", nums = nums.Where(x => findNums(x, dividers)).ToList()));
        }
    }
}