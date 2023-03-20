using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(';');
                string cmd = command[0];

                if (cmd == "END")
                    return;

                string teamName = command[1];

                try
                {
                    switch (cmd)
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;

                        case "Add":
                            Add(command, teams);
                            break;
                        case "Remove":
                            Team team = teams.Find(x => x.Name == teamName);
                            team.RemovePlayer(command[2]);
                            break;

                        case "Rating":
                            if (teams.All(x => x.Name != teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            Console.WriteLine(teams.Find(x => x.Name == teamName).ToString());
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private static void Add(string[] command, List<Team> teams)
        {
            string teamName = command[1];
            string playerName = command[2];

            int[] stats = command.Where(x => int.TryParse(x, out int num)).Select(int.Parse).ToArray();
            int endurance = stats[0];
            int sprint = stats[1];
            int dribble = stats[2];
            int passing = stats[3];
            int shooting = stats[4];

            if(teams.All(x => x.Name != teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Team team = teams.Find(x => x.Name == teamName);
            team.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
        }
    }
}
