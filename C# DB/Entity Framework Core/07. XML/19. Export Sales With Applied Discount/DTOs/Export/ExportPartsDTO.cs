using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _17._Export_Cars_With_Their_List_Of_Parts.DTOs.Export
{
    [XmlType("part")]
    public class ExportPartsDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
