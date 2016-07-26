using System.Collections.Generic;
using System.Xml;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.Mappers.Collections
{
    internal class AttributesXmlMapper : ICollectionsMapper
    {
        private IStreamLoader streamLoader;

        public AttributesXmlMapper(IStreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<string, IEnumerable<string>> Map(string tableName)
        {
            var results = new Dictionary<string, IEnumerable<string>>();
            var filename = string.Format("{0}.xml", tableName);
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

        private IEnumerable<string> GetAttributesFrom(XmlNode node)
        {
            var attributes = new List<string>();
            var attributesFromNode = node.SelectNodes("attribute");

            foreach (XmlNode attributeNode in attributesFromNode)
                attributes.Add(attributeNode.InnerText);

            return attributes;
        }
    }
}