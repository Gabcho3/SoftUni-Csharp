namespace T11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> func = (n, s) =>
            {
                int sum = 0;

                foreach(var ch in n)
                {
                    sum += ch;
                }

                return sum >= s;
            };

            Action<string[]> printFirstName = names => { Console.WriteLine(names[0]); };

            int neededSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().Where(x => func(x, neededSum)).ToArray();
            printFirstName(names);
        }
    }
}