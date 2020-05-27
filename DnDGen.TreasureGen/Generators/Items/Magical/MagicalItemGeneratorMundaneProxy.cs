using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using System;

namespace DnDGen.TreasureGen.Generators.Items.Magical
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

        public Item GenerateRandom(string power)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            return innerGenerator.GenerateRandom(power);
        }

        public Item Generate(string power, string itemName, params string[] traits)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            return innerGenerator.Generate(power, itemName, traits);
        }

        public bool IsItemOfPower(string itemName, string power)
        {
            if (power == PowerConstants.Mundane)
                return false;

            return innerGenerator.IsItemOfPower(itemName, power);
        }
    }
}