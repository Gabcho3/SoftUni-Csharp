using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T07.Tuple
{
    internal class Tuple<T,V>
    {
        private T item1;
        private V item2;

        public T Item1 { get { return item1; } set { item1 = value; } }

        public V Item2 { get { return item2; } set { item2 = value; } }

        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
