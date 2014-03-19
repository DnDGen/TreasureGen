using System;
using System.Collections.Generic;
using System.Xml;
using EquipmentGen.Mappers.Interfaces;
using EquipmentGen.Mappers.Objects;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Mappers
{
    public class PercentileXmlMapper : IPercentileMapper
    {
        private IStreamLoader streamLoader;

        public PercentileXmlMapper(IStreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public IEnumerable<PercentileObject> Map(String filename)
        {
            var results = new List<PercentileObject>();

            using (var stream = streamLoader.LoadFor(filename))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(stream);

                var objects = xmlDocument.DocumentElement.ChildNodes;
                foreach (XmlNode node in objects)
                {
                    var percentileObject = new PercentileObject();

                    percentileObject.LowerLimit = Convert.ToInt32(node.SelectSingleNode("lower").InnerText);
                    percentileObject.Content = node.SelectSingleNode("content").InnerText;
                    percentileObject.UpperLimit = Convert.ToInt32(node.SelectSingleNode("upper").InnerText);

                    results.Add(percentileObject);
                }
            }

            return results;
        }
    }
}