using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _02._Import_Products.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StreamReader reader = new StreamReader(inputXml);

            T deserializedDtos = (T)serializer.Deserialize(reader)!;

            return deserializedDtos;
        }
    }
}
