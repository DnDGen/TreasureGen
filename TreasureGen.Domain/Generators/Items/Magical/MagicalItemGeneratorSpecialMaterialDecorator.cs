﻿using System.Linq;
using TreasureGen.Domain.Items.Mundane;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalItemGeneratorSpecialMaterialDecorator : MagicalItemGenerator
    {
        private MagicalItemGenerator innerGenerator;
        private ISpecialMaterialGenerator specialMaterialGenerator;

        public MagicalItemGeneratorSpecialMaterialDecorator(MagicalItemGenerator innerGenerator, ISpecialMaterialGenerator specialMaterialGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.specialMaterialGenerator = specialMaterialGenerator;
        }

        public Item GenerateAtPower(string power)
        {
            var item = innerGenerator.GenerateAtPower(power);

            if (item.Magic.Curse == CurseConstants.SpecificCursedItem)
                return item;

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