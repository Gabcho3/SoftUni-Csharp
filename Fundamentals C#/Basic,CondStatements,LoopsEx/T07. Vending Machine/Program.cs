using System;

namespace T07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sum = 0.0;
            string input = Console.ReadLine();
            while (true)
            {
                var coins = double.Parse(input); //string -> double
                switch (coins)
                {
                    case 0.1: sum += 0.1; break;
                    case 0.2: sum += 0.2; break;
                    case 0.5: sum += 0.5; break;
                    case 1: sum += 1; break;
                    case 2: sum += 2; break;
                    default: Console.WriteLine($"Cannot accept {coins}"); break;
                }
                input = Console.ReadLine(); //"Start" or Sum(coins)

                if (input == "Start")
                {
                    //After command "Start"
                    while (input != "End")
                    {
                        
                        switch (input)
                        {
                            case "Start": break; //first input is always "Start"
                            case "Nuts":
                                if (sum >= 2.0)
                                {
                                    Console.WriteLine("Purchased nuts");
                                    sum -= 2.0;
                                }
                                else
                                    Console.WriteLine("Sorry, not enough money");
                                break;
                            case "Water":
                                if (sum >= 0.7)
                                {
                                    Console.WriteLine("Purchased water");
                                    sum -= 0.7;
                                }
                                else
                                    Console.WriteLine("Sorry, not enough money");
                                break;
                            case "Crisps":
                                if (sum >= 1.5)
                                {
                                    Console.WriteLine("Purchased crisps");
                                    sum -= 1.5;
                                }
                                else
                                    Console.WriteLine("Sorry, not enough money");
                                break;
                            case "Soda":
                                if (sum >= 0.8)
                                {
                                    Console.WriteLine("Purchased soda");
                                    sum -= 0.8;
                                }
                                else
                                    Console.WriteLine("Sorry, not enough money");
                                break;
                            case "Coke":
                                if (sum >= 1.0)
                                {
                                    Console.WriteLine("Purchased coke");
                                    sum -= 1.0;
                                }
                                else
                                    Console.WriteLine("Sorry, not enough money");
                                break;
                            default: 
                                    Console.WriteLine("Invalid product");
                                break;
                        }
                        input = Console.ReadLine();
                    }
                    Console.WriteLine($"Change: {sum:f2}"); //After command "End"
                    return;
                }
            }
        }
    }
}
