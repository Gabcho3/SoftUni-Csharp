using System;
using System.Collections.Generic;
using System.Linq;

namespace T11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            while(command[0] != "end")
            {
                switch(command[0])
                {
                    case "exchange":
                        int index = int.Parse(command[1]);
                        if (index >= 0 && index < integers.Length)
                            integers = Exchange(integers, index);

                        else
                            Console.WriteLine("Invalid index");

                        break;

                    case "max":
                        string input = command[1];
                        Max(integers, input);
                        break;

                    case "min":
                        input = command[1];
                        Min(integers, input);
                        break;

                    case "first":
                        int count = int.Parse(command[1]);
                        input = command[2];
                        if (count <= integers.Length)
                            First(integers, count, input);

                        else
                            Console.WriteLine("Invalid count");
                            break;
                    case "last":
                        count = int.Parse(command[1]);
                        input = command[2];
                        if (count <= integers.Length)
                            Last(integers, count, input);

                        else
                            Console.WriteLine("Invalid count");
                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", integers)}]");
        }

        private static void Last(int[] integers, int count, string input)
        {
            List<int> lastEven = new List<int>();
            List<int> lastOdd = new List<int>();

            for (int i = integers.Length - 1; i >= 0; i--)
            {
                if (integers[i] % 2 == 0 && lastEven.Count + 1 <= count)
                    lastEven.Add(integers[i]);

                if (integers[i] % 2 == 1 && lastOdd.Count + 1 <= count)
                    lastOdd.Add(integers[i]);
            }

            if (lastEven.Count == 0 && input == "even")
            {
                Console.WriteLine("[]");
                return;
            }

            if (lastOdd.Count == 0 && input == "odd")
            {
                Console.WriteLine("[]");
                return;
            }

            if (input == "even")
                Console.WriteLine($"[{string.Join(", ", lastEven)}]");

            else
                Console.WriteLine($"[{string.Join(", ", lastOdd)}]");
        }

        private static void First(int[] integers, int count, string input)
        {
            List<int> firstEven = new List<int>();
            List<int> firstOdd = new List<int>();

            for(int i = 0; i < integers.Length; i++)
            {
                if (integers[i] % 2 == 0 && firstEven.Count + 1 <= count)
                    firstEven.Add(integers[i]);

                if (integers[i] % 2 == 1 && firstOdd.Count + 1 <= count)
                    firstOdd.Add(integers[i]);
            }

            if (firstEven.Count == 0 && input == "even")
            {
                Console.WriteLine("[]");
                return;
            }

            if (firstOdd.Count == 0 && input == "odd")
            {
                Console.WriteLine("[]");
                return;
            }

            if (input == "even")
                Console.WriteLine($"[{string.Join(", ", firstEven )}]");

            else
                Console.WriteLine($"[{string.Join(", ", firstOdd)}]");
        }

        private static void Min(int[] integers, string input)
        {
            int minEven = int.MaxValue;
            int minOdd = int.MaxValue;
            int indexEven = -1;
            int indexOdd = -1;
            for (int i = 0; i < integers.Length; i++)
            {
                if (integers[i] % 2 == 0 && integers[i] <= minEven)
                {
                    minEven = integers[i];
                    indexEven = i;
                }

                if (integers[i] % 2 == 1 && integers[i] <= minOdd)
                {
                    minOdd = integers[i];
                    indexOdd = i;
                }
            }

            if (indexEven == -1 && input == "even")
            {
                Console.WriteLine("No matches");
                return;
            }

            if (indexOdd == -1 && input == "odd")
            {
                Console.WriteLine("No matches");
                return;
            }

            if (input == "even")
                Console.WriteLine(indexEven);

            else
                Console.WriteLine(indexOdd);
        }

        private static void Max(int[] integers, string input)
        {
            int maxEven = int.MinValue;
            int maxOdd = int.MinValue;
            int indexEven = -1;
            int indexOdd = -1;
            for(int i = 0; i < integers.Length; i++)
            {
                if (integers[i] % 2 == 0 && integers[i] >= maxEven)
                {
                    maxEven = integers[i];
                    indexEven = i;
                }

                if (integers[i] % 2 == 1 && integers[i] >= maxOdd)
                {
                    maxOdd = integers[i];
                    indexOdd = i;
                }
            }

            if(indexEven == -1 && input == "even")
            {
                Console.WriteLine("No matches");
                return;
            }

            if (indexOdd == -1 && input == "odd")
            {
                Console.WriteLine("No matches");
                return;
            }

            if (input == "even" )
                Console.WriteLine(indexEven);

            else if (input == "odd")
                Console.WriteLine(indexOdd);
        }

        private static int[] Exchange(int[] integers, int index)
        {
            int[] sub1 = new int[index + 1];
            int[] sub2 = new int[integers.Length - 1 - index];

            for (int i = 0; i < sub1.Length; i++)
                sub1[i] = integers[i];

            int indexSub2 = sub1.Length;
            for (int i = 0; i < sub2.Length; i++)
                sub2[i] = integers[indexSub2++];

            int j = 0;
            for (int i = 0; i < integers.Length; i++)
            {
                if (i < sub2.Length)
                    integers[i] = sub2[i];

                else
                    integers[i] = sub1[j++];
            }

            return integers;
        }
    }
}
