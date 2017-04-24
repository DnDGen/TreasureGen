using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal interface IArmorDataSelector
    {
        ArmorSelection Select(string name);
    }
}
