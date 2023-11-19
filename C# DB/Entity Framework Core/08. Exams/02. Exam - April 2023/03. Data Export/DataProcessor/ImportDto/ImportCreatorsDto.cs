using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorsDto
    {
        [XmlElement("FirstName")]
        [StringLength(7, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [XmlElement("LastName")]
        [StringLength(7, MinimumLength = 2)]
        public string? LastName { get; set; }

        [XmlArray("Boardgames")]
        public List<ImportBoardgamesDto> Boardgames { get; set; }
    }
}
