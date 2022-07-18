using System;

namespace T07.Projects_Creation___FirstSteps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());
            int need = projects * 3;
            Console.WriteLine($"The architect {name} will need {need} hours to complete {projects} project/s.");

        }
    }
}
