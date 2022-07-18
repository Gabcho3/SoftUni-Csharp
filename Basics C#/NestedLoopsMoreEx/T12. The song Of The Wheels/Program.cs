using System;

namespace T12._The_song_Of_The_Wheels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());
            bool correct = false;
            bool found = false;
            int count = 0;
            int pass = 0;
            for(int num = 1111; num <= 9999; num++)
            {
                string number = num.ToString();
                int a = int.Parse(number[0].ToString());
                int b = int.Parse(number[1].ToString());
                int c = int.Parse(number[2].ToString());
                int d = int.Parse(number[3].ToString());

                if (a * b + c * d == M) correct = true;
                else correct = false;
                if (correct)
                {
                    if (a < b) _ = true;
                    else
                    {
                        _ = false; 
                        continue;
                    }
                    if (c > d)
                    {
                        correct = true;
                    }
                    else
                    {
                        _ = false;
                        continue;
                    }
                }
                if (correct)
                {
                    Console.Write($"{a}{b}{c}{d} "); count++;
                }
                if(count == 4 && correct)
                {
                    pass = num;
                    found = true;
                }
            }
            if (count == 0 || count < 4)
            {
                Console.WriteLine();
                Console.WriteLine("No!"); 
                return;
            }
            Console.WriteLine();
            if (found)
            {
                Console.WriteLine($"Password: {pass}");
                return;
            }
        }
    }
}
