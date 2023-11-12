using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _11._Import_Cars.DTOs.Import
{
    [XmlType("Car")]
    public class ImportCarsDTO
    {
        [XmlElement("make")] public string Make { get; set; } = null!;

        [XmlElement("model")] public string Model { get; set; } = null!;

        [XmlElement("traveledDistance")] public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public HashSet<PartIdsDTO> PartIds { get; set; }
    }

    [XmlType("partId")]
    public class PartIdsDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
