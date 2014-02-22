using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MagicalArmorGenerator : IMagicalGearGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IAttributesProvider attributesProvider;
        private ISpecialAbilitiesGenerator gearSpecialAbilitiesProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;

        public MagicalArmorGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IAttributesProvider attributesProvider,
            ISpecialAbilitiesGenerator gearSpecialAbilitiesProvider, ISpecialMaterialGenerator materialsProvider,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.attributesProvider = attributesProvider;
            this.gearSpecialAbilitiesProvider = gearSpecialAbilitiesProvider;
            this.materialsProvider = materialsProvider;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
            this.intelligenceGenerator = intelligenceGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            var tableName = String.Format("{0}Armor", power);
            var result = typeAndAmountPercentileProvider.GetResultFrom(tableName);
            var armor = new Item();
            var abilityCount = 0;

            while (result.Type == "SpecialAbility")
            {
                abilityCount += result.Amount;
                result = typeAndAmountPercentileProvider.GetResultFrom(tableName);
            }

            var specific = result.Type.StartsWith("Specific", StringComparison.InvariantCultureIgnoreCase);
            if (specific)
            {
                tableName = power + result.Type;
            }
            else
            {
                tableName = String.Format("{0}Type", result.Type);
                armor.Magic[Magic.Bonus] = result.Amount;
            }

            armor.Name = percentileResultProvider.GetResultFrom(tableName);

            if (!specific)
            {
                armor.Attributes = attributesProvider.GetAttributesFor(armor.Name, "ArmorAttributes");
                var abilities = gearSpecialAbilitiesProvider.GenerateFor(armor.Attributes, power, result.Amount, abilityCount);
                armor.Magic.Add(Magic.Abilities, abilities);

                if (materialsProvider.HasSpecialMaterial(armor.Attributes))
                {
                    var specialMaterial = materialsProvider.GenerateFor(armor.Attributes);
                    armor.Traits.Add(specialMaterial);
                }

                var traits = magicItemTraitsGenerator.GenerateFor(ItemTypeConstants.Armor);
                armor.Traits.AddRange(traits);

                if (intelligenceGenerator.IsIntelligent(ItemTypeConstants.Armor, armor.Attributes))
                {
                    var intelligence = intelligenceGenerator.GenerateFor(ItemTypeConstants.Armor);
                    armor.Magic.Add(Magic.Intelligence, intelligence);
                }
            }

            return armor;
        }
    }
}