using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalArmorGenerator : IMagicalGearGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IPercentileSelector percentileSelector;
        private IAttributesSelector attributesSelector;
        private ISpecialAbilitiesGenerator specialAbilitiesSelector;
        private ISpecialMaterialGenerator materialsSelector;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private ISpecificGearGenerator specificGearGenerator;
        private IDice dice;

        public MagicalArmorGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector,
            IPercentileSelector percentileSelector, IAttributesSelector attributesSelector,
            ISpecialAbilitiesGenerator specialAbilitiesSelector, ISpecialMaterialGenerator materialsSelector,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            ISpecificGearGenerator specificGearGenerator, IDice dice)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.percentileSelector = percentileSelector;
            this.attributesSelector = attributesSelector;
            this.specialAbilitiesSelector = specialAbilitiesSelector;
            this.materialsSelector = materialsSelector;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
            this.specificGearGenerator = specificGearGenerator;
            this.dice = dice;
        }

        public Item GenerateAtPower(String power)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            var tableName = String.Format("{0}Armors", power);
            var roll = dice.Percentile();
            var result = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);
            var armor = new Item();
            var abilityCount = 0;

            while (result.Type == "SpecialAbility")
            {
                abilityCount += dice.Roll(result.AmountToRoll);
                roll = dice.Percentile();
                result = typeAndAmountPercentileSelector.SelectFrom(tableName, roll);
            }

            if (result.Type.StartsWith("Specific", StringComparison.InvariantCultureIgnoreCase))
                return specificGearGenerator.GenerateFrom(power, result.Type);

            tableName = String.Format("{0}Types", result.Type);

            armor.Magic[Magic.Bonus] = result.AmountToRoll;
            roll = dice.Percentile();
            armor.Name = percentileSelector.SelectFrom(tableName, roll);
            armor.Attributes = attributesSelector.SelectFrom(armor.Name, "ArmorAttributes");

            var quantity = dice.Roll(result.AmountToRoll);
            var abilities = specialAbilitiesSelector.GenerateWith(armor.Attributes, power, quantity, abilityCount);
            armor.Magic[Magic.Abilities] = abilities;

            if (materialsSelector.HasSpecialMaterial(armor.Attributes))
            {
                var specialMaterial = materialsSelector.GenerateFor(armor.Attributes);
                armor.Traits.Add(specialMaterial);
            }

            var traits = magicItemTraitsGenerator.GenerateFor(ItemTypeConstants.Armor);
            armor.Traits.AddRange(traits);

            if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.Armor, armor.Attributes, armor.Magic))
            {
                var intelligence = intelligenceGenerator.GenerateFor(armor.Magic);
                armor.Magic.Add(Magic.Intelligence, intelligence);
            }

            return armor;
        }
    }
}