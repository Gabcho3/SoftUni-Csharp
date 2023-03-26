using System;

namespace UniversityCompetition.Models.Contracts.Subjects
{
    public abstract class Subject : ISubject
    {
        private string name;
        public Subject(int id, string name, double rate)
        {
            Id = id;
            Name = name;
            Rate = rate;
        }

        public int Id { get; }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double Rate { get; }
    }
}
