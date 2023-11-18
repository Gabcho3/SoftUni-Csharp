using System.ComponentModel.DataAnnotations;
using Invoices.Data.Models.Enums;

namespace Invoices.Data.Models
{
    public class Product
    {
        public Product()
        {
            ProductsClients = new HashSet<ProductClient>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 9)]
        public string Name { get; set; } = null!;

        [Range(5.00, 1000.00)]
        public decimal Price { get; set; }

        [Range(0, 4)]
        public CategoryType CategoryType { get; set; }

        public ICollection<ProductClient> ProductsClients { get; set; }
    }
}
