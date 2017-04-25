using TreasureGen.Domain.Selectors.Selections;

namespace TreasureGen.Domain.Selectors.Collections
{
    internal interface IWeaponDataSelector
    {
        WeaponSelection Select(string name);
    }
}
