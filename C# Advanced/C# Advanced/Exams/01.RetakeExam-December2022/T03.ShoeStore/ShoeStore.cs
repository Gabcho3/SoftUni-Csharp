using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private readonly List<Shoe> shoes;

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            shoes = new List<Shoe>();
        }

        public string Name { get; }

        public int StorageCapacity { get; }

        IReadOnlyCollection<Shoe> Shoes => shoes;

        public int Count => shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Count == StorageCapacity)
            {
                return "No more space in the storage room";
            }

            shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            return shoes.RemoveAll(s => s.Material == material);
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return shoes.Where(s => s.Type.ToLower() == type.ToLower()).ToList();
        }

        public Shoe GetShoeBySize(double size)
        {
            return shoes.FirstOrDefault(s => s.Size == size);
        }

        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            List<Shoe> matchedShoes = shoes.Where(s => s.Size == size && s.Type == type).ToList();

            if (matchedShoes.Count > 0)
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var shoe in matchedShoes)
                    sb.AppendLine(shoe.ToString());
            }

            else
            {
                sb.AppendLine("No matches found!");
            }

            return sb.ToString().Trim();
        }
    }
}
