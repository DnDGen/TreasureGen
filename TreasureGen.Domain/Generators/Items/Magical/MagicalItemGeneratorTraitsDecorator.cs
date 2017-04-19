using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalItemGeneratorTraitsDecorator : MagicalItemGenerator
    {
        private MagicalItemGenerator innerGenerator;
        private IMagicalItemTraitsGenerator traitsGenerator;

        public MagicalItemGeneratorTraitsDecorator(MagicalItemGenerator innerGenerator, IMagicalItemTraitsGenerator traitsGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.traitsGenerator = traitsGenerator;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            var item = innerGenerator.Generate(template, allowRandomDecoration);

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

        public Item GenerateAtPower(string power)
        {
            var item = innerGenerator.GenerateAtPower(power);
            if (item.IsMagical == false)
                return item;

            item = AddTraits(item);

            return item;
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            var item = innerGenerator.GenerateFromSubset(power, subset);
            if (item.IsMagical == false)
                return item;

            item = AddTraits(item);

            return item;
        }
    }
}