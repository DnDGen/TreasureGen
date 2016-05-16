using System;
using System.Collections.Generic;
using System.Xml;
using TreasureGen.Domain.Tables;

namespace TreasureGen.Domain.Mappers.Percentile
{
    internal class PercentileXmlMapper : IPercentileMapper
    {
        private IStreamLoader streamLoader;

        public PercentileXmlMapper(IStreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<int, string> Map(string tableName)
        {
            var table = new Dictionary<int, string>();
            var filename = string.Format("{0}.xml", tableName);
            var xmlDocument = new XmlDocument();

            using (var stream = streamLoader.LoadFor(filename))
                xmlDocument.Load(stream);

            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                var lower = Convert.ToInt32(node.SelectSingleNode("lower").InnerText);
                var upper = Convert.ToInt32(node.SelectSingleNode("upper").InnerText);
                var content = node.SelectSingleNode("content").InnerText;

                for (var i = lower; i <= upper; i++)
                    table.Add(i, content);
            }

            return table;
        }
    }
}