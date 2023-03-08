using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal class Rogue : BaseHero
    {
        private const int power = 80;

        public Rogue(string name)
        : base(name, power) { }
    }
}
