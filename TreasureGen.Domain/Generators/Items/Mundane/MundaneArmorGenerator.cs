using TreasureGen.Domain.Selectors.Attributes;
using TreasureGen.Domain.Selectors.Percentiles;
using TreasureGen.Domain.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneArmorGenerator : MundaneItemGenerator
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
            var armor = new Item();
            armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors);

            if (armor.Name == AttributeConstants.Shield)
                armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneShields);

            armor.ItemType = ItemTypeConstants.Armor;
            var tableName = string.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, armor.ItemType);
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