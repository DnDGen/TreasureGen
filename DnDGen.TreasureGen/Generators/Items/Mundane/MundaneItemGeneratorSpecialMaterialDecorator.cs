using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;
using DnDGen.TreasureGen.Tables;
using System.Linq;

namespace DnDGen.TreasureGen.Generators.Items.Mundane
{
    internal class MundaneItemGeneratorSpecialMaterialDecorator : MundaneItemGenerator
    {
        private readonly MundaneItemGenerator innerGenerator;
        private readonly ISpecialMaterialGenerator specialMaterialGenerator;
        private readonly ICollectionSelector collectionsSelector;

        public MundaneItemGeneratorSpecialMaterialDecorator(MundaneItemGenerator innerGenerator, ISpecialMaterialGenerator specialMaterialGenerator, ICollectionSelector collectionsSelector)
        {
            this.innerGenerator = innerGenerator;
            this.specialMaterialGenerator = specialMaterialGenerator;
            this.collectionsSelector = collectionsSelector;
        }

        public Item GenerateRandom()
        {
            var item = innerGenerator.GenerateRandom();
            item = AddSpecialMaterials(item);

            return item;
        }

        public Item Generate(string itemName, params string[] traits)
        {
            var item = innerGenerator.Generate(itemName, traits);
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

            var masterworkMaterials = collectionsSelector.SelectFrom(TableNameConstants.Collections.Set.SpecialMaterials, TraitConstants.Masterwork);
            if (item.Traits.Intersect(masterworkMaterials).Any())
                item.Traits.Add(TraitConstants.Masterwork);

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
    }
}