using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Core.Generation.Generators.Interfaces;
using EquipmentGen.Core.Generation.Providers.Interfaces;

namespace EquipmentGen.Core.Generation.Generators
{
    public class MundaneArmorGenerator : IMundaneGearGenerator
    {
        private IPercentileResultProvider percentileResultProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private ITypesProvider typesProvider;

        public MundaneArmorGenerator(IPercentileResultProvider percentileResultProvider, ISpecialMaterialGenerator materialsProvider,
            ITypesProvider typesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.materialsProvider = materialsProvider;
            this.typesProvider = typesProvider;
        }

        public Gear Generate()
        {
            var result = percentileResultProvider.GetResultFrom("MundaneArmor");
            var armor = new Gear();

            if (result == TraitConstants.Darkwood || result == TraitConstants.Masterwork)
            {
                var tableName = String.Format("{0}Shields", result);
                armor.Name = percentileResultProvider.GetResultFrom(tableName);
                armor.Traits.Add(result);
            }
            else
            {
                armor.Name = result;
            }

            if (armor.Name == ArmorConstants.StuddedLeatherArmor)
                armor.Traits.Add(TraitConstants.Masterwork);

            armor.Types = typesProvider.GetTypesFor(armor.Name, "ArmorTypes");

            var size = percentileResultProvider.GetResultFrom("ArmorSizes");
            armor.Traits.Add(size);

            if (!armor.Traits.Contains(TraitConstants.Darkwood) && materialsProvider.HasSpecialMaterial(armor.Types))
            {
                var specialMaterial = materialsProvider.GenerateFor(armor.Types);
                armor.Traits.Add(specialMaterial);

                if (specialMaterial == TraitConstants.Dragonhide)
                    armor.Types = armor.Types.Except(new[] { TypeConstants.Metal, TypeConstants.Wood });
            }

            return armor;
        }
    }
}