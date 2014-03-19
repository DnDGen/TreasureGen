using System;
using System.Linq;
using D20Dice;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Mundane;
using EquipmentGen.Selectors.Interfaces;

namespace EquipmentGen.Generators.Items.Mundane
{
    public class MundaneArmorGenerator : IMundaneGearGenerator
    {
        private IPercentileSelector percentileResultProvider;
        private ISpecialMaterialGenerator materialsProvider;
        private IAttributesSelector attributesProvider;
        private IDice dice;

        public MundaneArmorGenerator(IPercentileSelector percentileResultProvider, ISpecialMaterialGenerator materialsProvider,
            IAttributesSelector attributesProvider, IDice dice)
        {
            this.percentileResultProvider = percentileResultProvider;
            this.materialsProvider = materialsProvider;
            this.attributesProvider = attributesProvider;
            this.dice = dice;
        }

        public Item Generate()
        {
            var roll = dice.Percentile();
            var result = percentileResultProvider.SelectFrom("MundaneArmors", roll);
            var armor = new Item();

            if (result == TraitConstants.Darkwood)
            {
                var tableName = String.Format("{0}Shields", result);
                roll = dice.Percentile();
                armor.Name = percentileResultProvider.SelectFrom(tableName, roll);
                armor.Attributes = attributesProvider.SelectFrom(ArmorConstants.Buckler, "ArmorAttributes");
                armor.Traits.Add(result);

                return armor;
            }
            else if (result == TraitConstants.Masterwork)
            {
                var tableName = String.Format("{0}Shields", result);
                roll = dice.Percentile();
                armor.Name = percentileResultProvider.SelectFrom(tableName, roll);
                armor.Traits.Add(result);
            }
            else
            {
                armor.Name = result;
            }

            if (armor.Name == ArmorConstants.StuddedLeatherArmor)
                armor.Traits.Add(TraitConstants.Masterwork);

            armor.Attributes = attributesProvider.SelectFrom(armor.Name, "ArmorAttributes");

            roll = dice.Percentile();
            var size = percentileResultProvider.SelectFrom("ArmorSizes", roll);
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