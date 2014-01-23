using System;
using System.Collections.Generic;
using System.Xml;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;

namespace EquipmentGen.Core.Generation.Xml.Parsers
{
    public class GearTypesXmlParser : IGearTypesXmlParser
    {
        private IStreamLoader streamLoader;

        public GearTypesXmlParser(IStreamLoader streamLoader)
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
                    var name = node.SelectSingleNode("gear").InnerText;
                    var types = GetTypesFrom(node);

                    results.Add(name, types);
                }
            }

            return results;
        }

        private IEnumerable<String> GetTypesFrom(XmlNode node)
        {
            var types = new List<String>();
            var typesFromNode = node.SelectNodes("type");

            foreach (XmlNode typeNode in typesFromNode)
                types.Add(typeNode.InnerText);

            return types;
        }
    }
}