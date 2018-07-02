using DnDGen.Core.Selectors.Collections;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items.Mundane;
using TreasureGen.Tables;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Generators.Items.Magical
{
    internal class MagicalItemGeneratorSpecialMaterialDecorator : MagicalItemGenerator
    {
        private readonly MagicalItemGenerator innerGenerator;
        private readonly ISpecialMaterialGenerator specialMaterialGenerator;
        private readonly ICollectionSelector collectionsSelector;

        public MagicalItemGeneratorSpecialMaterialDecorator(MagicalItemGenerator innerGenerator, ISpecialMaterialGenerator specialMaterialGenerator, ICollectionSelector collectionsSelector)
        {
            this.innerGenerator = innerGenerator;
            this.specialMaterialGenerator = specialMaterialGenerator;
            this.collectionsSelector = collectionsSelector;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);

            item = AddSpecialMaterials(item, allowRandomDecoration);

            return item;
        }

        private Item AddSpecialMaterials(Item item, bool allowMaterials)
        {
            while (allowMaterials && specialMaterialGenerator.CanHaveSpecialMaterial(item.ItemType, item.Attributes, item.Traits))
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

        public Item GenerateFrom(string power)
        {
            var item = innerGenerator.GenerateFrom(power);

            if (item.Magic.Curse == CurseConstants.SpecificCursedItem)
                return item;

            item = AddSpecialMaterials(item, true);

            return item;
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            var item = innerGenerator.GenerateFrom(power, subset, traits);

            if (item.Magic.Curse == CurseConstants.SpecificCursedItem)
                return item;

            item = AddSpecialMaterials(item, true);

            return item;
        }
    }
}