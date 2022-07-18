using System;

namespace T04.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int places = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int entered = 0;
            double income = 0;
            double bill = 0; //every loop price for people
            bool noSpace = false;

            while(input != "Movie time!")
            {
                int people = int.Parse(input);
                entered += people;
                if (entered > places)
                {
                    noSpace = true;
                    break;
                }
                bill = people * 5;
                if (people % 3 == 0) bill -= 5;
                income += bill;

                bill = 0;
                input = Console.ReadLine();
            }
            if (noSpace) Console.WriteLine("The cinema is full.");
            else Console.WriteLine($"There are {places - entered} seats left in the cinema.");
            Console.WriteLine($"Cinema income - {income} lv.");
        }
    }
}


