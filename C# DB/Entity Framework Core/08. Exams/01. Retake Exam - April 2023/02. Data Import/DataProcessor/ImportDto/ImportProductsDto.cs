using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductsDto
    {
        [StringLength(maximumLength: 30, MinimumLength = 9)]
        public string? Name { get; set; }

        [Range(5.00, 1000.00)]
        public decimal Price { get; set; }

        [Range(0, 4)]
        public CategoryType CategoryType { get; set; }

        [JsonProperty("Clients")]
        public HashSet<int> ClientsId { get; set; }
    }
}
