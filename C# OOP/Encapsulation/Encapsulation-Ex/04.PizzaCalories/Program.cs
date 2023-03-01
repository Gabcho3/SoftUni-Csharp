using System;
using System.Linq;
using System.Net.Security;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza;
            string pizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Last();

            string[] doughData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string doughType = doughData[1];
            string doughBakingTechnique = doughData[2];
            double doughGrams = double.Parse(doughData[3]);

            try
            {
                pizza = new Pizza(pizzaName, new Dough(doughType, doughBakingTechnique, doughGrams));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while(true)
            {
                string[] toppingData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (toppingData[0] == "END")
                {
                    Console.WriteLine(pizza.ToString());
                    return;
                }

                string toppingType = toppingData[1];
                double toppingGrams = double.Parse(toppingData[2]);

                try
                {
                    pizza.AddTopping(new Topping(toppingType, toppingGrams));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }
    }
}
