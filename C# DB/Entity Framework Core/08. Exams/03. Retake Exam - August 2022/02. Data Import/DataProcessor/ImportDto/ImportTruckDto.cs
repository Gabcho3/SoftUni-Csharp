using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [RegularExpression("^[A-Z]{2}[\\d]{4}[A-Z]{2}$")]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [StringLength(17)]
        public string? VinNumber { get; set; }

        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(5_000, 29_000)]
        public int CargoCapacity { get; set; }

        [XmlElement("CategotyType")]
        [Range(0, 3)]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Range(0, 4)]
        public int MakeType { get; set; }
    }
}
