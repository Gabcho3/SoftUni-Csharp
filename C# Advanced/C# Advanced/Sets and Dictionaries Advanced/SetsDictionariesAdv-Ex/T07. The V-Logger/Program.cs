using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace T07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var vloggers = new Dictionary<string, Vlogers>(); //name, [followers, following]

            while (input[0] != "Statistics")
            {
                string name = input[0];
                switch(input[1])
                {
                    case "joined":
                        Joined(vloggers, name);
                        break;

                    case "followed":
                        string followed = input[2];
                        Followed(vloggers, name, followed);
                        break;
                }
                input = Console.ReadLine().Split();
            }
            PrintStatistics(vloggers);
        }

        static void Joined (Dictionary<string, Vlogers> vloggers, string name)
        {
            if(!vloggers.ContainsKey(name))
            {
                vloggers.Add(name, new Vlogers() { Following = new List<string>(), Followers = new List<string>()});
            }
        }

        static void Followed (Dictionary<string, Vlogers> vloggers, string name, string followed)
        {
            if (!vloggers.ContainsKey(name) || !vloggers.ContainsKey(followed))
                return;

            if (name == followed)
                return;

            if (vloggers[name].Following.Contains(followed))
                return;

            vloggers[name].Following.Add(followed);
            vloggers[followed].Followers.Add(name);
        }

        static void PrintStatistics(Dictionary<string, Vlogers> vloggers)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int count = 1;
            foreach (var (vlogger, lists) in vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count))
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count++}. {vlogger} : {lists.Followers.Count} followers, {lists.Following.Count} following");
                    foreach (var follower in lists.Followers.OrderBy(x => x))
                        Console.WriteLine($"*  {follower}");
                }

                else
                {
                    Console.WriteLine($"{count++}. {vlogger} : {lists.Followers.Count} followers, {lists.Following.Count} following");
                }
            }
        }
    }

    class Vlogers
    {
        public List<string> Followers { get; set; }

        public List<string> Following { get; set; }
    }
}
