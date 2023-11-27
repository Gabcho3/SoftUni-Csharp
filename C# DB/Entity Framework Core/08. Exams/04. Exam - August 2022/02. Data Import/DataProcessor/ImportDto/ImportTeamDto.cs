using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [RegularExpression(@"^[A-Za-z\d\s.-]*$")]
        [StringLength(maximumLength: 40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public string Trophies { get; set; }

        [JsonProperty("Footballers")]
        public HashSet<int> FootballersIds { get; set; }
    }
}
