using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _13._Import_Sales.DTOs.Import
{
    [XmlType("Sale")]
    public class ImportSalesDTO
    {
        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("carId")]
        public int? CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }
    }
}
