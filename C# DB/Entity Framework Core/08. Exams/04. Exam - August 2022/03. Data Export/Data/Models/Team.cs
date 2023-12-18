using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data.Models
{
    public  class Team
    {
        public Team()
        {
            TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[A-Za-z\d\s.-]*$")]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Nationality { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Trophies { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
