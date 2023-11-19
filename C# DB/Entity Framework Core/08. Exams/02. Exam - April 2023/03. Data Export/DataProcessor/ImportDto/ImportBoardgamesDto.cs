using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgamesDto
    {
        [XmlElement("Name")]
        [StringLength(maximumLength: 20, MinimumLength = 10)]
        public string? Name { get; set; }

        [XmlElement("Rating")]
        [Range(1.00, 10.00)]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Range(2018, 2023)]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Range(0, 4)]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}
