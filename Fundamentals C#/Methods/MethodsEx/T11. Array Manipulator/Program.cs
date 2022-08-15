using System;
using System.Linq;

namespace T11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                if (commands[0] == "exchange")
                {
                    input = Exchange(commands, input);
                }

                else if (commands[0] == "max" && commands[1] == "even" || commands[1] == "odd")
                    MaxEvenOdd(commands, input);

                else if (commands[0] == "min" && commands[1] == "even" || commands[1] == "odd")
                    MinEvenOdd(commands, input);

                else if (commands[0] == "first" && commands[2] == "even" || commands[2] == "odd")
                    FirstCountEvenOdd(commands, input);

                else if (commands[0] == "last" && commands[2] == "even" || commands[2] == "odd")
                    LastCountEvenOdd(commands, input);

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine("[" + String.Join(", ", input) + "]");
        }

        static int[] Exchange(string[] commands, int[] input)
        {
            if (int.Parse(commands[1]) > input.Length - 1)
            {
                Console.WriteLine("Invalid index");
                return input;
            }

            int[] subArray1 = new int[int.Parse(commands[1]) + 1];
            int[] subArray2 = new int[input.Length - 1 - int.Parse(commands[1])];

            for(int i = 0; i < input.Length; i++)
            {
                if (i < subArray1.Length)
                    subArray1[i] = input[i];

                else
                    for(int j = 0; j < subArray2.Length; j++)
                    {
                        subArray2[j] = input[i];
                        i++;
                    }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (i < subArray2.Length)
                    input[i] = subArray2[i];

                else
                    for(int j = 0; j < subArray1.Length; j++)
                    {
                        input[i] = subArray1[j];
                        i++;
                    }
            }

            return input;
        }

        static void MaxEvenOdd(string[] commands, int[] input)
        {
            int maxEven = 0;
            int maxEvenIndex = -1;

            int maxOdd = 0;
            int maxOddIndex = -1;

            for(int i = 0; i < input.Length; i++)
            {
                int currDigit = input[i];

                if (currDigit % 2 == 0 && currDigit >= maxEven)
                {
                    maxEvenIndex = i;
                    maxEven = currDigit;
                }

                if (currDigit % 2 != 0 && currDigit >= maxOdd)
                { 
                    maxOddIndex = i;
                    maxOdd = currDigit;
                }
            }

            if (commands[1] == "even" && maxEvenIndex < 0 || commands[1] == "odd" && maxOddIndex < 0)
            {
                Console.WriteLine("No matches");
                return;
            }
            else
                Console.WriteLine(commands[1] == "odd" ? maxOddIndex : maxEvenIndex);
        }
        static void MinEvenOdd(string[] commands, int[] input)
        {
            int minEven = int.MaxValue; ;
            int minEvenIndex = -1;
            int minOdd = int.MaxValue;
            int minOddIndex = -1;

            for (int i = 0; i < input.Length; i++)
            {
                int currDigit = input[i];

                if (currDigit % 2 == 0 && currDigit <= minEven)
                {
                    minEvenIndex = i;
                    minEven = currDigit;
                }

                if (currDigit % 2 != 0 && currDigit <= minOdd)
                {
                    minOddIndex = i;
                    minOdd = currDigit;
                }
            }

            if (commands[1] == "even" && minEvenIndex < 0 || commands[1] == "odd" && minOddIndex < 0)
            {
                Console.WriteLine("No matches");
                return;
            }
            else
                Console.WriteLine(commands[1] == "odd" ? minOddIndex : minEvenIndex);
        }

        static void FirstCountEvenOdd(string[] commands, int[] input)
        {
            int evenCount = 0;
            int oddCount = 0;

            int[] oddNums = null;
            int[] evenNums = null;

            if (int.Parse(commands[1]) > input.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                    evenCount++;

                else
                    oddCount++;

                if (oddCount == int.Parse(commands[1]) && commands[2] == "odd")
                {
                    oddNums = new int[oddCount];
                    break;
                }


                if (evenCount == int.Parse(commands[1]) && commands[2] == "even")
                {
                    evenNums = new int[evenCount];
                    break;
                }

            }

            if (oddCount < int.Parse(commands[1]) && commands[2] == "odd")
            {
                oddNums = new int[oddCount];
            }

            if (evenCount < int.Parse(commands[1]) && commands[2] == "even")
            {
                evenNums = new int[evenCount];
            }

            if (commands[2] == "even" && evenCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            if (commands[2] == "odd" && oddCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    for (int j = 0; j < evenNums.Length; j++)
                    {
                        if (input[i] % 2 == 0)
                        {
                            evenNums[i] = input[i];
                            i++;
                        }
                    }
                }

                else
                    for (int j = 0; j < oddNums.Length; j++)
                    {

                        if (input[i] % 2 != 0)
                        {
                            oddNums[i] = input[i];
                            i++;
                        }
                    }

                if (oddCount <= int.Parse(commands[1]) && commands[2] == "odd")
                {
                    Console.WriteLine("[" + string.Join(", ", oddNums) + "]");
                    break;
                }

                if (evenCount <= int.Parse(commands[1]) && commands[2] == "even")
                {
                    Console.WriteLine("[" + string.Join(", ", evenNums) + "]");
                    break;
                }
            }
        }

        static void LastCountEvenOdd(string[] commands, int[] input)
        {
            int evenCount = 0;
            int oddCount = 0;

            int[] oddNums = null;
            int[] evenNums = null;

            if (int.Parse(commands[1]) > input.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] % 2 == 0)
                    evenCount++;

                else
                    oddCount++;

                if (oddCount == int.Parse(commands[1]) && commands[2] == "odd")
                {
                    oddNums = new int[oddCount];
                    break;
                }

                if (evenCount == int.Parse(commands[1]) && commands[2] == "even")
                {
                    evenNums = new int[evenCount];
                    break;
                }
            }

            if (commands[2] == "even" && evenCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            if (commands[2] == "odd" && oddCount == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] % 2 == 0)
                {
                    for (int j = 0; j < evenNums.Length; j++)
                    {
                        if (input[i] % 2 == 0)
                        {
                            evenNums[i] = input[i];
                            i++;
                        }
                    }
                }

                else
                    for (int j = 0; j < oddNums.Length; j++)
                    {

                        if (input[i] % 2 != 0)
                        {
                            oddNums[i] = input[i];
                            i++;
                        }
                    }

                if (oddCount < int.Parse(commands[1]) && commands[2] == "odd")
                {
                    oddNums = new int[oddCount];
                }

                if (evenCount < int.Parse(commands[1]) && commands[2] == "even")
                {
                    evenNums = new int[evenCount];
                }

                if (oddCount <= int.Parse(commands[1]) && commands[2] == "odd")
                {
                    Console.WriteLine("[" + string.Join(", ", oddNums) + "]");
                    break;
                }

                if (evenCount <= int.Parse(commands[1]) && commands[2] == "even")
                {
                    Console.WriteLine("[" + string.Join(", ", evenNums) + "]");
                    break;
                }
            }
        }
    }
}
