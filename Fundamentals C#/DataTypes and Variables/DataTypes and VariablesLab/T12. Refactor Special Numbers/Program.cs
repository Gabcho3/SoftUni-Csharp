using System;

namespace T12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine()); //changed name
            bool special = false; //changed name
            for (int num = 1; num <= count; num++) //change name 
            {
                int sum = 0; //smaller span
                int digits = num; //smaler span
                while (digits > 0) //num -> digits
                {
                    sum += digits % 10; //num -> digits
                    digits /= 10; //num -> digits
                }
                if (sum == 5 || sum == 7 || sum == 11) special = true; //made if-else construction
                else special = false;
                Console.WriteLine("{0} -> {1}", num, special); //digits -> num
            }
        }
    }
}
