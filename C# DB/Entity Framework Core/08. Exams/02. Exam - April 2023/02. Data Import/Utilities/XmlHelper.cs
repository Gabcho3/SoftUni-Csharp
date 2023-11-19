using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
    }
}
