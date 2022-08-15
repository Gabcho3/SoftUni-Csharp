using System;

namespace T07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //length * hight * wwidth one carton
            //every loop -->input to int cartons
            //if(input = Done) ""{брой свободни куб. метри} Cubic meters left."
            //if(NoSpace bool) "No more free space! You need {брой недостигащи куб. метри} Cubic meters more."
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            int totalSpace = width * length * hight;

            int occupiedSpace = 0;
            bool NoSpace = false;

            string input = Console.ReadLine();
            while(input != "Done")
            {
                NoSpace = false;
                int cartons = int.Parse(input);
                occupiedSpace += cartons;
                if(occupiedSpace > totalSpace)
                {
                    NoSpace = true;
                    break;
                }
                input = Console.ReadLine();
            }
            if(NoSpace)
            {
                Console.WriteLine($"No more free space! You need {occupiedSpace - totalSpace} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{totalSpace - occupiedSpace} Cubic meters left.");
            }
        }
    }
}
