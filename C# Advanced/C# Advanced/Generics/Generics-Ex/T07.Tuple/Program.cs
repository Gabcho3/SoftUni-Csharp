namespace T07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Tuple<string, string> tuple1 = new Tuple<string, string>()
            {
                Item1 = input[0] + " " + input[1],
                Item2 = input[2]
            };

            input = Console.ReadLine().Split();
            Tuple<string, int> tuple2 = new Tuple<string, int>()
            {
                Item1 = input[0],
                Item2 = int.Parse(input[1])
            };

            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Tuple<int, double> tuple3 = new Tuple<int, double>()
            {
                Item1 = (int)nums[0],
                Item2 = nums[1]
            };

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}