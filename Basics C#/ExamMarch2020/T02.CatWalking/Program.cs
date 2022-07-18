﻿using System;

namespace T02.CatWalking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int walksForDay = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            int totalMinutes = minutes * walksForDay;
            int totalcalories = totalMinutes * 5;
            double caloriesNeeded = calories - (calories * 0.50);

            if(caloriesNeeded <= totalcalories)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalcalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {totalcalories}.");
            }
        }
    }
}
//Деси трябва да разхожда своята котка ежедневно, но не може да прецени колко минути са досатъчни на ден.
//Като знаете колко калории приема котката на ден, колко пъти и по колко минути Деси разхожда котката си.
//Напишете програма, която изчислява дали разходката е достатъчна.
//За всяка минута от разходката, котката гори по 5 калории.
//Разходката е достатъчна, ако котката изграря 50% от приетите калории.

//Вход:

//Входът се чете от конзолата и съдържа точно 3 реда:
//•	На първия ред - минути разходка на ден - цяло число в интервала [1...50]
//•	На втория ред - броят на разходките дневно - цяло число в интервала [1…10]
//•	На третия ред - приетите от котката калории на ден – цяло число в интервала [100…4000]

//Изход:
//Да се отпечата на конзолата един ред:
//•	Ако изгорените калории през разходката са повече или равни на  50% от приетите през деня калории: 
//"Yes, the walk for your cat is enough. Burned calories per day: {общо изгорени калории от разходката}."
//•	Ако изгорените калории през разходката са по-малко от 50% от приетите през деня калории:
// "No, the walk for your cat is not enough. Burned calories per day: {общо изгорени калории от разходката}."

