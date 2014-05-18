using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalItemTraitsGenerator : IMagicalItemTraitsGenerator
    {
        private IPercentileSelector percentileSelector;

        public MagicalItemTraitsGenerator(IPercentileSelector percentileSelector)
        {
            this.percentileSelector = percentileSelector;
        }

        public IEnumerable<String> GenerateFor(String itemType, IEnumerable<String> attributes)
        {
            var tableName = String.Empty;

            if (itemType == ItemTypeConstants.Weapon)
            {
                if (attributes.Contains(AttributeConstants.Melee))
                    tableName = String.Format("{0}{1}Traits", AttributeConstants.Melee, itemType);
                else if (attributes.Contains(AttributeConstants.Ranged))
                    tableName = String.Format("{0}{1}Traits", AttributeConstants.Ranged, itemType);
                else
                    throw new ArgumentException("Weapon is not melee or ranged");
            }
            else
            {
                tableName = String.Format("{0}Traits", itemType);
            }

            var result = percentileSelector.SelectFrom(tableName);

            if (String.IsNullOrEmpty(result))
                return Enumerable.Empty<String>();

            return result.Split(',');
        }
    }
}