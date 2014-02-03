using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MagicalArmorGenerator : IMagicalGearGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private ITypesProvider typesProvider;
        private ISpecialAbilitiesGenerator gearSpecialAbilitiesProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IMagicalItemTraitsGenerator magicItemTraitsGenerator;

        public MagicalArmorGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, ITypesProvider typesProvider,
            ISpecialAbilitiesGenerator gearSpecialAbilitiesProvider, ISpecialMaterialGenerator materialsProvider,
            IMagicalItemTraitsGenerator magicItemTraitsGenerator)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.typesProvider = typesProvider;
            this.gearSpecialAbilitiesProvider = gearSpecialAbilitiesProvider;
            this.materialsProvider = materialsProvider;
            this.magicItemTraitsGenerator = magicItemTraitsGenerator;
        }

        public Gear GenerateAtPower(String power)
        {
            if (power == ItemsConstants.Power.Mundane)
                throw new ArgumentException();

            var tableName = String.Format("{0}Armor", power);
            var result = typeAndAmountPercentileProvider.GetResultFrom(tableName);
            var armor = new Gear();
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
                armor.MagicalBonus = result.Amount;
            }

            armor.Name = percentileResultProvider.GetResultFrom(tableName);
            armor.Types = typesProvider.GetTypesFor(armor.Name, "ArmorTypes");

            if (!specific)
            {
                armor.Abilities = gearSpecialAbilitiesProvider.GenerateFor(armor.Types, power, armor.MagicalBonus, abilities);

                if (materialsProvider.HasSpecialMaterial(armor.Types))
                {
                    var specialMaterial = materialsProvider.GenerateFor(armor.Types);
                    armor.Traits.Add(specialMaterial);
                }

                var traits = magicItemTraitsGenerator.GenerateFor(ItemsConstants.ItemTypes.Armor);
                armor.Traits.AddRange(traits);
            }

            return armor;
        }
    }
}