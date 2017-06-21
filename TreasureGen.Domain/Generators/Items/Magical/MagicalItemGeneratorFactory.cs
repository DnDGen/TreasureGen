using TreasureGen.Domain.Generators.Factories;
using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal class MagicalItemGeneratorFactory : IMagicalItemGeneratorFactory
    {
        private readonly JustInTimeFactory justInTimeFactory;

        public MagicalItemGeneratorFactory(JustInTimeFactory justInTimeFactory)
        {
            this.justInTimeFactory = justInTimeFactory;
        }

        public MagicalItemGenerator CreateGeneratorOf(string itemType)
        {
            return justInTimeFactory.Build<MagicalItemGenerator>(itemType);
        }
    }
}