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

        public Item GenerateFrom(string power, string itemName)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            return innerGenerator.GenerateFrom(power, itemName);
        }

        public bool IsItemOfPower(string itemName, string power)
        {
            if (power == PowerConstants.Mundane)
                return false;

            return innerGenerator.IsItemOfPower(itemName, power);
        }
    }
}