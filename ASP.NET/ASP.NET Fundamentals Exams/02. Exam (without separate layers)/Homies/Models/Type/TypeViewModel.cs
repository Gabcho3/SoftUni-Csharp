using System.ComponentModel.DataAnnotations;
using static Homies.Constants.DataConstants.TypeConstants;

namespace Homies.Models.Type
{
    public class TypeViewModel
    {
        public TypeViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters!")]
        public string Name { get; set; } = null!;
    }
}
