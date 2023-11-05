using Newtonsoft.Json;

namespace CarDealer.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }

        [JsonIgnore]
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();

        [JsonIgnore]
        public ICollection<PartCar> PartsCars { get; set; } = new List<PartCar>();
    }
}
