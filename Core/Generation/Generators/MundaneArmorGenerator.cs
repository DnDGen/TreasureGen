using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MundaneArmorGenerator : IMundaneGearGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IGearTypesProvider gearTypesProvider;

        public MundaneArmorGenerator(IPercentileResultProvider percentileResultProvider, ISpecialMaterialGenerator materialsProvider,
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
                var specialMaterial = materialsProvider.GenerateSpecialMaterialFor(armor.Types);
                if (!String.IsNullOrEmpty(specialMaterial))
                {
                    armor.Traits.Add(specialMaterial);

                    if (specialMaterial == ItemsConstants.Gear.Traits.Dragonhide)
                        armor.Types = armor.Types.Where(t => t != ItemsConstants.Gear.Types.Metal && t != ItemsConstants.Gear.Types.Wood);
                }
            }

            return armor;
        }
    }
}