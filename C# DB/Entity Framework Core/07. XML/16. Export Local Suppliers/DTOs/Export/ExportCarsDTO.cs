using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _14._Export_Cars_With_Distance.DTOs.Export
{
    [XmlType("car")]
    public class ExportCarsDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("traveled-distance")]
        public long TraveledDistance { get; set; }
    }
}
