using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Domain.Generators.Items.Magical
{
    internal interface ICurseGenerator : MundaneItemGenerator
    {
        bool HasCurse(bool isMagical);
        bool IsSpecificCursedItem(Item template);
        string GenerateCurse();
    }
}