using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Castle.Components.DictionaryAdapter;

namespace Invoices
{
    public class XmlHelper
    {
        public T Deserialize<T>(string xmlInput, string xmlRootName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(xmlRootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            TextReader streamReader = new StringReader(xmlInput);

            var deserializedDtos = (T)serializer.Deserialize(streamReader)!;

            return deserializedDtos;
        }

        public string Serialize<T>(T dto, string xmlRootName)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute(xmlRootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            serializer.Serialize(writer, dto, namespaces);

            return sb.ToString();
        }
    }
}
