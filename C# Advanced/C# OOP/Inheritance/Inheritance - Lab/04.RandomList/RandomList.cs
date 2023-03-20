using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random = new Random();

        public Random Random { get { return random; } }

        public string RandomString()
        {
            return Random.Next(0, Count).ToString();
        }
    }
}
