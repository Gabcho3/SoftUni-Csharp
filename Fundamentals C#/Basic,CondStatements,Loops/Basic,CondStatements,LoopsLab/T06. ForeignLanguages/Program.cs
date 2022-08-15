using System;

namespace T06._ForeignLanguages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var country = Console.ReadLine();
            var language = Console.ReadLine();
            switch(country)
            {
                case "England":
                case "USA":
                    language = "English";
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    language = "Spanish";
                    break;
                default: Console.WriteLine("unknown"); return;
            }
            Console.WriteLine(language);
        }
    }
}
