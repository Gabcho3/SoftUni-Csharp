using System;

namespace T01._Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var age = int.Parse(Console.ReadLine());
            var person = string.Empty;
            if (age < 3) person = "baby";
            else if (age > 2 && age < 14) person = "child";
            else if (age > 13 && age < 20) person = "teenager";
            else if (age > 19 && age < 66) person = "adult";
            else person = "elder";
            Console.WriteLine(person);
        }
    }
}
