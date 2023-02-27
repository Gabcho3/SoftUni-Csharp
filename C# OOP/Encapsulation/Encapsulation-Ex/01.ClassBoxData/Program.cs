using System;

namespace _01.ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box box = new Box();

            for(int i = 0; i < 3; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 0:
                            box.Length = double.Parse(Console.ReadLine());
                            break;
                        case 1:
                            box.Width = double.Parse(Console.ReadLine());
                            break;
                        case 2:
                            box.Height = double.Parse(Console.ReadLine());
                            break;
                    }
                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}" +
                $"\nLateral Surface Area - {box.LateralSurfaceArea():f2}" +
                $"\nVolume - {box.Volume():f2}");
        }
    }
}
