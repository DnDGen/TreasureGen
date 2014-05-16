using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

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
            var result = percentileSelector.SelectFrom("MundaneArmors");
            var armor = new Item();

            if (result == TraitConstants.Darkwood)
            {
                var tableName = String.Format("{0}Shields", result);
                armor.Name = percentileSelector.SelectFrom(tableName);
                armor.Attributes = attributesSelector.SelectFrom("SpecificShieldsAttributes", armor.Name);
                armor.Traits.Add(result);
                armor.ItemType = ItemTypeConstants.Armor;

                return armor;
            }
            else if (result == TraitConstants.Masterwork)
            {
                var tableName = String.Format("{0}Shields", result);
                armor.Name = percentileSelector.SelectFrom(tableName);
                armor.Traits.Add(result);
            }
            else
            {
                armor.Name = result;
            }

            armor.Attributes = attributesSelector.SelectFrom("ArmorAttributes", armor.Name);
            armor.ItemType = ItemTypeConstants.Armor;

            if (armor.Name == ArmorConstants.StuddedLeatherArmor)
                armor.Traits.Add(TraitConstants.Masterwork);

            var size = percentileSelector.SelectFrom("ArmorSizes");
            armor.Traits.Add(size);

            return armor;
        }
    }
}