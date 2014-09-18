using System;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;
using EquipmentGen.Generators.Interfaces.Items.Mundane;

namespace EquipmentGen.Generators.Decorators
{
    public class MagicalItemGeneratorSpecialMaterialDecorator : IMagicalItemGenerator
    {
        private IMagicalItemGenerator innerGenerator;
        private ISpecialMaterialGenerator specialMaterialGenerator;

        public MagicalItemGeneratorSpecialMaterialDecorator(IMagicalItemGenerator innerGenerator, ISpecialMaterialGenerator specialMaterialGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.specialMaterialGenerator = specialMaterialGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var item = innerGenerator.GenerateAtPower(power);

            while (specialMaterialGenerator.CanHaveSpecialMaterial(item.ItemType, item.Attributes, item.Traits))
            {
                var material = specialMaterialGenerator.GenerateFor(item.ItemType, item.Attributes, item.Traits);
                item.Traits.Add(material);

                if (material == TraitConstants.Dragonhide)
                {
                    var metalAndWood = new[] { AttributeConstants.Metal, AttributeConstants.Wood };
                    item.Attributes = item.Attributes.Except(metalAndWood);
                }
            }

            return item;
        }
    }
}