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
        private IAttributesProvider typesProvider;

        public MundaneArmorGenerator(IPercentileResultProvider percentileResultProvider, ISpecialMaterialGenerator materialsProvider,
            IAttributesProvider typesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.materialsProvider = materialsProvider;
            this.typesProvider = typesProvider;
        }

        public Item Generate()
        {
            var result = percentileResultProvider.GetResultFrom("MundaneArmor");
            var armor = new Item();

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

            armor.Attributes = typesProvider.GetAttributesFor(armor.Name, "ArmorTypes");

            var size = percentileResultProvider.GetResultFrom("ArmorSizes");
            armor.Traits.Add(size);

            if (!armor.Traits.Contains(TraitConstants.Darkwood) && materialsProvider.HasSpecialMaterial(armor.Attributes))
            {
                var specialMaterial = materialsProvider.GenerateFor(armor.Attributes);
                armor.Traits.Add(specialMaterial);

                if (specialMaterial == TraitConstants.Dragonhide)
                    armor.Attributes = armor.Attributes.Except(new[] { AttributeConstants.Metal, AttributeConstants.Wood });
            }

            return armor;
        }
    }
}