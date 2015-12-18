using System;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Items.Magical;

namespace TreasureGen.Generators.Domain.Decorators
{
    public class MagicalItemGeneratorMundaneProxy : MagicalItemGenerator
    {
        private MagicalItemGenerator innerGenerator;

        public MagicalItemGeneratorMundaneProxy(MagicalItemGenerator innerGenerator)
        {
            this.innerGenerator = innerGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            if (power == PowerConstants.Mundane)
                throw new ArgumentException();

            return innerGenerator.GenerateAtPower(power);
        }
    }
}