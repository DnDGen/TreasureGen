using System;
using System.Collections.Generic;
using System.Xml;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Mappers
{
    public class SpecialAbilityDataXmlParser : ISpecialAbilityDataXmlParser
    {
        private IStreamLoader streamLoader;

        public SpecialAbilityDataXmlParser(IStreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<String, SpecialAbilityDataObject> Parse(String fileName)
        {
            var results = new Dictionary<String, SpecialAbilityDataObject>();

            using (var stream = streamLoader.LoadStream(fileName))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(stream);

                var objects = xmlDocument.DocumentElement.ChildNodes;
                foreach (XmlNode node in objects)
                {
                    var name = node.SelectSingleNode("name").InnerText;
                    var specialAbilityData = new SpecialAbilityDataObject();

                    specialAbilityData.BonusEquivalent = Convert.ToInt32(node.SelectSingleNode("bonus").InnerText);
                    specialAbilityData.CoreName = node.SelectSingleNode("coreName").InnerText;
                    specialAbilityData.Strength = Convert.ToInt32(node.SelectSingleNode("strength").InnerText);

                    results.Add(name, specialAbilityData);
                }
            }

            return results;
        }
    }
}