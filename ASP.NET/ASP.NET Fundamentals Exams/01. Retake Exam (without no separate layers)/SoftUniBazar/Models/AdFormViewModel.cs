using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using static SoftUniBazar.Data.DataConstants.AdConstants;

namespace SoftUniBazar.Models
{
    public class AdFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name must be between {2} and {1} characters!")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Description must be between {2} and {1} characters!")]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
