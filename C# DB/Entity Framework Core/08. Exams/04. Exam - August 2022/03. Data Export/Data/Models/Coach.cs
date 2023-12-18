using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            Footballers = new HashSet<Footballer>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public ICollection<Footballer> Footballers { get; set; }
    }
}
