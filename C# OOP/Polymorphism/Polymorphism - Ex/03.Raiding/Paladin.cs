using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal class Paladin : BaseHero
    {
        private const int power = 100;

        public Paladin(string name)
        : base(name, power) { }
    }
}
