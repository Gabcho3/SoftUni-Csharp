using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using _06._Export_Sold_Products.DTOs;

namespace _08._Export_Users_and_Products.DTOs.Export
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductsWithCount
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductDTO[] Products { get; set; }
    }
}
