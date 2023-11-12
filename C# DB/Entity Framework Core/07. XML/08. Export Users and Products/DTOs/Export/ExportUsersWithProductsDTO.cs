using System.Xml.Serialization;

namespace _08._Export_Users_and_Products.DTOs.Export
{
    [XmlRoot("Users")]
    public class ExportUsersWithProductsDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserDTO[] Users { get; set; }
    }
}
