using System;

namespace T08.FuelTankPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typePetrol = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());
            string yesOrNocard = Console.ReadLine();

            if (typePetrol == "Gas")
            {
                if (liters < 20 & yesOrNocard == "No")
                {
                    double tax = liters * 0.93;
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters < 20 & yesOrNocard == "Yes")
                {
                    double discount = liters - (0.93 - 0.08);
                    Console.WriteLine($"{discount:F2} lv.");
                }

                if (liters >= 20 & liters <= 25 & yesOrNocard == "No")
                {
                    double tax = liters * 0.93 - (liters * 0.93 * 0.08);
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters >= 20 & liters <= 25 & yesOrNocard == "Yes")
                {
                    double discount = (liters * (0.93 - 0.08)) - (liters * (0.93 - 0.08) * 0.08);
                    Console.WriteLine($"{discount:F2} lv.");
                }

                if (liters > 25 & yesOrNocard == "No")
                {
                    double tax = liters * 0.93 - (liters * 0.93 * 0.10);
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters > 25 & yesOrNocard == "Yes")
                {
                    double discount = (liters * (0.93 - 0.08)) - (liters * (0.93 - 0.08) * 0.10);
                    Console.WriteLine($"{discount:F2} lv.");
                }
            }

            if (typePetrol == "Gasoline")
            {
                if (liters < 20 & yesOrNocard == "No")
                {
                    double tax = liters * 2.22;
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters < 20 & yesOrNocard == "Yes")
                {
                    double discount = liters - (2.22 - 0.18);
                    Console.WriteLine($"{discount:F2} lv.");
                }

                if (liters >= 20 & liters <= 25 & yesOrNocard == "No")
                {
                    double tax = liters * 2.22 - (liters * 2.22 * 0.08);
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters >= 20 & liters <= 25 & yesOrNocard == "Yes")
                {
                    double discount = liters * (2.22 - 0.18) * (liters * (2.22 - 0.18) * 0.10);
                    Console.WriteLine($"{discount:F2} lv.");
                }

                if (liters > 25 & yesOrNocard == "No")
                {
                    double tax = liters * 2.22 - (liters * 2.22 * 0.10);
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters > 25 & yesOrNocard == "Yes")
                {
                    double discount = liters * (2.22 - 0.18) - (liters * (2.22 - 0.18) * 0.10);
                    Console.WriteLine($"{discount:F2} lv.");
                }
            }

            if (typePetrol == "Diesel")
            {
                if (liters < 20 & yesOrNocard == "No")
                {
                    double tax = liters * 2.33;
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters < 20 & yesOrNocard == "Yes")
                {
                    double discount = liters * (2.33 - 0.12);
                    Console.WriteLine($"{discount:F2} lv.");
                }

                if (liters >= 20 & liters <= 25 & yesOrNocard == "No")
                {
                    double tax = liters * 2.33 - (liters * (2.33 - 0.12) * 0.08);
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters >= 20 & liters <= 25 & yesOrNocard == "Yes")
                {
                    double discount = liters * (2.33 - 0.12) - (liters * (2.33 - 0.12) * 0.08);
                    Console.WriteLine($"{discount:F2} lv.");
                }

                if (liters > 25 & yesOrNocard == "No")
                {
                    double tax = liters * 2.33 - (liters * 2.22 * 0.10);
                    Console.WriteLine($"{tax:F2} lv.");
                }
                if (liters > 25 & yesOrNocard == "Yes")
                {
                    double discount = liters * (2.33 - 0.12) - (liters * (2.33 - 0.12) * 0.10);
                    Console.WriteLine($"{discount:F2} lv.");
                }
            }
        }
    }
}
