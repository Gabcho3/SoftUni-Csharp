using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }

        public int StorageCapacity { get; set; }

        public List<Shoe> Shoes { get; set; }

        public int Count()
        {
            return Shoes.Count;
        }

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int currCount = Shoes.Count;
            Shoes.RemoveAll(x => x.Material == material);
            return currCount - Shoes.Count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.Where(x => x.Type == type.ToLower()).ToList();
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.Where(x => x.Size == size).First();
        }

        public string StockList(double size, string type)
        {
            List<Shoe> matches = Shoes.Where(x => x.Size == size && x.Type == type).ToList();

            if (matches.Count == 0)
                return "No matches found!";

            StringBuilder output = new StringBuilder();

            output.Append($"Stock list for size {size} - {type} shoes");
            foreach (var shoe in matches)
            {
                output.Append(Environment.NewLine + shoe.ToString());
            }

            return output.ToString();
        }
    }
}
