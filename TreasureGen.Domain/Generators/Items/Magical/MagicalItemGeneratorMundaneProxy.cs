using System;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalItemGeneratorMundaneProxy : MagicalItemGenerator
    {
        private MagicalItemGenerator innerGenerator;

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
    }
}