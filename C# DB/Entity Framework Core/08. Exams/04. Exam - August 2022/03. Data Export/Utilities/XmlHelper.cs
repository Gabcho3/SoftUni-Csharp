using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.Utilities
{
    public class XmlHelper
    {
        public static T Deserialize<T>(string xmlInput, string rootName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            StringReader reader = new StringReader(xmlInput);

            T deserializedDtos = (T)serializer.Deserialize(reader)!;

            return deserializedDtos;
        }

        public static string Serialize<T>(T dto, string rootName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, dto, namespaces);

            return sb.ToString();
        }
    }
}
