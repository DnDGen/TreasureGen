using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Generators.Interfaces.Items.Magical;

namespace EquipmentGen.Generators.Decorators
{
    public class MagicalItemGeneratorTraitsDecorator : IMagicalItemGenerator
    {
        private IMagicalItemGenerator innerGenerator;
        private IMagicalItemTraitsGenerator traitsGenerator;

        public MagicalItemGeneratorTraitsDecorator(IMagicalItemGenerator innerGenerator, IMagicalItemTraitsGenerator traitsGenerator)
        {
            this.innerGenerator = innerGenerator;
            this.traitsGenerator = traitsGenerator;
        }

        public Item GenerateAtPower(String power)
        {
            var item = innerGenerator.GenerateAtPower(power);
            var traits = traitsGenerator.GenerateFor(item.ItemType, item.Attributes);

            item.Traits.AddRange(traits);
            return item;
        }
    }
}