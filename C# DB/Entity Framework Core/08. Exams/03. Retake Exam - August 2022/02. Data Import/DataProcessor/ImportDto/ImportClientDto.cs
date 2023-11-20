using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string? Nationality { get; set; }

        public string? Type { get; set; }

        [JsonProperty("Trucks")]
        public HashSet<int> TrucksIds { get; set; }
    }
}
