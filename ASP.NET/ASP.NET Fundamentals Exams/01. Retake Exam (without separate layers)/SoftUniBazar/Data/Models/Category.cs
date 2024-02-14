using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.DataConstants.CategoryConstants;

namespace SoftUniBazar.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Ad> Ads { get; set; } = new List<Ad>();
    }
}
