using System;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MundaneArmorGenerator : IMundaneGearGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private IMaterialsProvider materialsProvider;
        private IGearTypesProvider gearTypesProvider;

        public MundaneArmorGenerator(IPercentileResultProvider percentileResultProvider, IMaterialsProvider materialsProvider,
            IGearTypesProvider gearTypesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.materialsProvider = materialsProvider;
            this.gearTypesProvider = gearTypesProvider;
        }

        public Gear Generate()
        {
            var result = percentileResultProvider.GetPercentileResult("MundaneArmor");

            var armor = new Gear();

            if (result == "DarkwoodShields")
            {
                armor.Name = percentileResultProvider.GetPercentileResult(result);
                armor.Traits.Add(ItemsConstants.Gear.Traits.Darkwood);
            }
            else if (result == "MasterworkShields")
            {
                armor.Name = percentileResultProvider.GetPercentileResult(result);
                armor.Traits.Add(ItemsConstants.Gear.Traits.Masterwork);
            }
            else if (result.StartsWith(ItemsConstants.Gear.Traits.Masterwork, StringComparison.InvariantCultureIgnoreCase))
            {
                armor.Name = result.Replace("Masterwork ", String.Empty);
                armor.Traits.Add(ItemsConstants.Gear.Traits.Masterwork);
            }
            else
            {
                armor.Name = result;
            }

            armor.Types = gearTypesProvider.GetGearTypesFor(armor.Name);

            var size = percentileResultProvider.GetPercentileResult("ArmorSizes");
            armor.Traits.Add(size);

            if (materialsProvider.HasSpecialMaterial())
            {
                var specialMaterial = materialsProvider.GetSpecialMaterialFor(armor.Types);
                armor.Traits.Add(specialMaterial);
            }

            return armor;
        }
    }
}