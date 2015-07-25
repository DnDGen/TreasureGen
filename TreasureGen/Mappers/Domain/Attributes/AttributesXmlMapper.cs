using System;
using System.Collections.Generic;
using System.Xml;
using TreasureGen.Tables;

namespace TreasureGen.Mappers.Domain.Attributes
{
    public class AttributesXmlMapper : IAttributesMapper
    {
        private IStreamLoader streamLoader;

        public AttributesXmlMapper(IStreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<String, IEnumerable<String>> Map(String tableName)
        {
            var results = new Dictionary<String, IEnumerable<String>>();
            var filename = String.Format("{0}.xml", tableName);
            var xmlDocument = new XmlDocument();

            using (var stream = streamLoader.LoadFor(filename))
                xmlDocument.Load(stream);

            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                var name = node.SelectSingleNode("name").InnerText;
                var attributes = GetAttributesFrom(node);

                results.Add(name, attributes);
            }

            return results;
        }

        private IEnumerable<String> GetAttributesFrom(XmlNode node)
        {
            var attributes = new List<String>();
            var attributesFromNode = node.SelectNodes("attribute");

            foreach (XmlNode attributeNode in attributesFromNode)
                attributes.Add(attributeNode.InnerText);

            return attributes;
        }
    }
}