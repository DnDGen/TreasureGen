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

        public Item GenerateAtPower(string power)
        {
            var item = innerGenerator.GenerateAtPower(power);
            if (item.IsMagical == false)
                return item;

            var traits = traitsGenerator.GenerateFor(item.ItemType, item.Attributes);

            item.Traits.AddRange(traits);
            return item;
        }
    }
}