﻿using System;

namespace T01.Change_Bureau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = int.Parse(Console.ReadLine());
            double yuan = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine()) / 100;

            int bitcoinInLev = bitcoin * 1168;
            double yuanInDollar = yuan * 0.15;
            double dollarInLev = yuanInDollar * 1.76;
            double inEuro = (bitcoinInLev + dollarInLev) / 1.95;
            double withCommission = inEuro - (inEuro * commission);
            Console.WriteLine($"{withCommission:f2}");
        }
    }
}
//Преди време Петър си е купил биткойн. Сега ще ходи на екскурзия из Европа и ще му трябва евро. Освен биткойн има и китайски юанa.
//Той иска да обмени парите си в евро за екскурзията.

//Напишете програма, която да пресмята колко евро може да купи спрямо следните валутни курсове:
//•	1 биткойн = 1168 лева.
//•	1 китайски юан = x0.15 долара.
//•	1 долар = 1.76 лева.
//•	1 евро = 1.95 лева.
//Обменното бюро има комисионна от 0 до 5 процента от крайната сума в евро.

//Вход:
//От конзолата се четат 3 числа:
//•	На първия ред – броят биткойни. Цяло число в интервала [0…20]
//•	На втория ред – броят китайски юана. Реално число в интервала [0.00… 50 000.00]
//•	На третия ред – комисионната. Реално число в интервала [0.00 ... 5.00]

//Изход:
//На конзолата да се отпечата 1 число - резултатът от обмяната на валутите. Резултатът да се форматира до втората цифра след десетичната запетая.

