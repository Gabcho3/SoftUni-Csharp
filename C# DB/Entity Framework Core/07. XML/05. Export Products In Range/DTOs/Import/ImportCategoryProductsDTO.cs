using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _04._Import_Categories_and_Products.DTOs.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductsDTO
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]

        public int ProductId { get; set; }
    }
}
