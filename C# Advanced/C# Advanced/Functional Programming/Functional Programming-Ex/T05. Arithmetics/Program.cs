namespace T05._Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> add = n => ++n;
            Func<int, int> multiply = n => n * 2;
            Func<int, int> subtract = n => --n;
            Action<int[]> print = n => Console.WriteLine(string.Join(" ", n));
            Predicate<string> isEnd = s => s == "end" ? true : false;

            int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input;

            while (!isEnd(input = Console.ReadLine()))
            {
                switch(input)
                {
                    case "add":
                        ints = ints.Select(x => add(x)).ToArray();
                        break;

                    case "multiply":
                        ints = ints.Select(x => multiply(x)).ToArray();
                        break;

                    case "subtract":
                        ints = ints.Select(x => subtract(x)).ToArray();
                        break;

                    case "print":
                        print(ints);
                        break;
                }
            }
        }
    }
}