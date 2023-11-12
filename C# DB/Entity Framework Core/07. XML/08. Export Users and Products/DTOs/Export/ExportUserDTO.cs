using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _08._Export_Users_and_Products.DTOs.Export
{
    [XmlType("User")]
    public class ExportUserDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
        
        [XmlElement("SoldProducts")]
        public ExportSoldProductsWithCount SoldProducts { get; set; }
    }
}
