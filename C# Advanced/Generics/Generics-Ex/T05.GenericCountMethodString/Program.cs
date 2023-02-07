namespace T05.GenericCountMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for(int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();
                box.Values.Add(item);
            }

            string element = Console.ReadLine();
            Console.WriteLine(box.Counter(box.Values, element));
        }
    }
}