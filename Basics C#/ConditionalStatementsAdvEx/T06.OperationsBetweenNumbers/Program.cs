using System;

namespace T06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double N1 = int.Parse(Console.ReadLine());
            double N2 = int.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());
            double result = 00;

            switch (op)
            {
                case '+':
                    if ((N1 + N2) % 2 == 0)
                    {
                        result = N1 + N2;
                        Console.WriteLine($"{N1} + {N2} = {result} - even");
                    }
                    if ((N1 + N2) % 2 != 0)
                    {
                        result = N1 + N2;
                        Console.WriteLine($"{N1} + {N2} = {result} - odd");
                    }
                    break;

                case '-':
                    if ((N1 - N2) % 2 == 0)
                    {
                        result = N1 - N2;
                        Console.WriteLine($"{N1} - {N2} = {result} - even");
                    }
                    if ((N1 - N2) % 2 != 0)
                    {
                        result = N1 - N2;
                        Console.WriteLine($"{N1} - {N2} = {result} - odd");
                    }
                    break;

                case '*':
                    if ((N1 * N2) % 2 == 0)
                    {
                        result = N1 * N2;
                        Console.WriteLine($"{N1} * {N2} = {result} - even");
                    }
                    if ((N1 * N2) % 2 != 0)
                    {
                        result = N1 * N2;
                        Console.WriteLine($"{N1} * {N2} = {result} - odd");
                    }
                    break;
            }

            if (op == '/')
            {
                if (N1 == 0 || N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                result = N1 / N2;
                Console.WriteLine($"{N1} / {N2} = {result:F2}");

            }
            if (op == '%')
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                result = N1 % N2;
                Console.WriteLine($"{N1} % {N2} = {result}");
            }
        }
    }
}
