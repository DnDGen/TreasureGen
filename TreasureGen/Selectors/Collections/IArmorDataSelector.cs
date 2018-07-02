using TreasureGen.Selectors.Selections;

namespace TreasureGen.Selectors.Collections
{
    internal interface IArmorDataSelector
    {
        ArmorSelection Select(string name);
    }
}
