using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public class Team :ITeam
    {
        private string name;
        private readonly List<IPlayer> players;

        public Team(string name)
        {
            this.Name = name;
            this.PointsEarned = 0;
            players = new List<IPlayer>();
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public int PointsEarned { get; private set; }

        public double OverallRating 
            => Math.Round(players.Select(p => p.Rating).Average(), 2);

        public IReadOnlyCollection<IPlayer> Players => players;

        public void SignContract(IPlayer player) => players.Add(player);

        public void Win()
        {
            this.PointsEarned += 3;
            players.ForEach(p => p.IncreaseRating());
        }

        public void Lose() => players.ForEach(p => p.DecreaseRating());

        public void Draw()
        {
            this.PointsEarned++;
            players.Find(p => p.GetType().Name == "Goalkeeper").IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string playersNames = players.Count > 0 ? string.Join(", ", players.Select(p => p.Name)) : "none";

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating + {OverallRating}");
            sb.AppendLine("Players: " + playersNames);

            return sb.ToString().Trim();
        }
    }
}
