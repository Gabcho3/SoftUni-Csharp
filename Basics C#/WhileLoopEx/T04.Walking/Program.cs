using System;

namespace T04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //needed Steps = 10000
            //steps everyday anytimes
            //bool goalReached = false/true
            //if(goalReached == true) --> "Goal reached! Good job!" && "{steps - 10000} steps over the goal!"
            //sometimes "GoingHome" + steps while going home
            //if(goalReached == false) --> "{10000 - steps} more steps to reach goal."
            //input to int 
            int steps = 0;
            int totalSteps = 0;
            bool goalReached = false;
            while(true)
            {
                goalReached = true;
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    steps = int.Parse(Console.ReadLine());
                    totalSteps += steps;
                    goalReached = false;
                    if(totalSteps > 10000) goalReached = true;
                    break;
                }
                steps = int.Parse(input);
                totalSteps += steps;
                if(totalSteps >= 10000)
                {
                    goalReached = true;
                    break;
                }
            }
            
            if(goalReached)
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - totalSteps} more steps to reach goal.");
            }

        }
    }
}
