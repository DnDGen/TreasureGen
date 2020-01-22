using System.Collections.Generic;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal class MagicalItemGeneratorTraitsDecorator : MagicalItemGenerator
    {
        private readonly MagicalItemGenerator innerGenerator;
        private readonly IMagicalItemTraitsGenerator traitsGenerator;

        public MagicalItemGeneratorTraitsDecorator(MagicalItemGenerator innerGenerator, IMagicalItemTraitsGenerator traitsGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.traitsGenerator = traitsGenerator;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            var item = innerGenerator.GenerateFrom(template, allowRandomDecoration);

            if (allowRandomDecoration)
            {
                item = AddTraits(item);
            }

            return item;
        }

        private Item AddTraits(Item item)
        {
            var traits = traitsGenerator.GenerateFor(item.ItemType, item.Attributes);

            foreach (var trait in traits)
                item.Traits.Add(trait);

            return item;
        }

        public Item GenerateFrom(string power)
        {
            var item = innerGenerator.GenerateFrom(power);
            if (!item.IsMagical)
                return item;

            item = AddTraits(item);

            return item;
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            var item = innerGenerator.GenerateFrom(power, subset, traits);
            if (!item.IsMagical)
                return item;

            item = AddTraits(item);

            return item;
        }
    }
}