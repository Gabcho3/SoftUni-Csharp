using System;
using System.Collections.Generic;
using System.Linq;

namespace T09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;

            while(sequence.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                bool isGreater = false;
                bool isLess = false;

                if (index < 0)
                {
                    index = 0;
                    isLess = true;
                }

                if (index > sequence.Count - 1)
                {
                    index = sequence.Count - 1;
                    isGreater = true;
                }

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (i == index)
                        continue;

                    if (sequence[i] > sequence[index])
                        sequence[i] -= sequence[index];

                    else
                        sequence[i] += sequence[index];
                }
                sum += sequence[index];

                if (isLess)
                    sequence[0] = sequence[sequence.Count - 1];

                if (isGreater)
                    sequence[sequence.Count - 1] = sequence[0];

                if (isGreater || isLess)
                    continue;

                sequence.RemoveAt(index);
            }

            Console.WriteLine(sum);
        }
    }
}
