using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellersDto
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 5)]
        public string? Name { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)] 
        public string? Address { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        [RegularExpression("^www[.][A-Za-z\\d-]+[.]com$")]
        public string? Website { get; set; }

        [JsonProperty("Boardgames")]
        public HashSet<int> BoardgamesId { get; set; }
    }
}
