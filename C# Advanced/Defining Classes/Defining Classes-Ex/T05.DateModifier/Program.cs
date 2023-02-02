using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            DateModifier dateModifier = new DateModifier();
            string[] firstDate = Console.ReadLine().Split();
            string[] secondDate = Console.ReadLine().Split();
            Console.WriteLine(dateModifier.CalculateDifference(firstDate, secondDate));
        }
    }
}