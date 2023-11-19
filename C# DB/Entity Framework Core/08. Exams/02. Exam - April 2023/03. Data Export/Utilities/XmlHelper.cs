using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Castle.Components.DictionaryAdapter;

namespace Boardgames.Utilities
{
    public class XmlHelper
    {
        public static T Deserialize<T>(string xmlString, string rootName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            StringReader xmlReader = new StringReader(xmlString);

            var serializedDtos = (T)serializer.Deserialize(xmlReader)!;

            return serializedDtos;
        }

        public static string Serialize<T>(T dto, string rootName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, dto, namespaces);

            return sb.ToString();
        }
    }
}
