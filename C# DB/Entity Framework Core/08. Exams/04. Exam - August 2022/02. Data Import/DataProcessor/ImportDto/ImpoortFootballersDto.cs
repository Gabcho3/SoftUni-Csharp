using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Footballers.Data.Models.Enums;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImpoortFootballersDto
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [Required]
        [XmlElement("PositionType")]
        [Range(0, 3)]
        public int Position { get; set; }

        [Required]
        [XmlElement("BestSkillType")]
        [Range(0, 4)]
        public int BestSkill { get; set; }
    }
}
