using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }

        public List<Drink> Drinks { get; set; }

        public int GetCount => Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (GetCount < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            Drink drink = Drinks.FirstOrDefault(d => d.Name == name);
            return Drinks.Remove(drink);
        }

        public Drink GetLongest() 
            => Drinks.OrderByDescending(d => d.Volume).FirstOrDefault();

        public Drink GetCheapest() 
            => Drinks.OrderBy(d => d.Price).FirstOrDefault();

        public string BuyDrink(string name)
            => Drinks.Find(d => d.Name == name).ToString();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");

            foreach (var drink in Drinks)
                sb.AppendLine(drink.ToString());

            return sb.ToString();
        }
    }
}
