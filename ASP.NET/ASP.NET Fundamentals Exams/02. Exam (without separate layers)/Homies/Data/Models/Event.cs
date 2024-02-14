using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static Homies.Constants.DataConstants.EventConstants;

namespace Homies.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string OrganiserId { get; set; } = null!;

        [ForeignKey(nameof(OrganiserId))]
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = DateStringFormat)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateStringFormat)]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateStringFormat)]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;

        public ICollection<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
    }
}
//•	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//•	Has Start – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//•	Has End – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//•	Has TypeId – an integer, foreign key (required)
//•	Has Type – a Type (required)
//•	Has EventsParticipants – a collection of type EventParticipant

