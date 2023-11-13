using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _16._Export_Local_Suppliers.DTOs.Export
{
    [XmlType("supplier")]
    public class ExportSuppliers
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
