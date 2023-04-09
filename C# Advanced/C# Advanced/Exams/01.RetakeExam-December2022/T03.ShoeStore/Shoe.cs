namespace ShoeStore
{
    public class Shoe
    { 
        public Shoe(string brand, string type, double size, string material)
        {
            Brand = brand;
            Type = type;
            Size = size;
            Material = material;
        }

        public string Brand { get;  }

        public string Type { get; }

        public double Size { get; }

        public string Material { get; }

        public override string ToString()
            => $"Size {Size}, {Material} {Brand} {Type} shoe.";
    }
}
