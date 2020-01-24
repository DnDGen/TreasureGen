using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Mundane;

namespace DnDGen.TreasureGen.Generators.Items.Magical
{
    internal interface ICurseGenerator : MundaneItemGenerator
    {
        bool HasCurse(Item item);
        bool IsSpecificCursedItem(Item template);
        bool IsSpecificCursedItem(string itemName);
        bool CanBeSpecificCursedItem(string itemName);
        bool ItemTypeCanBeSpecificCursedItem(string itemType);
        string GenerateCurse();
        Item GenerateSpecificCursedItem(string itemType);
    }
}