using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T08.Threeuple
{
    internal class Threeuple<T,V,W>
    {
        private T first;
        private V second;
        private W third;

        public T First { get { return first; } set { first = value; } }

        public V Second { get { return second; } set { second = value; } }

        public W Third { get { return third; } set { third = value; } }

        public override string ToString()
        {
            return $"{First} -> {Second} -> {Third}";
        }
    }
}
