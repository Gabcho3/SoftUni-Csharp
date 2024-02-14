using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Homies.Models.Type;
using static Homies.Constants.DataConstants.EventConstants;

namespace Homies.Models.Event
{
    public class EventFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters!")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "{0} must be between {2} and {1} characters!")]
        public string Description { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = DateStringFormat)]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateStringFormat)]
        public DateTime End { get; set; }

        public string OrganiserId { get; set; }

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; }
    }
}
