using System;

namespace T07._Safe_Passwords_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            char A = '#';
            char B = '@';
            int x = 1;
            int y = 1;
            int count = 0;
            while(true)
            {
                for (int pass = 1; pass <= max; pass++,A++,B++,y++)
                {
                    if (A > 55) A = '#';
                    if (B > 96) B = '@';
                    Console.Write(A);
                    Console.Write(B);
                    Console.Write(x);
                    Console.Write(y);
                    Console.Write(B);
                    Console.Write(A);
                    Console.Write("|");
                    if(x == a && y == b)
                    {
                        break;
                    }  
                    if (y == b)
                    {
                        y = 0; 
                        x++;
                    }
                }
                break;
            }
        }
    }
}
