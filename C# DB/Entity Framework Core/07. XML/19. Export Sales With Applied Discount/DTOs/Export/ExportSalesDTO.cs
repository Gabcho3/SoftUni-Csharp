using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using _14._Export_Cars_With_Distance.DTOs.Export;

namespace _19._Export_Sales_With_Applied_Discount.DTOs.Export
{
    [XmlType("sale")]
    public class ExportSalesDTO
    {
        [XmlElement("car")]
        public ExportCarsDTO Car{ get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
