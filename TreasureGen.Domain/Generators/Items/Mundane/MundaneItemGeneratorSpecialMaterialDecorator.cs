using System.Collections.Generic;
using System.Linq;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneItemGeneratorSpecialMaterialDecorator : MundaneItemGenerator
    {
        private readonly MundaneItemGenerator innerGenerator;
        private readonly ISpecialMaterialGenerator specialMaterialGenerator;
        private readonly IEnumerable<string> masterworkMaterials;

        public MundaneItemGeneratorSpecialMaterialDecorator(MundaneItemGenerator innerGenerator, ISpecialMaterialGenerator specialMaterialGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.specialMaterialGenerator = specialMaterialGenerator;

            masterworkMaterials = new[]
            {
                TraitConstants.SpecialMaterials.Adamantine,
                TraitConstants.SpecialMaterials.Darkwood,
                TraitConstants.SpecialMaterials.Dragonhide,
                TraitConstants.SpecialMaterials.Mithral,
            };
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

            if (item.Traits.Intersect(masterworkMaterials).Any())
                item.Traits.Add(TraitConstants.Masterwork);

            return item;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);

            if (allowRandomDecoration)
            {
                item = AddSpecialMaterials(item);
            }

            return item;
        }

        public Item GenerateFrom(IEnumerable<string> subset)
        {
            var item = innerGenerator.GenerateFrom(subset);
            item = AddSpecialMaterials(item);

            return item;
        }
    }
}