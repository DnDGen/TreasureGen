using TreasureGen.Domain.Generators.Factories;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    internal class MundaneItemGeneratorFactory : IMundaneItemGeneratorFactory
    {
        private readonly JustInTimeFactory justInTimeFactory;

        public MundaneItemGeneratorFactory(JustInTimeFactory justInTimeFactory)
        {
            this.justInTimeFactory = justInTimeFactory;
        }

        public MundaneItemGenerator CreateGeneratorOf(string itemType)
        {
            return justInTimeFactory.Build<MundaneItemGenerator>(itemType);
        }
    }
}