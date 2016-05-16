using TreasureGen.Items.Magical;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal interface IMagicalItemGeneratorFactory
    {
        MagicalItemGenerator CreateGeneratorOf(string type);
    }
}