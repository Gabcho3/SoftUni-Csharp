using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.DataConstants.CategoryConstants;

namespace SoftUniBazar.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
