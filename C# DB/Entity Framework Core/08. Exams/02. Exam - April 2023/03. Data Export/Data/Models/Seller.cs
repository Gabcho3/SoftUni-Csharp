using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 5)] 
        public string Name { get; set; } = null!;

        [StringLength(30, MinimumLength = 2)]
        public string Address { get; set; } = null!;

        public string Country { get; set; } = null!;

        [RegularExpression("^www[.][A-Za-z\\d-]+[.]com$")]
        public string Website { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
