using System;

namespace T05.EasterEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());
            int red = 0;
            int orange = 0;
            int blue = 0;
            int green = 0;
            int maxEggs = int.MinValue;
            string max = "";

            for(int egg = 1; egg <= eggs; egg++)
            {
                string colour = Console.ReadLine();
                switch(colour)
                {
                    case "red": red++; if (red > maxEggs) { maxEggs = red; max = colour; }
                        break;
                    case "orange": orange++; if (orange > maxEggs) { maxEggs = orange; max = colour; }
                        break;
                    case "blue": blue++; if (blue > maxEggs) { maxEggs = blue; max = colour; }
                        break;
                    case "green": green++; if (green > maxEggs) { maxEggs = green; max = colour; }
                        break;
                }
            }
            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {max}");
        }
    }
}
