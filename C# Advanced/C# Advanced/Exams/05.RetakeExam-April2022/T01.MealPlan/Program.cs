using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> mealCalories = new Dictionary<string, int>()
            {
                ["salad"] = 350,
                ["soup"] = 490,
                ["pasta"] = 680,
                ["steak"] = 790
            };

            int mealsCount = 0;
            while (true)
            {
                int cal = calories.Peek();

                while (cal > 0 && meals.Count > 0)
                {
                    string meal = meals.Peek();
                    int mealCal = mealCalories[meal];
                    cal -= mealCal;

                    meals.Dequeue();
                    mealsCount++;
                }

                if (cal < 0)
                {
                    calories.Pop();

                    if (calories.Count > 0)
                    {
                        calories.Push(calories.Pop() - Math.Abs(cal));
                    }
                }

                else if (cal == 0)
                {
                    calories.Pop();
                }

                else
                {
                    calories.Pop();
                    calories.Push(cal);
                }

                if (meals.Count == 0)
                {
                    Console.WriteLine("John had {0} meals.", mealsCount);
                    Console.WriteLine("For the next few days, he can eat {0} calories.", string.Join(", ", calories));
                    return;
                }

                if (calories.Count == 0)
                {
                    Console.WriteLine("John ate enough, he had {0} meals.", mealsCount);
                    Console.WriteLine("Meals left: {0}.", string.Join(", ", meals));
                    return;
                }
            }
        }
    }
}
