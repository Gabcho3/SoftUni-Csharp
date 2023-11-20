using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Nationality { get; set; } = null!;

        public string Type { get; set; } = null!;

        public ICollection<ClientTruck> ClientsTrucks { get; set; } = new HashSet<ClientTruck>();
    }
}
