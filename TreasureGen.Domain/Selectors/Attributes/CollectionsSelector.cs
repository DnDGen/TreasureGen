using System;
using System.Collections.Generic;
using TreasureGen.Domain.Mappers.Collections;

namespace TreasureGen.Domain.Selectors.Attributes
{
    internal class CollectionsSelector : ICollectionsSelector
    {
        private ICollectionsMapper attributesMapper;

        public CollectionsSelector(ICollectionsMapper attributesMapper)
        {
            this.attributesMapper = attributesMapper;
        }

        public bool Exists(string tableName, string name)
        {
            var table = attributesMapper.Map(tableName);
            return table.ContainsKey(name);
        }

        public IEnumerable<string> SelectFrom(string tableName, string name)
        {
            if (!Exists(tableName, name))
            {
                var message = string.Format("{0} is not in the table {1}", name, tableName);
                throw new ArgumentException(message);
            }

            var table = attributesMapper.Map(tableName);
            return table[name];
        }
    }
}