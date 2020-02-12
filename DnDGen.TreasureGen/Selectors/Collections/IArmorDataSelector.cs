using DnDGen.TreasureGen.Selectors.Selections;

namespace DnDGen.TreasureGen.Selectors.Collections
{
    internal interface IArmorDataSelector
    {
        ArmorSelection Select(string name);
    }
}
