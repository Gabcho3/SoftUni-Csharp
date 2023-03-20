namespace T08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Threeuple<string, string, string> threeuple1 = new Threeuple<string, string, string>()
            {
                First = string.Join(" ", input.Split().Take(2)),
                Second = input.Split()[2],
                Third = input.Split()[3]
            };

            input = Console.ReadLine();
            bool isDrunk = input.Split()[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> threeuple2 = new Threeuple<string, int, bool>()
            {
                First = input.Split()[0],
                Second = int.Parse(input.Split()[1]),
                Third = isDrunk
            };

            input = Console.ReadLine();
            Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>()
            {
                First = input.Split()[0],
                Second = double.Parse(input.Split()[1]),
                Third = input.Split()[2]
            };

            Console.WriteLine(threeuple1);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);
        }
    }
}