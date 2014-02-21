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
        private IAttributesProvider typesProvider;
        private ISpecialAbilitiesGenerator gearSpecialAbilitiesProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;
        private IIntelligenceGenerator intelligenceGenerator;

        public MagicalArmorGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IAttributesProvider typesProvider,
            ISpecialAbilitiesGenerator gearSpecialAbilitiesProvider, ISpecialMaterialGenerator materialsProvider,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator, IIntelligenceGenerator intelligenceGenerator)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.typesProvider = typesProvider;
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
            var abilities = 0;

            while (result.Type == "SpecialAbility")
            {
                abilities += result.Amount;
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
                armor.Attributes = typesProvider.GetAttributesFor(armor.Name, "ArmorTypes");
                armor.Magic[Magic.Abilities] = gearSpecialAbilitiesProvider.GenerateFor(armor.Attributes, power, result.Amount, abilities);

                if (materialsProvider.HasSpecialMaterial(armor.Attributes))
                {
                    var specialMaterial = materialsProvider.GenerateFor(armor.Attributes);
                    armor.Traits.Add(specialMaterial);
                }

                var traits = magicItemTraitsGenerator.GenerateFor(ItemTypeConstants.Armor);
                armor.Traits.AddRange(traits);

                armor.Magic[Magic.Intelligence] = intelligenceGenerator.GenerateFor(ItemTypeConstants.Armor);
            }

            return armor;
        }
    }
}