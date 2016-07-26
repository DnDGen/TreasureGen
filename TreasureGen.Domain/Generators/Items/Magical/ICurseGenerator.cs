using TreasureGen.Items;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal interface ICurseGenerator
    {
        bool HasCurse(bool isMagical);
        bool IsSpecificCursedItem(Item template);
        string GenerateCurse();
        Item GenerateSpecificCursedItem();
        Item GenerateSpecificCursedItem(Item template);
    }
}