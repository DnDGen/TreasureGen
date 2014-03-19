using System;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces;
using EquipmentGen.Selectors.Interfaces;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Generators.Items.Magical
{
    public class MagicalArmorGenerator : IMagicalGearGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IAttributesProvider attributesProvider;
        private ISpecialAbilitiesGenerator specialAbilitiesProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;
        private ISpecificGearGenerator specificGearGenerator;
        private IDice dice;

        public MagicalArmorGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IAttributesProvider attributesProvider,
            ISpecialAbilitiesGenerator specialAbilitiesProvider, ISpecialMaterialGenerator materialsProvider,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator,
            ISpecificGearGenerator specificGearGenerator, IDice dice)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.attributesProvider = attributesProvider;
            this.specialAbilitiesProvider = specialAbilitiesProvider;
            this.materialsProvider = materialsProvider;
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
            var result = typeAndAmountPercentileProvider.GetResultFrom(tableName, roll);
            var armor = new Item();
            var abilityCount = 0;

            while (result.Type == "SpecialAbility")
            {
                abilityCount += dice.Roll(result.AmountToRoll);
                roll = dice.Percentile();
                result = typeAndAmountPercentileProvider.GetResultFrom(tableName, roll);
            }

            if (result.Type.StartsWith("Specific", StringComparison.InvariantCultureIgnoreCase))
                return specificGearGenerator.GenerateFrom(power, result.Type);

            tableName = String.Format("{0}Types", result.Type);

            armor.Magic[Magic.Bonus] = result.AmountToRoll;
            roll = dice.Percentile();
            armor.Name = percentileResultProvider.GetResultFrom(tableName, roll);
            armor.Attributes = attributesProvider.GetAttributesFor(armor.Name, "ArmorAttributes");

            var quantity = dice.Roll(result.AmountToRoll);
            var abilities = specialAbilitiesProvider.GenerateWith(armor.Attributes, power, quantity, abilityCount);
            armor.Magic[Magic.Abilities] = abilities;

            if (materialsProvider.HasSpecialMaterial(armor.Attributes))
            {
                var specialMaterial = materialsProvider.GenerateFor(armor.Attributes);
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