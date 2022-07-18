using System;

namespace T06._Strong_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integer = int.Parse(Console.ReadLine());
            string number = integer.ToString();
            var factorialSumOfEveryNum = 1;
            var total = 0;
            for(int index = 0; index < number.Length; index++) 
            {
                int everyNum = int.Parse(number[index].ToString());
                while(everyNum > 1) //> 1 --> can be 0
                {
                    factorialSumOfEveryNum *= everyNum; //Example: factorial sum of !5 = 5 * 4 * 3 * 2 (* 1)
                    everyNum--; 
                }
                total += factorialSumOfEveryNum;
                factorialSumOfEveryNum = 1;
            }
            if (total == integer)  Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
}
