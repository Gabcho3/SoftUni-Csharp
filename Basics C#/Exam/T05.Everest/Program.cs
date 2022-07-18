using System;

namespace T05.Everest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string yesOrNo = Console.ReadLine();
            double start = 5364;
            int days = 1;

            while (yesOrNo != "END")
            {
                double meters = double.Parse(Console.ReadLine());
                start += meters;
                if (yesOrNo == "Yes")
                {
                    days++;
                }
                if (days > 5)
                {
                    if(start < 8848)
                    {
                        start -= meters;
                    }
                    break;
                }
                if (start >= 8848)
                {
                    break;
                }
                yesOrNo = Console.ReadLine();
            }
            if (start >= 8848) Console.WriteLine($"Goal reached for {days} days!");
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{start}");
            }
        }
    }
}
