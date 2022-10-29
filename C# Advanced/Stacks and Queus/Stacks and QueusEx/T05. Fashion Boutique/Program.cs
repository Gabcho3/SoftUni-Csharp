using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);

            int sum = 0;
            int racks = 0;

            while (true)
            {
                if (stack.Count == 0)
                    break;

                while (sum + stack.Peek() <= capacity)
                {
                    sum += stack.Pop();

                    if (stack.Count == 0)
                        break;
                }

                racks++;
                sum = 0;
            }
            
            Console.WriteLine(racks);
        }
    }
}
