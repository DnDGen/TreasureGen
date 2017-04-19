using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneItemGeneratorSpecialMaterialDecorator : MundaneItemGenerator
    {
        private MundaneItemGenerator innerGenerator;
        private ISpecialMaterialGenerator specialMaterialGenerator;

        public MundaneItemGeneratorSpecialMaterialDecorator(MundaneItemGenerator innerGenerator, ISpecialMaterialGenerator specialMaterialGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.specialMaterialGenerator = specialMaterialGenerator;
        }

        public Item Generate()
        {
            var item = innerGenerator.Generate();
            item = AddSpecialMaterials(item);

            return item;
        }

        private Item AddSpecialMaterials(Item item)
        {
            while (specialMaterialGenerator.CanHaveSpecialMaterial(item.ItemType, item.Attributes, item.Traits))
            {
                var material = specialMaterialGenerator.GenerateFor(item.ItemType, item.Attributes, item.Traits);
                item.Traits.Add(material);

                if (material == TraitConstants.SpecialMaterials.Dragonhide)
                {
                    var metalAndWood = new[] { AttributeConstants.Metal, AttributeConstants.Wood };
                    item.Attributes = item.Attributes.Except(metalAndWood);
                }
            }

            return item;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var item = innerGenerator.Generate(template, allowRandomDecoration);

            if (allowRandomDecoration)
            {
                item = AddSpecialMaterials(item);
            }

            return item;
        }

        public Item GenerateFromSubset(IEnumerable<string> subset)
        {
            var item = innerGenerator.GenerateFromSubset(subset);
            item = AddSpecialMaterials(item);

            return item;
        }
    }
}