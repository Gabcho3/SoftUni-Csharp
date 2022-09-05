using System;
using System.Collections.Generic;
using System.Linq;

namespace T06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();
            List<Box> boxes = new List<Box>();

            while (data[0] != "end")
            {
                //Item Properties
                string itemName = data[1];
                double itemPrice = double.Parse(data[3]);

                //Box Properties
                int serialNumber = int.Parse(data[0]);
                int itemQuantity = int.Parse(data[2]);

                //Creating new items and boxes
                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, itemQuantity, itemPrice, item);

                //Adding currBox to List of boxes
                boxes.Add(box);

                data = Console.ReadLine().Split();
            }

            //Ordering price for a box by descending 
            boxes = boxes.OrderByDescending(box => box.Price).ToList();

            //Printing List of boxes
            foreach (Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
    }

    class Item
    {
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }
    }

    class Box
    {
        public Box(int serialNumber, int quantity, double itemPrice, Item item)
        {
            SerialNumber = serialNumber;
            ItemQuantity = quantity;
            Price = quantity * itemPrice;
            Item = item;
        }

        public int SerialNumber { get; set; }

        public Item Item { get; set; }
       
        public int ItemQuantity { get; set; }

        public double Price { get; set; }
    }
}
