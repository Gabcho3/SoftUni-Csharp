using PersonInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Birthday
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdat)
        {
            Name = name;
            Birthdate = birthdat;
        }

        public string Name { get; }

        public string Birthdate { get; }

        public string Id => throw new NotImplementedException();
    }
}
