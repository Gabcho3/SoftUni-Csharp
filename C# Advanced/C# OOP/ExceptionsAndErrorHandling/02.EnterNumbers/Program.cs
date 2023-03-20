using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>();

            while(ints.Count < 10)
            {
                try
                {
                    if (ints.Count > 0)
                    {
                        ints.Add(ReadNumber(ints.Max(), 100));
                    }
                    else
                    {
                        ints.Add(ReadNumber(1, 100));
                    }
                }
                catch(FormatException formEx)
                {
                    Console.WriteLine(formEx.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(", ", ints));
        }

        static int ReadNumber(int start, int  end)
        {
            int num;
            try
            {
                num = int.Parse(Console.ReadLine());

                if (num <= start || num >= end)
                {
                    throw new ArgumentException($"Your number is not in range {start} - {end}!");
                }
            }
            catch(FormatException)
            {
                throw new FormatException("Invalid Number!");
            }

            return num;
        }
    }
}
