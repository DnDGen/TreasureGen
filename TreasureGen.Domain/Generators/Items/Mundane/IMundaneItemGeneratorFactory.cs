using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Mundane
{
    public interface IMundaneItemGeneratorFactory
    {
        MundaneItemGenerator CreateGeneratorOf(string itemType);
    }
}