﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _12._Import_Customers.DTOs.Import
{
    [XmlType("Customer")]
    public class ImportCustomersDTO
    {
        [XmlElement("name")]
        public string? Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
