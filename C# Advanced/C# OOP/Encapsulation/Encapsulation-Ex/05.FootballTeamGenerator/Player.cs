using System;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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

        private int Endurance { get { return endurance; } set { endurance = IsStatValid(value, "Endurance"); } }
        private int Sprint { get { return sprint; } set { sprint = IsStatValid(value, "Sprint"); } }
        private int Dribble { get { return dribble; } set { dribble = IsStatValid(value, "Dribble"); } }
        private int Passing { get { return passing; } set { passing = IsStatValid(value, "Passing"); } }
        private int Shooting { get { return shooting; } set { shooting = IsStatValid(value, "Shooting"); } }

        public int SkillLevel { get { return (int)Math.Round((endurance + sprint + dribble + passing + shooting) / 5d); } }

        private int IsStatValid(int value, string stat)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{stat} should be between 0 and 100.");
            }
            return value;
        }
    }
}