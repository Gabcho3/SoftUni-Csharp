using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Data.Models.Enums;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 10)] 
        public string Name { get; set; } = null!;

        [Range(1.00, 10.00)]
        public double Rating { get; set; }

        [Range(2018, 2023)]
        public int YearPublished { get; set; }

        [Range(0, 4)]
        public CategoryType CategoryType { get; set; }

        public string Mechanics { get; set; } = null!;

        public int CreatorId { get; set; }
        public Creator Creator { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
