using System;

namespace T03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowersType = Console.ReadLine(); //Roses || Dahlias || Tulips || Narcissus || Gladiolus
            int flowersCount = int.Parse(Console.ReadLine()); //брой цветя, цяло число
            int budget = int.Parse(Console.ReadLine()); //бюджата, цяло число
            double totalPrice = 0; //общата цена за цветята

            switch (flowersType)
            {
                case "Roses":
                    totalPrice = flowersCount * 5; //пресмятаме общата цена според табличката
                    if(flowersCount > 80)
                    {
                        totalPrice *= 0.90; //ако розите са повече от 80, отстъпка 10% (100% - 10% = 90% = 0.90)
                    }
                    break;

                case "Dahlias":
                    totalPrice = flowersCount * 3.80; //пресмятаме общата цена според табличката
                    if (flowersCount > 90)
                    {
                        totalPrice *= 0.85; //ако далиите са повече от 90, отстъпка 15% (100% - 15% = 85% = 0.85)
                    }
                    break;

                case "Tulips":
                    totalPrice = flowersCount * 2.80; //пресмятаме общата цена според табличката
                    if (flowersCount > 80)
                    {
                        totalPrice *= 0.85; //ако лалетата са повече от 80, отстъпка 15% (100% - 15% = 85% = 0.85)
                    }
                    break;

                case "Narcissus":
                    totalPrice = flowersCount * 3; //пресмятаме общата цена според табличката
                    if (flowersCount < 120)
                    {
                        totalPrice *= 1.15; //ако нарцисите са по-малко от 120, оскъпяване 15% (100% + 15% = 115% = 1.15)
                    }
                    break;

                case "Gladiolus":
                    totalPrice = flowersCount * 2.50; //пресмятаме общата цена според табличката
                    if (flowersCount < 80)
                    {
                        totalPrice *= 1.20; //ако гладиолите са по-малко от 80, оскъпяване 20% (100% + 20% = 120% = 1.20)
                    }
                    break;
            }

            //ПРАВИМ ПРОВЕРКИ ДАЛИ БЮДЖЕТА НИ СТИГА
            if(budget >= totalPrice)
            {
                double leftSum = budget - totalPrice; //останалата сума
                Console.WriteLine($"Hey, you have great garden with {flowersCount} {flowersType} and {leftSum:f2} leva left.");
                //:f2 -> закръгляне до второто число след десетичната запетайка
            }
            else //ако бюджета не стига
            {
                double needSum = totalPrice - budget; //нужната сума
                Console.WriteLine($"Not enough money, you need {needSum:f2} leva more.");
            }
        }
    }
}
