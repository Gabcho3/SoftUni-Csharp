using _08.Collecti.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _08.Collecti.Classes
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        private List<string> addRemoveCollection;

        public AddRemoveCollection()
        {
            addRemoveCollection = new List<string>();
        }

        public List<int> Add(string[] items)
        {
            foreach (string item in items)
            {
                addRemoveCollection.Insert(0, item);
            }
            List<int> indexes = new List<int>();

            while (indexes.Count < addRemoveCollection.Count)
                indexes.Add(0);

            return indexes;
        }

        public List<string> Remove(int times)
        {
            List<string> removedItems = new List<string>();

            int index = addRemoveCollection.Count - 1;
            while (removedItems.Count < times)
            {
                removedItems.Add(addRemoveCollection[index--]);
            }
            addRemoveCollection.RemoveRange(index + 1, times);
            return removedItems;
        }
    }
}
