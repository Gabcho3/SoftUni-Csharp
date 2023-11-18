using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Data.Models.Enums;

namespace Invoices.Data.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Range(maximum:1_500_000_000, minimum: 1_000_000_000)]
        public int Number { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal Amount { get; set; }

        [Range(maximum: 2, minimum: 0)]
        public CurrencyType CurrencyType { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
