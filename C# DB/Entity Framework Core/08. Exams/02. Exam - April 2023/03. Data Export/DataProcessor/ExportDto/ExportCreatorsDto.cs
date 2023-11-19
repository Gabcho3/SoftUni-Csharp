using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorsDto
    {
        [XmlAttribute("BoardgamesCount")]
        public int BoardGamesCount { get; set; }

        [XmlElement("CreatorName")]
        public string Name { get; set; }

        [XmlArray("Boardgames")]
        public List<ExportBoardgamesDto> Boardgames { get; set; }
    }
}
