using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Mundane;
using TreasureGen.Selectors;
using TreasureGen.Tables;

namespace TreasureGen.Generators.Domain.Items.Mundane
{
    public class MundaneArmorGenerator : IMundaneItemGenerator
    {
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;

        public MundaneArmorGenerator(IPercentileSelector percentileSelector, IAttributesSelector attributesSelector,
            IBooleanPercentileSelector booleanPercentileSelector)
        {
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
        }

        public Item Generate()
        {
            var result = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors);
            var armor = new Item();

            if (result == TraitConstants.Darkwood)
            {
                armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.DarkwoodShields);
                armor.Traits.Add(TraitConstants.Darkwood);
            }
            else if (result == AttributeConstants.Shield)
            {
                armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields);
            }
            else
            {
                armor.Name = result;
            }

            armor.ItemType = ItemTypeConstants.Armor;
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, armor.ItemType);
            armor.Attributes = attributesSelector.SelectFrom(tableName, armor.Name);

            var isMasterwork = booleanPercentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.IsMasterwork);
            if (isMasterwork)
                armor.Traits.Add(TraitConstants.Masterwork);

            var size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneGearSizes);
            armor.Traits.Add(size);

            return armor;
        }
    }
}