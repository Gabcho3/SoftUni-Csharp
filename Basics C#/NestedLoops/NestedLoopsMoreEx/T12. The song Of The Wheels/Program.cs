using System;

namespace T12._The_song_Of_The_Wheels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int M = int.Parse(Console.ReadLine());

            bool found = false;

            int count = 0;
            int pass = 0;

            for(int num = 1212; num <= 8998; num++)
            {
                string number = num.ToString();
                int a = int.Parse(number[0].ToString());
                int b = int.Parse(number[1].ToString());
                int c = int.Parse(number[2].ToString());
                int d = int.Parse(number[3].ToString());

                bool correct;

                if (a * b + c * d == M && a < b && c > d)
                    correct = true;
                else
                    correct = false;

                if (correct)
                {
                    Console.Write($"{num} "); 
                    count++;

                    if(count == 4)
                    {
                        pass = num;
                        found = true;
                    }
                }

            }
            Console.WriteLine();

            if (count < 4)
            {
                Console.WriteLine("No!");
            }

            if (found)
            {
                Console.WriteLine($"Password: {pass}");
            }
        }
    }
}
