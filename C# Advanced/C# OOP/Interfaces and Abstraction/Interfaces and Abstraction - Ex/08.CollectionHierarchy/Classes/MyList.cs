using _08.Collecti.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Collecti.Classes
{
    public class MyList : IAddable, IRemovable, ICountable
    {
        private List<string> myList;

        public MyList()
        {
            myList = new List<string>();
        }

        public int Used => myList.Count;

        public List<int> Add(string[] items)
        {
            foreach (string item in items)
            {
                myList.Insert(0, item);
            }
            List<int> indexes = new List<int>();

            while (indexes.Count < myList.Count)
                indexes.Add(0);

            return indexes;
        }

        public List<string> Remove(int times)
        {
            List<string> removedItems = new List<string>();

            while (removedItems.Count < times)
            {
                removedItems.Add(myList[0]);
                myList.RemoveAt(0);
            }
            return removedItems;
        }
    }
}
