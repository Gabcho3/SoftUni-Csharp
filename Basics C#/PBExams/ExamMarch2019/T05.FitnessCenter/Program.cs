using System;

namespace T05.FitnessCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            int back = 0;
            int chest = 0;
            int legs = 0;
            int abs = 0;
            int shake = 0;
            int bar = 0;

            double training = 0;
            double buying = 0;

            for(int pupil = 1; pupil <= people; pupil++)
            {
                string activity = Console.ReadLine();
                if (activity == "Back") { back++; training++; }
                if (activity == "Chest") { chest++; training++; }
                if(activity == "Legs") { legs++; training++; }
                if (activity == "Abs") { abs++; training++; }
                if (activity == "Protein shake") { shake++; buying++; }
                if (activity == "Protein bar") { bar++; buying++; }
            }
            double percentTraining = training / people * 100;
            double percentBuying = buying / people * 100;
            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{shake} - protein shake");
            Console.WriteLine($"{bar} - protein bar");
            Console.WriteLine($"{percentTraining:f2}% - work out");
            Console.WriteLine($"{percentBuying:f2}% - protein");
        }
    }
}
