using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            Item = new List<T>();
        }

        public List<T> Item { get; set; }

        public int Count => Item.Count;

        public void Add(T element)
        {
            Item.Add(element);
        }

        public T Remove()
        {
            T element = (Item.Last<T>());
            Item.Remove(element);
            return element;
        }
    }
}
