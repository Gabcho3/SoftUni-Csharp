using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices
{
    [XmlType("Address")]
    public class ImportAddressesDto
    {
        [StringLength(maximumLength: 20, MinimumLength = 10)]
        [XmlElement("StreetName")]
        public string? StreetName { get; set; }

        [XmlElement("StreetNumber")]
        public int? StreetNumber { get; set; }

        [XmlElement("PostCode")]
        public string? PostCode { get; set; }

        [StringLength(maximumLength: 15, MinimumLength = 5)]
        [XmlElement("City")]
        public string? City { get; set; }

        [StringLength(maximumLength: 15, MinimumLength = 5)]
        [XmlElement("Country")]
        public string? Country { get; set; }
    }
}
