using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CarDealer.Models;

namespace _18._Export_Total_Sales_By_Customer.DTOs.Export
{
    [XmlType("customer")]
    public class ExportCustomersTotalSalesDTO
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; } = null!;

        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }

        [XmlIgnore]
        public bool IsYoungerDriver { get; set; }
    }
}
