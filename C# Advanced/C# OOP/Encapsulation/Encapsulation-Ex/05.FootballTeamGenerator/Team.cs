using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        private List<Player> Players { get; set; }

        public int Rating
        {
            get
            {
                if (Players.Count > 0)
                {
                    return (int)Math.Round(Players.Select(x => x.SkillLevel).Average());
                }

                else
                    return 0;
            }
        }

        public void AddPlayer(Player player)
            => Players.Add(player);

        public void RemovePlayer(string playerName)
        {
            if(Players.All(x => x.Name != playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            Players.RemoveAll(x => x.Name == playerName);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
