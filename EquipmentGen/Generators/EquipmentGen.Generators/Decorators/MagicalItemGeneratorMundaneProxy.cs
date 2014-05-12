using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Decorators
{
    public class MagicalItemGeneratorMundaneProxy : IMagicalItemGenerator
    {
        private IMagicalItemGenerator innerGenerator;

        public MagicalItemGeneratorMundaneProxy(IMagicalItemGenerator innerGenerator)
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