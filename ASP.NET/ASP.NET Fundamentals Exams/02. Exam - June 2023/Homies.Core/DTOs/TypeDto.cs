using System.ComponentModel.DataAnnotations;

namespace Homies.Core.DTOs
{
    public class TypeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Name { get; set; } = null!;
    }
}
