using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [XmlElement("Name")]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        public string? Name { get; set; }

        [XmlElement("Position")]
        [Required(AllowEmptyStrings = true)]
        public string? Position { get; set; }

        [XmlArray("Trucks")]
        public List<ImportTruckDto> Trucks { get; set; }
    }
}
