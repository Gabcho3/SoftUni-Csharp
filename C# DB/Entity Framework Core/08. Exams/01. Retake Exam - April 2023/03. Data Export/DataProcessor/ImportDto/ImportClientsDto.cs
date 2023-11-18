using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Invoices;

namespace DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientsDto
    {
        [StringLength(maximumLength: 25, MinimumLength = 10)]
        [XmlElement("Name")]
        public string? Name { get; set; }

        [StringLength(maximumLength: 15, MinimumLength = 10)]
        [XmlElement("NumberVat")]
        public string? NumberVat { get; set; }

        [XmlArray("Addresses")]
        public List<ImportAddressesDto> Addresses { get; set; }
    }
}
