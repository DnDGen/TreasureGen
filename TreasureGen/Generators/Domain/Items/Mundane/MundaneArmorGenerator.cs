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

        public MundaneArmorGenerator(IPercentileSelector percentileSelector, IAttributesSelector attributesSelector)
        {
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
        }

        public Item Generate()
        {
            var result = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MundaneArmors);

            if (result == TraitConstants.Darkwood)
                return GenerateDarkwoodShield();

            var armor = new Item();

            if (result == TraitConstants.Masterwork)
            {
                armor.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.MasterworkShields);
                armor.Traits.Add(result);
            }
            else
            {
                armor.Name = result;
            }

            armor.ItemType = ItemTypeConstants.Armor;
            var tableName = String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, armor.ItemType);
            armor.Attributes = attributesSelector.SelectFrom(tableName, armor.Name);

            if (armor.Name == ArmorConstants.StuddedLeatherArmor)
                armor.Traits.Add(TraitConstants.Masterwork);

            var size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.ArmorSizes);
            armor.Traits.Add(size);

            return armor;
        }

        private Item GenerateDarkwoodShield()
        {
            var shield = new Item();

            shield.Name = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.DarkwoodShields);

            var tableName = String.Format(TableNameConstants.Attributes.Formattable.SpecificITEMTYPEAttributes, AttributeConstants.Shield);
            shield.Attributes = attributesSelector.SelectFrom(tableName, shield.Name);
            shield.Traits.Add(TraitConstants.Darkwood);
            shield.ItemType = ItemTypeConstants.Armor;

            var size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.ArmorSizes);
            shield.Traits.Add(size);

            return shield;
        }
    }
}