using System.ComponentModel.DataAnnotations;
using static Homies.Constants.DataConstants.TypeConstants;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
