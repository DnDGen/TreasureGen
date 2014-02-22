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
        private IAttributesProvider attributesProvider;

        public MundaneArmorGenerator(IPercentileResultProvider percentileResultProvider, ISpecialMaterialGenerator materialsProvider,
            IAttributesProvider typesProvider)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.materialsProvider = materialsProvider;
            this.attributesProvider = typesProvider;
        }

        public Item Generate()
        {
            var result = percentileResultProvider.GetResultFrom("MundaneArmor");
            var armor = new Item();

            if (result == TraitConstants.Darkwood)
            {
                var tableName = String.Format("{0}Shields", result);
                armor.Name = percentileResultProvider.GetResultFrom(tableName);
                armor.Attributes = attributesProvider.GetAttributesFor(ArmorConstants.Buckler, "ArmorAttributes");
                armor.Traits.Add(result);

                return armor;
            }
            else if (result == TraitConstants.Masterwork)
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

            armor.Attributes = attributesProvider.GetAttributesFor(armor.Name, "ArmorAttributes");

            var size = percentileResultProvider.GetResultFrom("ArmorSizes");
            armor.Traits.Add(size);

            if (materialsProvider.HasSpecialMaterial(armor.Attributes))
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