using System.ComponentModel.DataAnnotations;

namespace Homies.Core.DTOs
{
    public class EventFormDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        public string OrganiserId { get; set; } = null!;

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MM/yyyy H:mm")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MM/yyyy H:mm")]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MM/yyyy H:mm")]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public List<TypeDto> Types { get; set; }
    }
}
