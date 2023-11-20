using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required(AllowEmptyStrings = true)]
        public string? Position { get; set; }

        public ICollection<Truck> Trucks { get; set; } = new HashSet<Truck>();
    }
}
