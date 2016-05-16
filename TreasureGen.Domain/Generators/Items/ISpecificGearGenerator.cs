using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items
{
    internal interface ISpecificGearGenerator
    {
        Item GenerateFrom(string power, string specificGearType);
    }
}