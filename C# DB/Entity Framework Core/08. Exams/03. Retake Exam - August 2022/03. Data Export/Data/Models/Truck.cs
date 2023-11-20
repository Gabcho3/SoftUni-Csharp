using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression("^[A-Z]{2}[\\d]{4}[A-Z]{2}$")]
        public string RegistrationNumber { get; set; } = null!;

        [StringLength(17)]
        public string VinNumber { get; set; } = null!;

        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        [Range(5_000, 29_000)]
        public int CargoCapacity { get; set; }

        public CategoryType CategoryType { get; set; }

        public MakeType MakeType { get; set; }

        public int DespatcherId  { get; set; }
        public Despatcher Despatcher { get; set; } = null!;

        public ICollection<ClientTruck> ClientsTrucks { get; set; } = new HashSet<ClientTruck>();
    }
}
