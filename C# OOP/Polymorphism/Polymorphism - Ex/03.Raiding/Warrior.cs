using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal class Warrior : BaseHero
    {
        private const int power = 100;

        public Warrior(string name)
        : base(name, power) { }
    }
}
