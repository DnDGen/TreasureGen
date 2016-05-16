using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal interface ICurseGenerator
    {
        bool HasCurse(bool isMagical);
        string GenerateCurse();
        Item GenerateSpecificCursedItem();
    }
}