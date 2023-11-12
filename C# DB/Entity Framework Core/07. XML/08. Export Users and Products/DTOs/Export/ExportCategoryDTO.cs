using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProductShop.Models;

namespace _07._Export_Categories_By_Products_Count.DTOs.Export
{
    [XmlType("Category")]
    public class ExportCategoryDTO
    {

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
