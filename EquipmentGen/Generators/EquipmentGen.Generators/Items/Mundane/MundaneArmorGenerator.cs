using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Tables.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
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

            shield.Attributes = attributesSelector.SelectFrom(TableNameConstants.Attributes.Set.SpecificShieldAttributes, shield.Name);
            shield.Traits.Add(TraitConstants.Darkwood);
            shield.ItemType = ItemTypeConstants.Armor;

            var size = percentileSelector.SelectFrom(TableNameConstants.Percentiles.Set.ArmorSizes);
            shield.Traits.Add(size);

            return shield;
        }
    }
}