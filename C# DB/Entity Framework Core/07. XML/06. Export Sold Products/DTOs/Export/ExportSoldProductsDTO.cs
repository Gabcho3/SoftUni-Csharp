using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using _05._Export_Products_In_Range.DTOs.Export;

namespace _06._Export_Sold_Products.DTOs.Export
{
    [XmlType("User")]
    public class ExportSoldProductsDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [XmlArray("soldProducts")]
        public ProductDTO[] SoldProducts { get; set; } = null!;
    }
}
