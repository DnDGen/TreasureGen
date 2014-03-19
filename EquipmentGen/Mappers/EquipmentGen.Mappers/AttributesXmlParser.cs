using System;
using System.Collections.Generic;
using System.Xml;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Mappers
{
    public class AttributesXmlParser : IAttributesMapper
    {
        private IStreamLoader streamLoader;

        public AttributesXmlParser(IStreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<String, IEnumerable<String>> Parse(String fileName)
        {
            var results = new Dictionary<String, IEnumerable<String>>();

            using (var stream = streamLoader.LoadStream(fileName))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(stream);

                var objects = xmlDocument.DocumentElement.ChildNodes;
                foreach (XmlNode node in objects)
                {
                    var name = node.SelectSingleNode("name").InnerText;
                    var attributes = GetTypesFrom(node);

                    results.Add(name, attributes);
                }
            }

            return results;
        }

        private IEnumerable<String> GetTypesFrom(XmlNode node)
        {
            var attributes = new List<String>();
            var attributesFromNode = node.SelectNodes("attribute");

            foreach (XmlNode attributeNode in attributesFromNode)
                attributes.Add(attributeNode.InnerText);

            return attributes;
        }
    }
}