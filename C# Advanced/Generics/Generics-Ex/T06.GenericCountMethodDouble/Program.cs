namespace T06.GenericCountMethodDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>()
            {
                Doubles = new List<double>()
            };

            for(int i = 0; i < n; i++)
            {
                box.Doubles.Add(double.Parse(Console.ReadLine()));
            }

            double element = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Counter<double>(box.Doubles, element));
        }
    }
}