using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Generators.Items.Magical
{
    internal class MagicalItemGeneratorMundaneProxy : MagicalItemGenerator
    {
        private readonly MagicalItemGenerator innerGenerator;

        public MagicalItemGeneratorMundaneProxy(MagicalItemGenerator innerGenerator)
        {
            this.innerGenerator = innerGenerator;
        }

        public Item GenerateFrom(Item template, bool allowRandomDecoration = false)
        {
            return innerGenerator.GenerateFrom(template, allowRandomDecoration);
        }

        public Item GenerateFrom(string power)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            return innerGenerator.GenerateFrom(power);
        }

        public Item GenerateFrom(string power, IEnumerable<string> subset, params string[] traits)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            return innerGenerator.GenerateFrom(power, subset, traits);
        }
    }
}