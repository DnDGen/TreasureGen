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

            if (result == ItemsConstants.Gear.Traits.Darkwood || result == ItemsConstants.Gear.Traits.Masterwork)
            {
                var tableName = String.Format("{0}Shields", result);
                armor.Name = percentileResultProvider.GetPercentileResult(tableName);
                armor.Traits.Add(result);
            }
            else
            {
                armor.Name = result;
            }

            if (armor.Name == ItemsConstants.Gear.Armor.StuddedLeatherArmor)
                armor.Traits.Add(ItemsConstants.Gear.Traits.Masterwork);

            armor.Types = gearTypesProvider.GetGearTypesFor(armor.Name);

            var size = percentileResultProvider.GetPercentileResult("ArmorSizes");
            armor.Traits.Add(size);

            if (!armor.Traits.Contains(ItemsConstants.Gear.Traits.Darkwood) && materialsProvider.HasSpecialMaterial())
            {
                var specialMaterial = materialsProvider.GetSpecialMaterialFor(armor.Types);
                armor.Traits.Add(specialMaterial);
            }

            return armor;
        }
    }
}