using System;

namespace T05._Month_Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var mon = string.Empty;
            switch(num)
            {
                case 1: mon = "January"; break;
                case 2: mon = "February"; break;
                case 3: mon = "March"; break;
                case 4: mon = "April"; break;
                case 5: mon = "May"; break;
                case 6: mon = "June"; break;
                case 7: mon = "July"; break;
                case 8: mon = "August"; break;
                case 9: mon = "September"; break;
                case 10: mon = "October"; break;
                case 11: mon = "November"; break;
                case 12: mon = "December"; break;
                default: Console.WriteLine("Error!"); return; 
            }
            Console.WriteLine(mon);
        }
    }
}
