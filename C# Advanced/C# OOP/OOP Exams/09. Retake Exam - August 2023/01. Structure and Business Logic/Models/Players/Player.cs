using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;

        protected Player(string name, double rating)
        {
            this.Name = name;
            this.Rating = rating;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }
        }

        public double Rating { get; protected set; }

        public string Team { get; private set; }

        public void JoinTeam(string name) => this.Team = name;

        public abstract void IncreaseRating();

        public abstract void DecreaseRating();

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name}" 
                   + Environment.NewLine 
                   + $"Rating: {Rating}";
        }
    }
}
