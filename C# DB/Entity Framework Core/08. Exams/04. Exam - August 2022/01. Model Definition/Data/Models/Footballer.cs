using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footballers.Data.Models.Enums;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public Footballer()
        {
            TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        public DateTime ContractStartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        [Range(0, 3)]
        public PositionType Position { get; set; }

        [Range(0, 4)]
        public BestSkillType BestSkill { get; set; }

        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }
        public Coach Coach { get; set; } = null!;

        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
