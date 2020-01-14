using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Selectors.Percentiles;
using DnDGen.TreasureGen.Tables;
using DnDGen.TreasureGen.Items;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class MagicalItemTraitsGenerator : IMagicalItemTraitsGenerator
    {
        private readonly ITreasurePercentileSelector percentileSelector;

        public MagicalItemTraitsGenerator(ITreasurePercentileSelector percentileSelector)
        {
            this.percentileSelector = percentileSelector;
        }

        public IEnumerable<string> GenerateFor(string itemType, IEnumerable<string> attributes)
        {
            var tableName = GetTableName(itemType, attributes);
            var result = percentileSelector.SelectFrom(tableName);

            if (string.IsNullOrEmpty(result))
                return Enumerable.Empty<string>();

            return result.Split(',');
        }

        private string GetTableName(string itemType, IEnumerable<string> attributes)
        {
            if (attributes.Contains(AttributeConstants.Melee))
                return string.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, AttributeConstants.Melee);

            if (attributes.Contains(AttributeConstants.Ranged))
                return string.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, AttributeConstants.Ranged);

            return string.Format(TableNameConstants.Percentiles.Formattable.ITEMTYPETraits, itemType);
        }
    }
}