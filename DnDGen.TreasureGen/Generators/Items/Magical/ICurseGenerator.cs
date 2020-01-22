using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal interface ICurseGenerator : MundaneItemGenerator
    {
        bool HasCurse(bool isMagical);
        bool IsSpecificCursedItem(Item template);
        string GenerateCurse();
    }
}