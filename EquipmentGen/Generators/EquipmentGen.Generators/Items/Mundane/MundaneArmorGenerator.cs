using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class MundaneArmorGenerator : IMundaneGearGenerator
    {
        private IPercentileSelector percentileSelector;
        private ISpecialMaterialGenerator materialsSelector;
        private IAttributesSelector attributesSelector;
        private IDice dice;

        public MundaneArmorGenerator(IPercentileSelector percentileSelector, ISpecialMaterialGenerator materialsSelector,
            IAttributesSelector attributesSelector, IDice dice)
        {
            this.percentileSelector = percentileSelector;
            this.materialsSelector = materialsSelector;
            this.attributesSelector = attributesSelector;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = percentileSelector.SelectFrom("MundaneArmors", roll);
            var armor = new Item();

            if (result == TraitConstants.Darkwood)
            {
                var tableName = String.Format("{0}Shields", result);
                roll = dice.Percentile();
                armor.Name = percentileSelector.SelectFrom(tableName, roll);
                armor.Attributes = attributesSelector.SelectFrom(ArmorConstants.Buckler, "ArmorAttributes");
                armor.Traits.Add(result);

                return armor;
            }
            else if (result == TraitConstants.Masterwork)
            {
                var tableName = String.Format("{0}Shields", result);
                roll = dice.Percentile();
                armor.Name = percentileSelector.SelectFrom(tableName, roll);
                armor.Traits.Add(result);
            }
            else
            {
                armor.Name = result;
            }

            if (armor.Name == ArmorConstants.StuddedLeatherArmor)
                armor.Traits.Add(TraitConstants.Masterwork);

            armor.Attributes = attributesSelector.SelectFrom(armor.Name, "ArmorAttributes");

            roll = dice.Percentile();
            var size = percentileSelector.SelectFrom("ArmorSizes", roll);
            armor.Traits.Add(size);

            if (materialsSelector.HasSpecialMaterial(armor.Attributes))
            {
                var specialMaterial = materialsSelector.GenerateFor(armor.Attributes);
                armor.Traits.Add(specialMaterial);

                if (specialMaterial == TraitConstants.Dragonhide)
                    armor.Attributes = armor.Attributes.Except(new[] { AttributeConstants.Metal, AttributeConstants.Wood });
            }

            return armor;
        }
    }
}