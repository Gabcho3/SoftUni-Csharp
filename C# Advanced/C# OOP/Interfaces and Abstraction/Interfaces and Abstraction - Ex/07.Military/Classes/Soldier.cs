using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Classes
{
    abstract public class Soldier : ISoldier
    {
        protected Soldier(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Id { get; }
    }
}
