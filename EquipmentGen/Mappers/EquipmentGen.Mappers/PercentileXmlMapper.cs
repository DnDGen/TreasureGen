using System;
using System.Collections.Generic;
using System.Xml;
using EquipmentGen.Mappers.Interfaces;
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

        public Dictionary<Int32, String> Map(String tableName)
        {
            var table = new Dictionary<Int32, String>();
            var filename = String.Format("{0}.xml", tableName);

            using (var stream = streamLoader.LoadFor(filename))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(stream);

                var objects = xmlDocument.DocumentElement.ChildNodes;
                foreach (XmlNode node in objects)
                {
                    var lower = Convert.ToInt32(node.SelectSingleNode("lower").InnerText);
                    var upper = Convert.ToInt32(node.SelectSingleNode("upper").InnerText);
                    var content = node.SelectSingleNode("content").InnerText;

                    for (var i = lower; i <= upper; i++)
                        table.Add(i, content);
                }
            }

            return table;
        }
    }
}