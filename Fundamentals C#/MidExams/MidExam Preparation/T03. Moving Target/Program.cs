using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "End")
            {
                switch(command[0])
                {
                    case "Shoot":
                        Shoot(targets, command);
                        break;

                    case "Add":
                        Add(targets, command);
                        break;

                    case "Strike":
                        Strike(targets, command);
                        break;
                }
                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join("|", targets));
        }
        
        static void Shoot(List<int> targets, string[] command)
        {
            if (int.Parse(command[1]) < 0 || int.Parse(command[1]) > targets.Count - 1)
                return;
            
            targets[int.Parse(command[1])] -= int.Parse(command[2]);

            if (targets[int.Parse(command[1])] <= 0)
                targets.RemoveAt(int.Parse(command[1]));
        }

        static void Add(List<int> targets, string[] command)
        {
            if (int.Parse(command[1]) > targets.Count - 1 || int.Parse(command[1]) < 0)
                Console.WriteLine("Invalid placement!");

            else
                targets.Insert(int.Parse(command[1]), int.Parse(command[2]));
        }

        static void Strike(List<int> targets, string[] command)
        {

            int startRadius = int.Parse(command[1]) - int.Parse(command[2]);
            int endRadius = int.Parse(command[1]) + int.Parse(command[2]);

            if(startRadius < 0 || endRadius > targets.Count - 1)
            {
                Console.WriteLine("Strike missed!");
                return;
            }

            targets.RemoveRange(startRadius, int.Parse(command[2]) * 2 + 1);
        }
    }
}
