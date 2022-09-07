using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;

namespace T05._Teamwork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsToRegister = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            //TEAMS REGISTRATION
            string[] userAndTeam = new string[0];

            for(int i = 0; i < teamsToRegister; i++)
            {
                userAndTeam = Console.ReadLine().Split('-');

                string user = userAndTeam[0];
                string teamName = userAndTeam[1];

                if (teams.Any(currTeam => currTeam.Name == teamName))
                    Console.WriteLine($"Team {teamName} was already created!");

                else if (teams.Any(currTeam => currTeam.Creator == user))
                    Console.WriteLine($"{user} cannot create another team!");

                else
                {
                    Team team = new Team { Creator = user, Name = teamName };
                    team.Members = new List<string>();
                    teams.Add(team);

                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                }
            }

            //MEMBERS REGISTRATION
            userAndTeam = Console.ReadLine().Split("->");

            while (userAndTeam[0] != "end of assignment")
            {
                string member = userAndTeam[0];
                string teamName = userAndTeam[1];

                if (!teams.Any(currTeam => currTeam.Name == teamName))
                    Console.WriteLine($"Team {teamName} does not exist!");

                else if (teams.Any(creator => creator.Creator == member) ||
                         teams.Any(currMember => currMember.Members.Contains(member)))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }

                else
                    foreach (var team in teams)
                    {
                        if (team.Name == teamName)
                            team.Members.Add(member);
                    }

                userAndTeam = Console.ReadLine().Split("->");
            }

            //FINDING AND REMOVING DISBAND TEAMS 
            List<string> disbandTeams = new List<string>();

            for(int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count == 0)
                {
                    disbandTeams.Add(teams[i].Name);
                    teams.RemoveAt(i);
                }
            }

            teams = teams.OrderByDescending(team => team.Members.Count).ThenBy(n => n.Name).ToList();

            //PRINTING TEAMS
            foreach(var team in teams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                foreach(var member in team.Members.OrderBy(n => n))
                    Console.WriteLine($"-- {member}");
            }

            //PRINTING DISBAND TEAMS
            disbandTeams = disbandTeams.OrderBy(team => team).ToList();

            Console.WriteLine("Teams to disband:");

            for (int i = 0; i < disbandTeams.Count; i++)
                Console.WriteLine(disbandTeams[i]);
        }
    }

    class Team
    {
        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }
}
