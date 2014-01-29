using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class PowerArmorGenerator : IPowerGearGenerator
    {
        private ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider;
        private IPercentileResultProvider percentileResultProvider;
        private IGearTypesProvider gearTypesProvider;
        private IGearSpecialAbilitiesGenerator gearSpecialAbilitiesProvider;
        private ISpecialMaterialGenerator materialsProvider;

        public PowerArmorGenerator(ITypeAndAmountPercentileResultProvider typeAndAmountPercentileProvider,
            IPercentileResultProvider percentileResultProvider, IGearTypesProvider gearTypesProvider,
            IGearSpecialAbilitiesGenerator gearSpecialAbilitiesProvider, ISpecialMaterialGenerator materialsProvider)
        {
            this.typeAndAmountPercentileProvider = typeAndAmountPercentileProvider;
            this.percentileResultProvider = percentileResultProvider;
            this.gearTypesProvider = gearTypesProvider;
            this.gearSpecialAbilitiesProvider = gearSpecialAbilitiesProvider;
            this.materialsProvider = materialsProvider;
        }

        public Gear GenerateAtPower(String power)
        {
            var tableName = String.Format("{0}Armor", power);
            var result = typeAndAmountPercentileProvider.GetTypeAndAmountPercentileResult(tableName);
            var armor = new Gear();
            var abilities = 0;

            while (result.Type == "SpecialAbility")
            {
                abilities += result.Amount;
                result = typeAndAmountPercentileProvider.GetTypeAndAmountPercentileResult(tableName);
            }

            var specific = result.Type.StartsWith("Specific", StringComparison.InvariantCultureIgnoreCase);
            if (specific)
            {
                tableName = String.Format("{0}Specific{1}", power, result.Type);
            }
            else
            {
                tableName = String.Format("{0}Type", result.Type);
                armor.MagicalBonus = result.Amount;
            }

            armor.Name = percentileResultProvider.GetPercentileResult(tableName);
            armor.Types = gearTypesProvider.GetGearTypesFor(armor.Name);

            if (!specific)
            {
                armor.Abilities = gearSpecialAbilitiesProvider.GenerateFor(armor.Types, power, armor.MagicalBonus, abilities);

                if (materialsProvider.HasSpecialMaterial())
                {
                    var specialMaterial = materialsProvider.GenerateSpecialMaterialFor(armor.Types);
                    if (!String.IsNullOrEmpty(specialMaterial))
                        armor.Traits.Add(specialMaterial);
                }
            }

            return armor;
        }
    }
}