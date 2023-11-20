using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.Utilities
{
    public class XmlHelper
    {
        public static T Deserialize<T>(string xmlString, string rootName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            StringReader xmlReader = new StringReader(xmlString);

            return (T)serializer.Deserialize(xmlReader)!;
        }

        public static string Seserialize<T>(T dto, string rootName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, dto, xmlns);

            return sb.ToString();
        }
    }
}
