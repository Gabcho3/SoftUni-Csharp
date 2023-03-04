using _07.Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military.Classes
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, string id, int codeNumber)
            : base(firstName, lastName, id)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
            => $"Name: {FirstName} {LastName} Id: {Id}" + Environment.NewLine + $"Code Number: {CodeNumber}";
    }
}
