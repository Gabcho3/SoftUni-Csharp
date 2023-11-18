using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 10)]
        public string StreetName { get; set; } = null!;

        public int StreetNumber { get; set; }

        public string PostCode { get; set; } = null!;

        [StringLength(maximumLength: 15, MinimumLength = 5)]
        public string City { get; set; } = null!;

        [StringLength(maximumLength: 15, MinimumLength = 5)]
        public string Country { get; set; } = null!;

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
