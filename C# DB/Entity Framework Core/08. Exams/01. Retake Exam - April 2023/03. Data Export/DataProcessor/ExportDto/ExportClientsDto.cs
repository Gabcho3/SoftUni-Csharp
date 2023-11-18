using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientsDto
    {
        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }

        [XmlElement("ClientName")]
        public string Name { get; set; }

        [XmlElement("VatNumber")]
        public string VatNumber { get; set; }

        [XmlArray("Invoices")]
        public List<ExportInvoicesDto> Invoices { get; set; }
    }
}
