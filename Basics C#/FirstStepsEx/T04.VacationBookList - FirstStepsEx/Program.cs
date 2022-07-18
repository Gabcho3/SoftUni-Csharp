using System;

namespace T04.VacationBookList___FirstStepsEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int page = int.Parse(Console.ReadLine());
            int pageh = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int need = (page / pageh) / days;
            Console.WriteLine(need);
        }
    }
}
