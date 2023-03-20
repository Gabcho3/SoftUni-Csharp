using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T05.GenericCountMethodString
{
    internal class Box<T>
    {
        private List<T> values;

        public Box()
        {
            Values = new List<T>();
        }

        public List<T> Values { get { return values; } set { values = value; } }

        public int Counter<T>(List<T> values, T element) where T : IComparable
        {
            values = values.Where(x => x.CompareTo(element) == 1).ToList();

            return values.Count;
        }
    }
}
