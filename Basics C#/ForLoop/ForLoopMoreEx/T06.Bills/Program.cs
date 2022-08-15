using System;

namespace T06.Bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double priceWater = 0;
            double priceInternet = 0;
            double priceOther = 0.00;
            double totalMonth = 0;
            double priceElectricity = 0;

            for ( int everyMonth = 1; everyMonth <= months; everyMonth++)
            {
                double priceElectricityPerMonth = double.Parse(Console.ReadLine());

                priceElectricity += priceElectricityPerMonth;
                priceWater += 20;
                priceInternet += 15;
                
                totalMonth = priceElectricity + priceWater + priceInternet;
                priceOther = totalMonth + (totalMonth * 0.20);
            }
            Console.WriteLine($"Electricity: {priceElectricity:F2} lv");
            Console.WriteLine($"Water: {priceWater:F2} lv"); 
            Console.WriteLine($"Internet: {priceInternet:F2} lv");
            Console.WriteLine($"Other: {priceOther:F2} lv");
            double total = priceElectricity + priceInternet + priceWater + priceOther;
            double average = total / months;
            Console.WriteLine($"Average: {average:f2} lv");
        }
    }
}
