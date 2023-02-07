using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T06.GenericCountMethodDouble
{
    internal class Box<T>
    {
        public List<T> Doubles { get; set; }

        public int Counter<T>(List<T> doubles, T element) where T : IComparable
        { 
            return doubles.Where(x => x.CompareTo(element) == 1).ToList().Count; 
        }
    }
}
