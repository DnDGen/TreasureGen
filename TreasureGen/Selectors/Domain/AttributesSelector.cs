using System;
using System.Collections.Generic;
using TreasureGen.Mappers;

namespace TreasureGen.Selectors.Domain
{
    public class AttributesSelector : IAttributesSelector
    {
        private IAttributesMapper attributesMapper;

        public AttributesSelector(IAttributesMapper attributesMapper)
        {
            this.attributesMapper = attributesMapper;
        }

        public IEnumerable<String> SelectFrom(String tableName, String name)
        {
            var table = attributesMapper.Map(tableName);

            if (!table.ContainsKey(name))
            {
                var message = String.Format("{0} is not in the table {1}", name, tableName);
                throw new ArgumentException(message);
            }

            return table[name];
        }
    }
}