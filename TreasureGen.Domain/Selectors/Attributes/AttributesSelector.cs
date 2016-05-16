using System;
using System.Collections.Generic;
using TreasureGen.Domain.Mappers.Attributes;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal class AttributesSelector : IAttributesSelector
    {
        private IAttributesMapper attributesMapper;

        public AttributesSelector(IAttributesMapper attributesMapper)
        {
            this.attributesMapper = attributesMapper;
        }

        public IEnumerable<string> SelectFrom(string tableName, string name)
        {
            var table = attributesMapper.Map(tableName);

            if (!table.ContainsKey(name))
            {
                var message = string.Format("{0} is not in the table {1}", name, tableName);
                throw new ArgumentException(message);
            }

            return table[name];
        }
    }
}