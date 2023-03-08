using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal class Druid : BaseHero
    {
        private const int power = 80;

        public Druid(string name)
        : base(name, power) { }
    }
}
