using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalItemGeneratorMundaneProxy : MagicalItemGenerator
    {
        private readonly MagicalItemGenerator innerGenerator;

        public MagicalItemGeneratorMundaneProxy(MagicalItemGenerator innerGenerator)
        {
            this.innerGenerator = innerGenerator;
        }

        public Item Generate(Item template, bool allowRandomDecoration = false)
        {
            return innerGenerator.Generate(template, allowRandomDecoration);
        }

        public Item GenerateAtPower(string power)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            return innerGenerator.GenerateAtPower(power);
        }

        public Item GenerateFromSubset(string power, IEnumerable<string> subset)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            if (!subset.Any())
                throw new ArgumentException("Cannot generate from an empty collection subset");

            return innerGenerator.GenerateFromSubset(power, subset);
        }
    }
}