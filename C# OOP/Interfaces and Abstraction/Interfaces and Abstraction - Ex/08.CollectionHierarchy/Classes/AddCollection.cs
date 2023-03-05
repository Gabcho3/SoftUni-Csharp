using _08.Collecti.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Collecti.Classes
{
    public class AddCollection : IAddable
    {
        private List<string> addCollection;

        public AddCollection()
        {
            addCollection = new List<string>();
        }

        public List<int> Add(string[] items)
        {
            foreach(string item in items)
            {
                addCollection.Add(item);
            }
            int index = 0;
            List<int> indexes = new List<int>();

            for(int i = 0; i < addCollection.Count; i++)
            {
                indexes.Add(index++);
            }

            return indexes;
        }
    }
}
