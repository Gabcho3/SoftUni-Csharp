using System;

namespace T03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double startBalance = balance; //balance decreases by the price 
            string game = Console.ReadLine();
            double total = 0;
            while(game != "Game Time")
            {
                switch(game)
                {
                    case "OutFall 4":
                    case "RoverWatch Origins Edition":
                        balance -= 39.99;
                        total += 39.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive"); 
                            balance += 39.99;
                            total -= 39.99;
                        }
                        else
                            Console.WriteLine($"Bought {game}");
                        break;
                    case "CS: OG":
                        balance -= 15.99;
                        total += 15.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive"); 
                            balance += 15.99;
                            total -= 15.99;
                        }
                        else
                            Console.WriteLine($"Bought {game}");
                        break;
                    case "Zplinter Zell":
                        balance -= 19.99;
                        total += 19.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 19.99;
                            total -= 19.99;
                        }
                        else
                            Console.WriteLine($"Bought {game}");
                        break;
                    case "Honored 2":
                        balance -= 59.99;
                        total += 59.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 59.99;
                            total -= 59.99;
                        }
                        else
                            Console.WriteLine($"Bought {game}");
                        break;
                    case "RoverWatch":
                        balance -= 29.99;
                        total += 29.99;
                        if (balance < 0)
                        {
                            Console.WriteLine("Too Expensive");
                            balance += 29.99;
                            total -= 29.99;
                        }
                        else
                            Console.WriteLine($"Bought {game}");
                        break;
                    default: 
                            Console.WriteLine("Not Found");
                        break;
                }
                if(balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                game = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${total:f2}. Remaining: ${startBalance - total:f2}");
        }
    }
}
