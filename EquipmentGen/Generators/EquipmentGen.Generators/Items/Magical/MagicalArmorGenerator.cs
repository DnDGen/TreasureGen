using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalArmorGenerator : IMagicalItemGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private ISpecialAbilitiesGenerator specialAbilitiesSelector;
        private ISpecialMaterialGenerator materialsSelector;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private ISpecificGearGenerator specificGearGenerator;

        public MagicalArmorGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IPercentileSelector percentileSelector, IAttributesSelector attributesSelector, ISpecialAbilitiesGenerator specialAbilitiesSelector, ISpecialMaterialGenerator materialsSelector, IMagicalItemTraitsGenerator magicItemTraitsGenerator, ISpecificGearGenerator specificGearGenerator)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.specialAbilitiesSelector = specialAbilitiesSelector;
            this.materialsSelector = materialsSelector;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
            this.specificGearGenerator = specificGearGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var tableName = String.Format("{0}Armors", power);
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var abilityCount = 0;

            while (result.Type == "SpecialAbility")
            {
                abilityCount += Convert.ToInt32(result.Amount);
                result = typeAndAmountPercentileSelector.SelectFrom(tableName);
            }

            if (result.Type.StartsWith("Specific", StringComparison.InvariantCultureIgnoreCase))
                return specificGearGenerator.GenerateFrom(power, result.Type);

            tableName = String.Format("{0}Types", result.Type);

            var armor = new Item();
            armor.ItemType = ItemTypeConstants.Armor;
            armor.Name = percentileSelector.SelectFrom(tableName);
            armor.Attributes = attributesSelector.SelectFrom("ArmorAttributes", armor.Name);
            armor.Magic.Bonus = Convert.ToInt32(result.Amount);
            armor.Magic.SpecialAbilities = specialAbilitiesSelector.GenerateFor(armor.ItemType, armor.Attributes, power, armor.Magic.Bonus, abilityCount); ;

            if (materialsSelector.HasSpecialMaterial(armor.ItemType, armor.Attributes))
            {
                var specialMaterial = materialsSelector.GenerateFor(armor.ItemType, armor.Attributes);
                armor.Traits.Add(specialMaterial);
            }

            var traits = magicItemTraitsGenerator.GenerateFor(armor.ItemType);
            armor.Traits.AddRange(traits);

            return armor;
        }
    }
}